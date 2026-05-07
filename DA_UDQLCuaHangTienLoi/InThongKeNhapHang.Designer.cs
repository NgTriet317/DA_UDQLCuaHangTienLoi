namespace DA_UDQLCuaHangTienLoi
{
    partial class InThongKeNhapHang
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboChoNgayNhap = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.crystalReportViewer3 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.rptThongKeNhapHang1 = new DA_UDQLCuaHangTienLoi.rptThongKeNhapHang();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboChoNgayNhap);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(873, 101);
            this.panel1.TabIndex = 0;
            // 
            // cboChoNgayNhap
            // 
            this.cboChoNgayNhap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChoNgayNhap.FormattingEnabled = true;
            this.cboChoNgayNhap.Location = new System.Drawing.Point(319, 41);
            this.cboChoNgayNhap.Margin = new System.Windows.Forms.Padding(4);
            this.cboChoNgayNhap.Name = "cboChoNgayNhap";
            this.cboChoNgayNhap.Size = new System.Drawing.Size(267, 24);
            this.cboChoNgayNhap.TabIndex = 1;
            this.cboChoNgayNhap.SelectedIndexChanged += new System.EventHandler(this.cboChoNgayNhap_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(212, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn ngày:";
            // 
            // crystalReportViewer3
            // 
            this.crystalReportViewer3.ActiveViewIndex = 0;
            this.crystalReportViewer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer3.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer3.Location = new System.Drawing.Point(0, 101);
            this.crystalReportViewer3.Margin = new System.Windows.Forms.Padding(4);
            this.crystalReportViewer3.Name = "crystalReportViewer3";
            this.crystalReportViewer3.ReportSource = this.rptThongKeNhapHang1;
            this.crystalReportViewer3.Size = new System.Drawing.Size(873, 372);
            this.crystalReportViewer3.TabIndex = 1;
            this.crystalReportViewer3.ToolPanelWidth = 267;
            // 
            // InThongKeNhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 473);
            this.Controls.Add(this.crystalReportViewer3);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "InThongKeNhapHang";
            this.Text = "InThongKeNhapHang";
            this.Load += new System.EventHandler(this.InThongKeNhapHang_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboChoNgayNhap;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer3;
        private rptThongKeNhapHang rptThongKeNhapHang1;
    }
}