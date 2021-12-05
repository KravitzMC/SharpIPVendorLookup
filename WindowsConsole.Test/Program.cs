using System;
using ZunMega.Net.DeviceManufacturer;

namespace WindowsConsole.Test
{
    internal class Program
    {
        [Obsolete]
        static void Main(string[] args)
        {
            //-------------------------------------------------------------------------------------

            ///!!! Warning : Before run it please set your range ip address from network adapter.

            //-------------------------------------------------------------------------------------

            IPDeviceManufacturerScanner manufacturerScanner = new IPDeviceManufacturerScanner();

            ///Scan by default gateway (current network connection).
            manufacturerScanner.SetIPAddress();

            manufacturerScanner.ScanRecieved += ManufacturerScanner_ScanRecieved;
            manufacturerScanner.ScanComplete += ManufacturerScanner_ScanComplete;

            ///Scan by IP custom range.
            //manufacturerScanner.SetIPAddress(IPAddress.Parse("192.168.1.1"), IPAddress.Parse("192.168.1.255"));

            ///Scan by IP-Destination and return to your gateway router.
            //manufacturerScanner.SetIPAddress(IPAddress.Parse("192.168.1.15"));

            manufacturerScanner.StartScan();

            Console.ReadKey();

        }

        static void ManufacturerScanner_ScanRecieved(object sender, ScanRecievedEventArgs args)
        {
            Console.WriteLine(
                $"IP Address : {args.IPAddress.ToString()} \n" +
                $"MAC Address : {args.MACAddress} \n" +
                $"Host Name : {args.HostName}\n" +
                $"Network Adapter Company : {args.CompanyName} \n" +
                $"Company Address : {args.CompanyAddress} \n" +
                $"Country Code : {args.CountryCode}\n" +
                $"Country Name : {args.CountryName}\n");

            Console.WriteLine("-----------------------------------------------------------");
        }

        static void ManufacturerScanner_ScanComplete(object sender, EventArgs e)
        {
            Console.WriteLine("Complete..!!");
            Console.ReadKey();
        }
    }
}
