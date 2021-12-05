using System;
using System.Windows.Forms;
using System.Net;
using ZunMega.Net.DeviceManufacturer;

namespace WindowsForms.Test
{
    public partial class FormDemo : Form
    {
        private IPDeviceManufacturerScanner manufacturerScanner = null;
        public FormDemo()
        {
            InitializeComponent();
        }
        private void FormDemo_Load(object sender, EventArgs e)
        {
            if (manufacturerScanner == null)
            {
                manufacturerScanner = new IPDeviceManufacturerScanner();
                manufacturerScanner.ScanRecieved += ManufacturerScanner_ScanRecieved;
                manufacturerScanner.ScanComplete += ManufacturerScanner_ScanComplete;
            }
        }

        private void ManufacturerScanner_ScanComplete(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    chk1.Checked = tbIPAddrFrom.Enabled = tbIPAddrTo.Enabled = btnScan.Enabled = true;
                    lblSc.Text = "Scan Complete";
                    MessageBox.Show("Scan Complete", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }));
            }
            else
            {
                chk1.Checked = tbIPAddrFrom.Enabled = tbIPAddrTo.Enabled = btnScan.Enabled = true;
                lblSc.Text = "Scan Complete";
                MessageBox.Show("Scan Complete", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ManufacturerScanner_ScanRecieved(object sender, ScanRecievedEventArgs args)
        {
            //Use cross thread operation for debug mode.

            if (InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    DgvIPScanner.Rows.Add(
                        $"{args.IPAddress}",
                        $"{args.MACAddress}",
                        $"{args.HostName}",
                        $"{args.CompanyName}",
                        $"{args.CompanyAddress}",
                        $"{args.CountryCode}",
                        $"{args.CountryName}");

                    tooTotal.Text = $"Scan Total : {args.Total} Items";
                }));
            }
            else
            {
                DgvIPScanner.Rows.Add(
                        $"{args.IPAddress}",
                        $"{args.MACAddress}",
                        $"{args.HostName}",
                        $"{args.CompanyName}",
                        $"{args.CompanyAddress}",
                        $"{args.CountryCode}",
                        $"{args.CountryName}");

                tooTotal.Text = $"Scan Total : {args.Total} Items";
            }
        }

        [Obsolete]
        private void btnScan_Click(object sender, EventArgs e)
        {
            //Clear data UI before start.

            DgvIPScanner.Rows.Clear();

            if (chk1.Checked)
                manufacturerScanner.SetIPAddress();
            else
                manufacturerScanner.SetIPAddress(IPAddress.Parse(tbIPAddrFrom.Text), IPAddress.Parse(tbIPAddrTo.Text));

            manufacturerScanner.StartScan();

            tbIPAddrFrom.Enabled = tbIPAddrTo.Enabled = btnScan.Enabled = false;
            lblSc.Text = "Scaning...";
        }
        private void chk1_CheckedChanged(object sender, EventArgs e)
        {
            if (chk1.Checked)
                tbIPAddrFrom.Enabled = tbIPAddrTo.Enabled = false;
            else
                tbIPAddrFrom.Enabled = tbIPAddrTo.Enabled = true;
        }
    }
}
