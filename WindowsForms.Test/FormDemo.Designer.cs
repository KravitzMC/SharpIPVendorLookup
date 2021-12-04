namespace WindowsForms.Test
{
    partial class FormDemo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnScan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbIPAddrTo = new System.Windows.Forms.TextBox();
            this.tbIPAddrFrom = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk1 = new System.Windows.Forms.CheckBox();
            this.DgvIPScanner = new System.Windows.Forms.DataGridView();
            this.col_ipaddr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_mac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_hostName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_company = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_companyAddr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_countryCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_countryname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSc = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tooTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvIPScanner)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(743, 59);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(171, 35);
            this.btnScan.TabIndex = 0;
            this.btnScan.Text = "Start Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "From :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(388, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "To :";
            // 
            // tbIPAddrTo
            // 
            this.tbIPAddrTo.Enabled = false;
            this.tbIPAddrTo.Location = new System.Drawing.Point(428, 66);
            this.tbIPAddrTo.Name = "tbIPAddrTo";
            this.tbIPAddrTo.Size = new System.Drawing.Size(279, 27);
            this.tbIPAddrTo.TabIndex = 3;
            this.tbIPAddrTo.Text = "192.168.1.255";
            // 
            // tbIPAddrFrom
            // 
            this.tbIPAddrFrom.Enabled = false;
            this.tbIPAddrFrom.Location = new System.Drawing.Point(88, 66);
            this.tbIPAddrFrom.Name = "tbIPAddrFrom";
            this.tbIPAddrFrom.Size = new System.Drawing.Size(279, 27);
            this.tbIPAddrFrom.TabIndex = 4;
            this.tbIPAddrFrom.Text = "192.168.1.1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chk1);
            this.groupBox1.Controls.Add(this.btnScan);
            this.groupBox1.Controls.Add(this.tbIPAddrFrom);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbIPAddrTo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(25, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(936, 113);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IP Address ";
            // 
            // chk1
            // 
            this.chk1.AutoSize = true;
            this.chk1.Checked = true;
            this.chk1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.chk1.Location = new System.Drawing.Point(88, 32);
            this.chk1.Name = "chk1";
            this.chk1.Size = new System.Drawing.Size(214, 24);
            this.chk1.TabIndex = 5;
            this.chk1.Text = "Use Default Gateway.";
            this.chk1.UseVisualStyleBackColor = true;
            this.chk1.CheckedChanged += new System.EventHandler(this.chk1_CheckedChanged);
            // 
            // DgvIPScanner
            // 
            this.DgvIPScanner.AllowUserToAddRows = false;
            this.DgvIPScanner.AllowUserToDeleteRows = false;
            this.DgvIPScanner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvIPScanner.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.DgvIPScanner.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvIPScanner.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_ipaddr,
            this.col_mac,
            this.col_hostName,
            this.col_company,
            this.col_companyAddr,
            this.col_countryCode,
            this.col_countryname});
            this.DgvIPScanner.Location = new System.Drawing.Point(25, 155);
            this.DgvIPScanner.MultiSelect = false;
            this.DgvIPScanner.Name = "DgvIPScanner";
            this.DgvIPScanner.ReadOnly = true;
            this.DgvIPScanner.RowHeadersVisible = false;
            this.DgvIPScanner.RowHeadersWidth = 51;
            this.DgvIPScanner.RowTemplate.Height = 24;
            this.DgvIPScanner.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvIPScanner.Size = new System.Drawing.Size(1283, 422);
            this.DgvIPScanner.TabIndex = 6;
            // 
            // col_ipaddr
            // 
            this.col_ipaddr.HeaderText = "IP Address";
            this.col_ipaddr.MinimumWidth = 6;
            this.col_ipaddr.Name = "col_ipaddr";
            this.col_ipaddr.ReadOnly = true;
            this.col_ipaddr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_ipaddr.Width = 150;
            // 
            // col_mac
            // 
            this.col_mac.HeaderText = "MAC Address";
            this.col_mac.MinimumWidth = 6;
            this.col_mac.Name = "col_mac";
            this.col_mac.ReadOnly = true;
            this.col_mac.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_mac.Width = 150;
            // 
            // col_hostName
            // 
            this.col_hostName.HeaderText = "Host Name";
            this.col_hostName.MinimumWidth = 6;
            this.col_hostName.Name = "col_hostName";
            this.col_hostName.ReadOnly = true;
            this.col_hostName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_hostName.Width = 160;
            // 
            // col_company
            // 
            this.col_company.HeaderText = "Network Adapter Company";
            this.col_company.MinimumWidth = 6;
            this.col_company.Name = "col_company";
            this.col_company.ReadOnly = true;
            this.col_company.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_company.Width = 230;
            // 
            // col_companyAddr
            // 
            this.col_companyAddr.HeaderText = "Company Address";
            this.col_companyAddr.MinimumWidth = 6;
            this.col_companyAddr.Name = "col_companyAddr";
            this.col_companyAddr.ReadOnly = true;
            this.col_companyAddr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_companyAddr.Width = 240;
            // 
            // col_countryCode
            // 
            this.col_countryCode.HeaderText = "Country Code";
            this.col_countryCode.MinimumWidth = 6;
            this.col_countryCode.Name = "col_countryCode";
            this.col_countryCode.ReadOnly = true;
            this.col_countryCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_countryCode.Width = 150;
            // 
            // col_countryname
            // 
            this.col_countryname.HeaderText = "Country Name";
            this.col_countryname.MinimumWidth = 6;
            this.col_countryname.Name = "col_countryname";
            this.col_countryname.ReadOnly = true;
            this.col_countryname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_countryname.Width = 200;
            // 
            // lblSc
            // 
            this.lblSc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblSc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSc.Location = new System.Drawing.Point(980, 40);
            this.lblSc.Name = "lblSc";
            this.lblSc.Size = new System.Drawing.Size(328, 75);
            this.lblSc.TabIndex = 7;
            this.lblSc.Text = "-";
            this.lblSc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.BackColor = System.Drawing.Color.Silver;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tooTotal});
            this.statusStrip1.Location = new System.Drawing.Point(0, 596);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1338, 39);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tooTotal
            // 
            this.tooTotal.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tooTotal.Name = "tooTotal";
            this.tooTotal.Size = new System.Drawing.Size(64, 33);
            this.tooTotal.Text = "Total :";
            // 
            // FormDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1338, 635);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblSc);
            this.Controls.Add(this.DgvIPScanner);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormDemo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " IEEE Vendors Device Manufacturer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormDemo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvIPScanner)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbIPAddrTo;
        private System.Windows.Forms.TextBox tbIPAddrFrom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DgvIPScanner;
        private System.Windows.Forms.Label lblSc;
        private System.Windows.Forms.CheckBox chk1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ipaddr;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mac;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_hostName;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_company;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_companyAddr;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_countryCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_countryname;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tooTotal;
    }
}