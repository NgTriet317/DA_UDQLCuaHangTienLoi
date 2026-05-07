namespace DA_UDQLCuaHangTienLoi
{
    partial class NhanVien
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnNhanVien = new Guna.UI2.WinForms.Guna2Button();
            this.btnCaLam = new Guna.UI2.WinForms.Guna2Button();
            this.pnMainNV = new System.Windows.Forms.Panel();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.guna2Panel1.BorderColor = System.Drawing.Color.Black;
            this.guna2Panel1.BorderThickness = 2;
            this.guna2Panel1.Controls.Add(this.guna2HtmlLabel1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(982, 50);
            this.guna2Panel1.TabIndex = 0;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.SystemColors.Control;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(0, 0);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(982, 50);
            this.guna2HtmlLabel1.TabIndex = 0;
            this.guna2HtmlLabel1.Text = "QUẢN LÝ NHÂN VIÊN";
            this.guna2HtmlLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.guna2HtmlLabel1.Click += new System.EventHandler(this.guna2HtmlLabel1_Click);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.BorderRadius = 15;
            this.btnNhanVien.BorderThickness = 2;
            this.btnNhanVien.CustomizableEdges.BottomLeft = false;
            this.btnNhanVien.CustomizableEdges.BottomRight = false;
            this.btnNhanVien.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNhanVien.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNhanVien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNhanVien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNhanVien.FillColor = System.Drawing.Color.Gainsboro;
            this.btnNhanVien.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNhanVien.ForeColor = System.Drawing.Color.Black;
            this.btnNhanVien.Location = new System.Drawing.Point(39, 69);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Size = new System.Drawing.Size(190, 45);
            this.btnNhanVien.TabIndex = 1;
            this.btnNhanVien.Text = "Danh sách nhân viên";
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // btnCaLam
            // 
            this.btnCaLam.BorderRadius = 15;
            this.btnCaLam.BorderThickness = 2;
            this.btnCaLam.CustomizableEdges.BottomLeft = false;
            this.btnCaLam.CustomizableEdges.BottomRight = false;
            this.btnCaLam.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCaLam.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCaLam.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCaLam.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCaLam.FillColor = System.Drawing.Color.DarkGray;
            this.btnCaLam.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCaLam.ForeColor = System.Drawing.Color.Black;
            this.btnCaLam.Location = new System.Drawing.Point(235, 69);
            this.btnCaLam.Name = "btnCaLam";
            this.btnCaLam.Size = new System.Drawing.Size(187, 45);
            this.btnCaLam.TabIndex = 1;
            this.btnCaLam.Text = "Danh sách ca làm";
            this.btnCaLam.Click += new System.EventHandler(this.btnCaLam_Click);
            // 
            // pnMainNV
            // 
            this.pnMainNV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnMainNV.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnMainNV.Location = new System.Drawing.Point(12, 113);
            this.pnMainNV.Name = "pnMainNV";
            this.pnMainNV.Size = new System.Drawing.Size(958, 529);
            this.pnMainNV.TabIndex = 2;
            this.pnMainNV.Paint += new System.Windows.Forms.PaintEventHandler(this.pnMainNV_Paint);
            // 
            // NhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(982, 654);
            this.Controls.Add(this.pnMainNV);
            this.Controls.Add(this.btnCaLam);
            this.Controls.Add(this.btnNhanVien);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "NhanVien";
            this.Text = "Danh sách nhân viên";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.NhanVien_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Button btnNhanVien;
        private Guna.UI2.WinForms.Guna2Button btnCaLam;
        private System.Windows.Forms.Panel pnMainNV;
    }
}