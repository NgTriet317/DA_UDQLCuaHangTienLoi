namespace DA_UDQLCuaHangTienLoi
{
    partial class TTSanPham
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
			this.dgvTT = new System.Windows.Forms.DataGridView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnThem = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.picQRCode = new Guna.UI2.WinForms.Guna2PictureBox();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.label4 = new System.Windows.Forms.Label();
			this.btnQuanLy = new System.Windows.Forms.Button();
			this.picHinh = new System.Windows.Forms.PictureBox();
			this.txtSL = new System.Windows.Forms.TextBox();
			this.txtMaSP = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.txtKM = new System.Windows.Forms.TextBox();
			this.txtTenSP = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtNCC = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtLoaiSP = new System.Windows.Forms.TextBox();
			this.txtGiaGoc = new System.Windows.Forms.TextBox();
			this.txtDVT = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtGiaSP = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgvTT)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picQRCode)).BeginInit();
			this.flowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picHinh)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvTT
			// 
			this.dgvTT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvTT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvTT.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.dgvTT.Location = new System.Drawing.Point(0, 541);
			this.dgvTT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.dgvTT.Name = "dgvTT";
			this.dgvTT.ReadOnly = true;
			this.dgvTT.RowHeadersWidth = 51;
			this.dgvTT.RowTemplate.Height = 24;
			this.dgvTT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvTT.Size = new System.Drawing.Size(1336, 274);
			this.dgvTT.TabIndex = 0;
			this.dgvTT.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTT_CellContentClick);
			this.dgvTT.Click += new System.EventHandler(this.dgvTT_Click);
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.btnThem);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(15, 16, 15, 16);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1336, 541);
			this.panel1.TabIndex = 1;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// btnThem
			// 
			this.btnThem.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnThem.BackColor = System.Drawing.Color.LawnGreen;
			this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnThem.Location = new System.Drawing.Point(62, 471);
			this.btnThem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnThem.Name = "btnThem";
			this.btnThem.Size = new System.Drawing.Size(89, 50);
			this.btnThem.TabIndex = 4;
			this.btnThem.Text = "Thêm";
			this.btnThem.UseVisualStyleBackColor = false;
			this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.picQRCode);
			this.panel2.Controls.Add(this.flowLayoutPanel1);
			this.panel2.Controls.Add(this.btnQuanLy);
			this.panel2.Controls.Add(this.picHinh);
			this.panel2.Controls.Add(this.txtSL);
			this.panel2.Controls.Add(this.txtMaSP);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.label12);
			this.panel2.Controls.Add(this.label9);
			this.panel2.Controls.Add(this.txtKM);
			this.panel2.Controls.Add(this.txtTenSP);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.txtNCC);
			this.panel2.Controls.Add(this.label7);
			this.panel2.Controls.Add(this.txtLoaiSP);
			this.panel2.Controls.Add(this.txtGiaGoc);
			this.panel2.Controls.Add(this.txtDVT);
			this.panel2.Controls.Add(this.label5);
			this.panel2.Controls.Add(this.txtGiaSP);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.label11);
			this.panel2.Controls.Add(this.label6);
			this.panel2.Location = new System.Drawing.Point(28, 38);
			this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1286, 405);
			this.panel2.TabIndex = 2;
			this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
			// 
			// picQRCode
			// 
			this.picQRCode.ImageRotate = 0F;
			this.picQRCode.Location = new System.Drawing.Point(289, 67);
			this.picQRCode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.picQRCode.Name = "picQRCode";
			this.picQRCode.Size = new System.Drawing.Size(109, 74);
			this.picQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picQRCode.TabIndex = 6;
			this.picQRCode.TabStop = false;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.flowLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel1.Controls.Add(this.label4);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(1284, 41);
			this.flowLayoutPanel1.TabIndex = 5;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.SystemColors.Control;
			this.label4.Location = new System.Drawing.Point(2, 0);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(137, 31);
			this.label4.TabIndex = 2;
			this.label4.Text = "CHI TIẾT";
			this.label4.Click += new System.EventHandler(this.label4_Click);
			// 
			// btnQuanLy
			// 
			this.btnQuanLy.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnQuanLy.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.btnQuanLy.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnQuanLy.ForeColor = System.Drawing.SystemColors.Control;
			this.btnQuanLy.Location = new System.Drawing.Point(30, 332);
			this.btnQuanLy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnQuanLy.Name = "btnQuanLy";
			this.btnQuanLy.Size = new System.Drawing.Size(254, 50);
			this.btnQuanLy.TabIndex = 4;
			this.btnQuanLy.Text = "Quản lý";
			this.btnQuanLy.UseVisualStyleBackColor = false;
			this.btnQuanLy.Click += new System.EventHandler(this.btnQuanLy_Click);
			// 
			// picHinh
			// 
			this.picHinh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picHinh.Location = new System.Drawing.Point(30, 67);
			this.picHinh.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.picHinh.Name = "picHinh";
			this.picHinh.Size = new System.Drawing.Size(255, 238);
			this.picHinh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picHinh.TabIndex = 3;
			this.picHinh.TabStop = false;
			// 
			// txtSL
			// 
			this.txtSL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.txtSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtSL.Location = new System.Drawing.Point(586, 331);
			this.txtSL.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.txtSL.Name = "txtSL";
			this.txtSL.ReadOnly = true;
			this.txtSL.Size = new System.Drawing.Size(257, 35);
			this.txtSL.TabIndex = 1;
			// 
			// txtMaSP
			// 
			this.txtMaSP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.txtMaSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMaSP.Location = new System.Drawing.Point(586, 56);
			this.txtMaSP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.txtMaSP.Name = "txtMaSP";
			this.txtMaSP.ReadOnly = true;
			this.txtMaSP.Size = new System.Drawing.Size(257, 35);
			this.txtMaSP.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(472, 132);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(94, 29);
			this.label1.TabIndex = 0;
			this.label1.Text = "Tên SP";
			// 
			// label12
			// 
			this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label12.Location = new System.Drawing.Point(456, 333);
			this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(109, 29);
			this.label12.TabIndex = 0;
			this.label12.Text = "Số lượng";
			// 
			// label9
			// 
			this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(479, 58);
			this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(84, 29);
			this.label9.TabIndex = 0;
			this.label9.Text = "Mã SP";
			// 
			// txtKM
			// 
			this.txtKM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtKM.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtKM.Location = new System.Drawing.Point(1047, 265);
			this.txtKM.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.txtKM.Name = "txtKM";
			this.txtKM.ReadOnly = true;
			this.txtKM.Size = new System.Drawing.Size(220, 35);
			this.txtKM.TabIndex = 1;
			// 
			// txtTenSP
			// 
			this.txtTenSP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.txtTenSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTenSP.Location = new System.Drawing.Point(586, 128);
			this.txtTenSP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.txtTenSP.Name = "txtTenSP";
			this.txtTenSP.ReadOnly = true;
			this.txtTenSP.Size = new System.Drawing.Size(257, 35);
			this.txtTenSP.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(411, 270);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(160, 29);
			this.label3.TabIndex = 0;
			this.label3.Text = "Nhà cung cấp";
			// 
			// txtNCC
			// 
			this.txtNCC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.txtNCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNCC.Location = new System.Drawing.Point(586, 265);
			this.txtNCC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.txtNCC.Name = "txtNCC";
			this.txtNCC.ReadOnly = true;
			this.txtNCC.Size = new System.Drawing.Size(257, 35);
			this.txtNCC.TabIndex = 1;
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(949, 61);
			this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(88, 29);
			this.label7.TabIndex = 0;
			this.label7.Text = "Giá SP";
			this.label7.Click += new System.EventHandler(this.label7_Click);
			// 
			// txtLoaiSP
			// 
			this.txtLoaiSP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.txtLoaiSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtLoaiSP.Location = new System.Drawing.Point(586, 197);
			this.txtLoaiSP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.txtLoaiSP.Name = "txtLoaiSP";
			this.txtLoaiSP.ReadOnly = true;
			this.txtLoaiSP.Size = new System.Drawing.Size(257, 35);
			this.txtLoaiSP.TabIndex = 1;
			// 
			// txtGiaGoc
			// 
			this.txtGiaGoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtGiaGoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtGiaGoc.Location = new System.Drawing.Point(1047, 128);
			this.txtGiaGoc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.txtGiaGoc.Name = "txtGiaGoc";
			this.txtGiaGoc.ReadOnly = true;
			this.txtGiaGoc.Size = new System.Drawing.Size(220, 35);
			this.txtGiaGoc.TabIndex = 1;
			// 
			// txtDVT
			// 
			this.txtDVT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDVT.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDVT.Location = new System.Drawing.Point(1047, 197);
			this.txtDVT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.txtDVT.Name = "txtDVT";
			this.txtDVT.ReadOnly = true;
			this.txtDVT.Size = new System.Drawing.Size(220, 35);
			this.txtDVT.TabIndex = 1;
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(467, 204);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(97, 29);
			this.label5.TabIndex = 0;
			this.label5.Text = "Loại SP";
			// 
			// txtGiaSP
			// 
			this.txtGiaSP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtGiaSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtGiaSP.Location = new System.Drawing.Point(1047, 58);
			this.txtGiaSP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.txtGiaSP.Name = "txtGiaSP";
			this.txtGiaSP.ReadOnly = true;
			this.txtGiaSP.Size = new System.Drawing.Size(220, 35);
			this.txtGiaSP.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(942, 132);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 29);
			this.label2.TabIndex = 0;
			this.label2.Text = "Giá gốc";
			// 
			// label11
			// 
			this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.Location = new System.Drawing.Point(902, 265);
			this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(138, 29);
			this.label11.TabIndex = 0;
			this.label11.Text = "Khuyến mãi";
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(913, 199);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(124, 29);
			this.label6.TabIndex = 0;
			this.label6.Text = "Đơn vị tính";
			// 
			// TTSanPham
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1336, 815);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.dgvTT);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "TTSanPham";
			this.Text = "TTSanPham";
			this.Load += new System.EventHandler(this.TTSanPham_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvTT)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picQRCode)).EndInit();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picHinh)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTT;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNCC;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtKM;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDVT;
        private System.Windows.Forms.TextBox txtGiaSP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picHinh;
        private System.Windows.Forms.TextBox txtLoaiSP;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnQuanLy;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox txtGiaGoc;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2PictureBox picQRCode;
    }
}