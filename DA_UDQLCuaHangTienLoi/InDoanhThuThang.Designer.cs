namespace DA_UDQLCuaHangTienLoi
{
    partial class InDoanhThuThang
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
            this.cboChonThang = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.crystalReportViewer2 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.rptThongKeDoanhThuThang1 = new DA_UDQLCuaHangTienLoi.rptThongKeDoanhThuThang();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboChonThang);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1067, 76);
            this.panel1.TabIndex = 0;
            // 
            // cboChonThang
            // 
            this.cboChonThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChonThang.FormattingEnabled = true;
            this.cboChonThang.Location = new System.Drawing.Point(427, 31);
            this.cboChonThang.Margin = new System.Windows.Forms.Padding(4);
            this.cboChonThang.Name = "cboChonThang";
            this.cboChonThang.Size = new System.Drawing.Size(224, 24);
            this.cboChonThang.TabIndex = 1;
            this.cboChonThang.SelectedIndexChanged += new System.EventHandler(this.cboChonThang_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(316, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn tháng:";
            // 
            // crystalReportViewer2
            // 
            this.crystalReportViewer2.ActiveViewIndex = 0;
            this.crystalReportViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer2.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer2.Location = new System.Drawing.Point(0, 76);
            this.crystalReportViewer2.Margin = new System.Windows.Forms.Padding(4);
            this.crystalReportViewer2.Name = "crystalReportViewer2";
            this.crystalReportViewer2.ReportSource = this.rptThongKeDoanhThuThang1;
            this.crystalReportViewer2.Size = new System.Drawing.Size(1067, 478);
            this.crystalReportViewer2.TabIndex = 1;
            this.crystalReportViewer2.ToolPanelWidth = 267;
            // 
            // InDoanhThuThang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.crystalReportViewer2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "InDoanhThuThang";
            this.Text = "InDoanhThuThang";
            this.Load += new System.EventHandler(this.InDoanhThuThang_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboChonThang;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer2;
        private rptThongKeDoanhThuThang rptThongKeDoanhThuThang1;
    }
}