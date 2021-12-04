using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace Acolyte.Net.Manufacturer
{
    public static class Win32ApiCalls
    {
        [DllImport("iphlpapi.dll", CharSet = CharSet.Auto)]
        public static extern int GetBestInterface(UInt32 destAddr, out UInt32 bestIfIndex);

        [DllImport("iphlpapi.dll", ExactSpelling = true)]
        public static extern int SendARP(int DestIP, int SrcIP, [Out] byte[] pMacAddr, ref int PhyAddrLen);
    }

    public class IPDeviceManufacturerScanner
    {
        /// <summary>
        /// Set IP Destination Address.
        /// </summary>
        private IPAddress IPDefaultGateway { get; set; }
        /// <summary>
        /// Set IP Address range by from.
        /// </summary>
        private IPAddress IPAddressFrom { get; set; }

        /// <summary>
        /// Set IP Address range by to.
        /// </summary>
        private IPAddress IPAddressTo { get; set; }

        /// <summary>
        /// Check Mac Address if is null.
        /// </summary>
        private readonly string EMPTY_MAC_ADDRESS = "00-00-00-00-00-00";

        private readonly string MAC_ADDR_DB_NAME = "MacAddress";

        /// <summary>
        /// Max Postfix range ip address.
        /// </summary>
        private readonly Int32 MAX_RANGE_IP = 255;
        private Int32 IP_NUM_FROM { get; set; }
        private Int32 IP_NUM_TO { get; set; }
        private string IP_PREFIX_FROM { get; set; }
        private string IP_PREFIX_TO { get; set; }

        private LiteDatabase MACAddressVendorDB = null;

        private ILiteCollection<MacAddressCollection> MACAddrCollection = null;

        /// <summary>
        /// Get Current Device Path Database from assembly.
        /// </summary>
        private string DevicePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dist", "Devices.db");

        public IPDeviceManufacturerScanner()
        {
            InitialCollection();
        }

        private void InitialCollection()
        {
            if (MACAddressVendorDB == null)
            {
                MACAddressVendorDB = new LiteDatabase(DevicePath);
                MACAddrCollection = MACAddressVendorDB.GetCollection<MacAddressCollection>(MAC_ADDR_DB_NAME);
            }
        }

        /// <summary>
        /// Set IP Address within custom range.
        /// </summary>
        /// <param name="ipAddressFrom"></param>
        /// <param name="ipAddressTo"></param>
        public void SetIPAddress(IPAddress ipAddressFrom, IPAddress ipAddressTo)
        {
            this.IPAddressFrom = ipAddressFrom;
            this.IPAddressTo = ipAddressTo;
        }

        /// <summary>
        /// Set IP Address by default gateway network connection.
        /// </summary>
        /// <param name="fromNetworkAdapter"></param>
        public void SetIPAddress()
        {
            this.IPDefaultGateway = GetDefaultGateway();
            this.IPAddressFrom = IPDefaultGateway;
            var ip = this.IPDefaultGateway.ToString().Split('.');
            this.IPAddressTo = IPAddress.Parse($"{ip[0]}.{ip[1]}.{ip[2]}.255");
        }

        /// <summary>
        /// Set IP Address through ip client destination and return to default gateway.
        /// </summary>
        public void SetIPAddress(IPAddress IPDestinationAddress)
        {
            this.IPDefaultGateway = GetGatewayForDestination(IPDestinationAddress);
            this.IPAddressFrom = this.IPDefaultGateway;
            var ip = this.IPDefaultGateway.ToString().Split('.');
            this.IPAddressTo = IPAddress.Parse($"{ip[0]}.{ip[1]}.{ip[2]}.255");
        }

        /// <summary>
        /// Start Scan IP Address
        /// </summary>
        /// <exception cref="IPAddressOutOfRangeException"></exception>
        /// <exception cref="IPAddressInvalidRangeException"></exception>
        [Obsolete]
        public void StartScan()
        {
            var _ipAddrFrom = IPAddressFrom.ToString().Split('.');
            var _ipAddrTo = IPAddressTo.ToString().Split('.');
            var totalIPScan = 0;

            IP_PREFIX_FROM = $"{_ipAddrFrom[0]}.{_ipAddrFrom[1]}.{_ipAddrFrom[2]}";
            IP_PREFIX_TO = $"{_ipAddrTo[0]}.{_ipAddrTo[1]}.{_ipAddrTo[2]}";

            IP_NUM_FROM = Convert.ToInt32(this.IPAddressFrom.ToString().Split('.')[3]);
            IP_NUM_TO = Convert.ToInt32(this.IPAddressTo.ToString().Split('.')[3]);

            if (IP_NUM_TO > MAX_RANGE_IP)
                throw new IPAddressOutOfRangeException("IP Address postfix range must between 1 - 255.");

            if (IP_PREFIX_FROM != IP_PREFIX_TO)
                throw new IPAddressInvalidRangeException("IP Address range between From and To are not equal.");

            var tasks = new List<Task>
            {
                Task.Run(() =>
                {
                    Parallel.For(IP_NUM_FROM, IP_NUM_TO, ip =>
                    {
                        try
                        {
                            var IpAddress = $"{IP_PREFIX_FROM}.{ip}";
                            IPAddress hostIPAddress = IPAddress.Parse(IpAddress);
                            byte[] ab = new byte[6];
                            int len = ab.Length, r = Win32ApiCalls.SendARP((int)hostIPAddress.Address, 0, ab, ref len);
                            var MacAddr = BitConverter.ToString(ab);

                            if (MacAddr != EMPTY_MAC_ADDRESS)
                            {
                                var STR_MAC = BitConverter.ToString(ab).Split('-');

                                var MacAddressPattern1 = $"{STR_MAC[0]}:{STR_MAC[1]}:{STR_MAC[2]}";
                                var MacAddressPattern2 = $"{STR_MAC[0]}:{STR_MAC[1]}:{STR_MAC[2]}:{STR_MAC[3]}";
                                var MacAddressPattern3 = $"{STR_MAC[0]}:{STR_MAC[1]}:{STR_MAC[2]}:{STR_MAC[3]}:{STR_MAC[4].Remove(STR_MAC[4].Length - 1)}";

                                var mac = MACAddrCollection.FindAll().Where(x => x.oui == MacAddressPattern1
                                || x.oui == MacAddressPattern2
                                || x.oui == MacAddressPattern3).FirstOrDefault();

                                OnRaiseScanReceived(new ScanRecievedEventArgs(IPAddress.Parse(IpAddress),
                                    MacAddr, GetHostName(IpAddress),
                                    mac.companyName,
                                    mac.companyAddress,
                                    mac.countryCode,
                                    totalIPScan+=1));
                            }
                        }
                        catch (Exception) { }
                    });
            }).ContinueWith((x)=> {

                if (ScanComplete != null)
                    ScanComplete(this, null);})
            };

            Task.WaitAll();
        }

        /// <summary>
        /// Get host name from IP Address
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        private string GetHostName(string ipAddress)
        {
            try
            {
                IPHostEntry entry = Dns.GetHostEntry(ipAddress);
                if (entry != null)
                {
                    return entry.HostName;
                }
            }
            catch (System.Net.Sockets.SocketException) { }

            return null;
        }

        #region Utils

        /// <summary>
        /// This function reference from :https://stackoverflow.com/a/28546099
        /// </summary>
        /// <returns></returns>
        private IPAddress GetDefaultGateway()
        {
            IPAddress result = null;
            var cards = NetworkInterface.GetAllNetworkInterfaces().ToList();
            if (cards.Any())
            {
                foreach (var card in cards)
                {
                    var props = card.GetIPProperties();
                    if (props == null)
                        continue;

                    var gateways = props.GatewayAddresses;
                    if (!gateways.Any())
                        continue;

                    var gateway =
                        gateways.FirstOrDefault(g => g.Address.AddressFamily.ToString() == "InterNetwork");
                    if (gateway == null)
                        continue;

                    result = gateway.Address;
                    break;
                };
            }

            return result;
        }

        /// <summary>
        /// This function reference from : https://stackoverflow.com/a/13635038
        /// </summary>
        /// <param name="destinationAddress"></param>
        /// <returns></returns>
        /// <exception cref="Win32Exception"></exception>
        public static IPAddress GetGatewayForDestination(IPAddress destinationAddress)
        {
            UInt32 destaddr = BitConverter.ToUInt32(destinationAddress.GetAddressBytes(), 0);

            uint interfaceIndex;
            int result = Win32ApiCalls.GetBestInterface(destaddr, out interfaceIndex);
            if (result != 0)
                throw new System.ComponentModel.Win32Exception(result);

            foreach (var ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                var niprops = ni.GetIPProperties();
                if (niprops == null)
                    continue;

                var gateway = niprops.GatewayAddresses?.FirstOrDefault()?.Address;
                if (gateway == null)
                    continue;

                if (ni.Supports(NetworkInterfaceComponent.IPv4))
                {
                    var v4props = niprops.GetIPv4Properties();
                    if (v4props == null)
                        continue;

                    if (v4props.Index == interfaceIndex)
                        return gateway;
                }

                if (ni.Supports(NetworkInterfaceComponent.IPv6))
                {
                    var v6props = niprops.GetIPv6Properties();
                    if (v6props == null)
                        continue;

                    if (v6props.Index == interfaceIndex)
                        return gateway;
                }
            }

            return null;
        }

        #endregion

        #region Events

        public delegate void ScanRecievedEventHandler(object sender, ScanRecievedEventArgs args);
        public event ScanRecievedEventHandler ScanRecieved;
        public event EventHandler ScanComplete;

        protected virtual void OnRaiseScanReceived(ScanRecievedEventArgs args)
        {
            if (ScanRecieved != null)
                ScanRecieved(this, args);
        }

        #endregion
    }
}
