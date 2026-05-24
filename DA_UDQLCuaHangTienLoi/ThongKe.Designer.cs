namespace DA_UDQLCuaHangTienLoi
{
    partial class ThongKe
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
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnNhapHang = new System.Windows.Forms.Button();
			this.btnDoanhThuThang = new System.Windows.Forms.Button();
			this.btnDoanhThu = new System.Windows.Forms.Button();
			this.pnHienThi = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(760, 44);
			this.panel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.Control;
			this.label1.Location = new System.Drawing.Point(308, 6);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(156, 31);
			this.label1.TabIndex = 0;
			this.label1.Text = "THỐNG KÊ";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.btnNhapHang);
			this.panel2.Controls.Add(this.btnDoanhThuThang);
			this.panel2.Controls.Add(this.btnDoanhThu);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 44);
			this.panel2.Margin = new System.Windows.Forms.Padding(2);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(760, 62);
			this.panel2.TabIndex = 1;
			// 
			// btnNhapHang
			// 
			this.btnNhapHang.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnNhapHang.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.btnNhapHang.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.btnNhapHang.Location = new System.Drawing.Point(276, 12);
			this.btnNhapHang.Margin = new System.Windows.Forms.Padding(2);
			this.btnNhapHang.Name = "btnNhapHang";
			this.btnNhapHang.Size = new System.Drawing.Size(109, 34);
			this.btnNhapHang.TabIndex = 0;
			this.btnNhapHang.Text = "Nhập hàng";
			this.btnNhapHang.UseVisualStyleBackColor = false;
			this.btnNhapHang.Click += new System.EventHandler(this.btnNhapHang_Click);
			// 
			// btnDoanhThuThang
			// 
			this.btnDoanhThuThang.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnDoanhThuThang.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.btnDoanhThuThang.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.btnDoanhThuThang.Location = new System.Drawing.Point(138, 12);
			this.btnDoanhThuThang.Margin = new System.Windows.Forms.Padding(2);
			this.btnDoanhThuThang.Name = "btnDoanhThuThang";
			this.btnDoanhThuThang.Size = new System.Drawing.Size(119, 34);
			this.btnDoanhThuThang.TabIndex = 0;
			this.btnDoanhThuThang.Text = "Doanh thu theo tháng";
			this.btnDoanhThuThang.UseVisualStyleBackColor = false;
			this.btnDoanhThuThang.Click += new System.EventHandler(this.btnDoanhThuThang_Click);
			// 
			// btnDoanhThu
			// 
			this.btnDoanhThu.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnDoanhThu.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.btnDoanhThu.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.btnDoanhThu.Location = new System.Drawing.Point(10, 12);
			this.btnDoanhThu.Margin = new System.Windows.Forms.Padding(2);
			this.btnDoanhThu.Name = "btnDoanhThu";
			this.btnDoanhThu.Size = new System.Drawing.Size(115, 34);
			this.btnDoanhThu.TabIndex = 0;
			this.btnDoanhThu.Text = "Doanh thu theo ngày";
			this.btnDoanhThu.UseVisualStyleBackColor = false;
			this.btnDoanhThu.Click += new System.EventHandler(this.btnDoanhThu_Click);
			// 
			// pnHienThi
			// 
			this.pnHienThi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnHienThi.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnHienThi.Location = new System.Drawing.Point(0, 106);
			this.pnHienThi.Margin = new System.Windows.Forms.Padding(2);
			this.pnHienThi.Name = "pnHienThi";
			this.pnHienThi.Size = new System.Drawing.Size(760, 377);
			this.pnHienThi.TabIndex = 2;
			this.pnHienThi.Paint += new System.Windows.Forms.PaintEventHandler(this.pnHienThi_Paint);
			// 
			// ThongKe
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(760, 483);
			this.Controls.Add(this.pnHienThi);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "ThongKe";
			this.Text = "ThongKe";
			this.Load += new System.EventHandler(this.ThongKe_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnNhapHang;
        private System.Windows.Forms.Button btnDoanhThu;
        private System.Windows.Forms.Panel pnHienThi;
        private System.Windows.Forms.Button btnDoanhThuThang;
    }
}