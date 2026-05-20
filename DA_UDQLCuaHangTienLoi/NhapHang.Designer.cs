namespace DA_UDQLCuaHangTienLoi
{
    partial class NhapHang
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
            this.dgvTTNhapHang = new System.Windows.Forms.DataGridView();
            this.MaNhaphang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaKhoHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TGNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnThemKho = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.dgvTTChiTiet = new System.Windows.Forms.DataGridView();
            this.MaNH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.donGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnSPS = new System.Windows.Forms.Panel();
            this.cboLoaiSP = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtpHanSD = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpNgaySX = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoaChiTiet = new System.Windows.Forms.Button();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.txtSL = new System.Windows.Forms.TextBox();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.txtNCC = new System.Windows.Forms.TextBox();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMaNH = new System.Windows.Forms.TextBox();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTTNhapHang)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTTChiTiet)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvTTNhapHang);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 480);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1082, 223);
            this.panel1.TabIndex = 0;
            // 
            // dgvTTNhapHang
            // 
            this.dgvTTNhapHang.AllowUserToResizeColumns = false;
            this.dgvTTNhapHang.AllowUserToResizeRows = false;
            this.dgvTTNhapHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTTNhapHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTTNhapHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaNhaphang,
            this.MaNhanVien,
            this.MaKhoHang,
            this.TGNhap,
            this.colTongTien,
            this.TrangThai});
            this.dgvTTNhapHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTTNhapHang.Location = new System.Drawing.Point(0, 0);
            this.dgvTTNhapHang.Name = "dgvTTNhapHang";
            this.dgvTTNhapHang.ReadOnly = true;
            this.dgvTTNhapHang.RowHeadersWidth = 51;
            this.dgvTTNhapHang.RowTemplate.Height = 24;
            this.dgvTTNhapHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTTNhapHang.Size = new System.Drawing.Size(882, 223);
            this.dgvTTNhapHang.TabIndex = 2;
            this.dgvTTNhapHang.Click += new System.EventHandler(this.dgvTTNhapHang_Click);
            // 
            // MaNhaphang
            // 
            this.MaNhaphang.DataPropertyName = "MaNH";
            this.MaNhaphang.HeaderText = "Mã NH";
            this.MaNhaphang.MinimumWidth = 6;
            this.MaNhaphang.Name = "MaNhaphang";
            this.MaNhaphang.ReadOnly = true;
            // 
            // MaNhanVien
            // 
            this.MaNhanVien.HeaderText = "Nhân viên";
            this.MaNhanVien.MinimumWidth = 6;
            this.MaNhanVien.Name = "MaNhanVien";
            this.MaNhanVien.ReadOnly = true;
            // 
            // MaKhoHang
            // 
            this.MaKhoHang.HeaderText = "Kho";
            this.MaKhoHang.MinimumWidth = 6;
            this.MaKhoHang.Name = "MaKhoHang";
            this.MaKhoHang.ReadOnly = true;
            // 
            // TGNhap
            // 
            this.TGNhap.HeaderText = "TG Nhập";
            this.TGNhap.MinimumWidth = 6;
            this.TGNhap.Name = "TGNhap";
            this.TGNhap.ReadOnly = true;
            // 
            // colTongTien
            // 
            this.colTongTien.HeaderText = "Tổng tiền";
            this.colTongTien.MinimumWidth = 6;
            this.colTongTien.Name = "colTongTien";
            this.colTongTien.ReadOnly = true;
            // 
            // TrangThai
            // 
            this.TrangThai.HeaderText = "Trạng thái";
            this.TrangThai.MinimumWidth = 6;
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.ReadOnly = true;
            this.TrangThai.Visible = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnThemKho);
            this.panel4.Controls.Add(this.btnXoa);
            this.panel4.Controls.Add(this.btnHuy);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(882, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 223);
            this.panel4.TabIndex = 1;
            // 
            // btnThemKho
            // 
            this.btnThemKho.BackColor = System.Drawing.Color.Lime;
            this.btnThemKho.Location = new System.Drawing.Point(53, 6);
            this.btnThemKho.Name = "btnThemKho";
            this.btnThemKho.Size = new System.Drawing.Size(108, 63);
            this.btnThemKho.TabIndex = 6;
            this.btnThemKho.Text = "Thêm vào kho";
            this.btnThemKho.UseVisualStyleBackColor = false;
            this.btnThemKho.Click += new System.EventHandler(this.btnThemKho_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.Crimson;
            this.btnXoa.ForeColor = System.Drawing.SystemColors.Control;
            this.btnXoa.Location = new System.Drawing.Point(53, 79);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(108, 63);
            this.btnXoa.TabIndex = 6;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnHuy.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnHuy.Location = new System.Drawing.Point(53, 148);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(108, 63);
            this.btnHuy.TabIndex = 6;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // dgvTTChiTiet
            // 
            this.dgvTTChiTiet.AllowUserToResizeColumns = false;
            this.dgvTTChiTiet.AllowUserToResizeRows = false;
            this.dgvTTChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTTChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTTChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaNH,
            this.MaSP,
            this.tenSP,
            this.SoLuong,
            this.donGia,
            this.thanhTien});
            this.dgvTTChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTTChiTiet.Location = new System.Drawing.Point(0, 0);
            this.dgvTTChiTiet.Name = "dgvTTChiTiet";
            this.dgvTTChiTiet.ReadOnly = true;
            this.dgvTTChiTiet.RowHeadersWidth = 51;
            this.dgvTTChiTiet.RowTemplate.Height = 24;
            this.dgvTTChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTTChiTiet.Size = new System.Drawing.Size(785, 198);
            this.dgvTTChiTiet.TabIndex = 0;
            // 
            // MaNH
            // 
            this.MaNH.HeaderText = "Mã nhập";
            this.MaNH.MinimumWidth = 6;
            this.MaNH.Name = "MaNH";
            this.MaNH.ReadOnly = true;
            // 
            // MaSP
            // 
            this.MaSP.HeaderText = "Mã SP";
            this.MaSP.MinimumWidth = 6;
            this.MaSP.Name = "MaSP";
            this.MaSP.ReadOnly = true;
            // 
            // tenSP
            // 
            this.tenSP.HeaderText = "Tên SP";
            this.tenSP.MinimumWidth = 6;
            this.tenSP.Name = "tenSP";
            this.tenSP.ReadOnly = true;
            // 
            // SoLuong
            // 
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.MinimumWidth = 6;
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.ReadOnly = true;
            // 
            // donGia
            // 
            this.donGia.HeaderText = "Đơn giá";
            this.donGia.MinimumWidth = 6;
            this.donGia.Name = "donGia";
            this.donGia.ReadOnly = true;
            // 
            // thanhTien
            // 
            this.thanhTien.HeaderText = "Thành tiền";
            this.thanhTien.MinimumWidth = 6;
            this.thanhTien.Name = "thanhTien";
            this.thanhTien.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pnSPS);
            this.panel2.Controls.Add(this.cboLoaiSP);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(330, 480);
            this.panel2.TabIndex = 0;
            // 
            // pnSPS
            // 
            this.pnSPS.AutoScroll = true;
            this.pnSPS.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.pnSPS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnSPS.Location = new System.Drawing.Point(3, 33);
            this.pnSPS.Name = "pnSPS";
            this.pnSPS.Size = new System.Drawing.Size(285, 440);
            this.pnSPS.TabIndex = 1;
            this.pnSPS.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // cboLoaiSP
            // 
            this.cboLoaiSP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiSP.FormattingEnabled = true;
            this.cboLoaiSP.Location = new System.Drawing.Point(3, 3);
            this.cboLoaiSP.Name = "cboLoaiSP";
            this.cboLoaiSP.Size = new System.Drawing.Size(285, 24);
            this.cboLoaiSP.TabIndex = 0;
            this.cboLoaiSP.SelectedIndexChanged += new System.EventHandler(this.cboLoaiSP_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dtpHanSD);
            this.panel3.Controls.Add(this.dtpNgaySX);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.btnThem);
            this.panel3.Controls.Add(this.btnLamMoi);
            this.panel3.Controls.Add(this.btnXoaChiTiet);
            this.panel3.Controls.Add(this.btnXacNhan);
            this.panel3.Controls.Add(this.txtSL);
            this.panel3.Controls.Add(this.txtDonGia);
            this.panel3.Controls.Add(this.txtNCC);
            this.panel3.Controls.Add(this.txtMaSP);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.txtMaNH);
            this.panel3.Controls.Add(this.txtTenSP);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(295, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(787, 480);
            this.panel3.TabIndex = 0;
            // 
            // dtpHanSD
            // 
            this.dtpHanSD.Checked = true;
            this.dtpHanSD.FillColor = System.Drawing.Color.White;
            this.dtpHanSD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHanSD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHanSD.Location = new System.Drawing.Point(616, 176);
            this.dtpHanSD.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpHanSD.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpHanSD.Name = "dtpHanSD";
            this.dtpHanSD.Size = new System.Drawing.Size(158, 36);
            this.dtpHanSD.TabIndex = 9;
            this.dtpHanSD.Value = new System.DateTime(2026, 5, 9, 13, 11, 41, 507);
            // 
            // dtpNgaySX
            // 
            this.dtpNgaySX.Checked = true;
            this.dtpNgaySX.FillColor = System.Drawing.Color.White;
            this.dtpNgaySX.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.dtpNgaySX.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaySX.Location = new System.Drawing.Point(616, 93);
            this.dtpNgaySX.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgaySX.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgaySX.Name = "dtpNgaySX";
            this.dtpNgaySX.Size = new System.Drawing.Size(158, 36);
            this.dtpNgaySX.TabIndex = 9;
            this.dtpNgaySX.Value = new System.DateTime(2026, 5, 9, 13, 12, 40, 170);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dgvTTChiTiet);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 280);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(785, 198);
            this.panel5.TabIndex = 8;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(195, 209);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(117, 51);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm đơn";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.Aqua;
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.Location = new System.Drawing.Point(60, 208);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(117, 53);
            this.btnLamMoi.TabIndex = 6;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXoaChiTiet
            // 
            this.btnXoaChiTiet.BackColor = System.Drawing.Color.Crimson;
            this.btnXoaChiTiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaChiTiet.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnXoaChiTiet.Location = new System.Drawing.Point(352, 209);
            this.btnXoaChiTiet.Name = "btnXoaChiTiet";
            this.btnXoaChiTiet.Size = new System.Drawing.Size(117, 53);
            this.btnXoaChiTiet.TabIndex = 6;
            this.btnXoaChiTiet.Text = "Xóa";
            this.btnXoaChiTiet.UseVisualStyleBackColor = false;
            this.btnXoaChiTiet.Click += new System.EventHandler(this.btnXoaChiTiet_Click);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BackColor = System.Drawing.Color.Lime;
            this.btnXacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.Location = new System.Drawing.Point(487, 209);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(117, 53);
            this.btnXacNhan.TabIndex = 6;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // txtSL
            // 
            this.txtSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSL.Location = new System.Drawing.Point(395, 154);
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(205, 27);
            this.txtSL.TabIndex = 3;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDonGia.Location = new System.Drawing.Point(395, 113);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.ReadOnly = true;
            this.txtDonGia.Size = new System.Drawing.Size(206, 27);
            this.txtDonGia.TabIndex = 3;
            // 
            // txtNCC
            // 
            this.txtNCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNCC.Location = new System.Drawing.Point(398, 65);
            this.txtNCC.Name = "txtNCC";
            this.txtNCC.ReadOnly = true;
            this.txtNCC.Size = new System.Drawing.Size(206, 27);
            this.txtNCC.TabIndex = 3;
            // 
            // txtMaSP
            // 
            this.txtMaSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaSP.Location = new System.Drawing.Point(84, 155);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.ReadOnly = true;
            this.txtMaSP.Size = new System.Drawing.Size(206, 27);
            this.txtMaSP.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(357, 158);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 20);
            this.label8.TabIndex = 2;
            this.label8.Text = "SL";
            // 
            // txtMaNH
            // 
            this.txtMaNH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNH.Location = new System.Drawing.Point(84, 66);
            this.txtMaNH.Name = "txtMaNH";
            this.txtMaNH.ReadOnly = true;
            this.txtMaNH.Size = new System.Drawing.Size(206, 27);
            this.txtMaNH.TabIndex = 3;
            // 
            // txtTenSP
            // 
            this.txtTenSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenSP.Location = new System.Drawing.Point(84, 110);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.ReadOnly = true;
            this.txtTenSP.Size = new System.Drawing.Size(206, 27);
            this.txtTenSP.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(325, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "Đơn giá";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(611, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Hạn SD";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(611, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Ngày SX";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(314, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tên NCC";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(5, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 20);
            this.label9.TabIndex = 2;
            this.label9.Text = "Mã NH";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã SP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên SP";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.label1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(785, 47);
            this.panel6.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(353, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thông tin";
            // 
            // NhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1082, 703);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(1100, 750);
            this.MinimumSize = new System.Drawing.Size(1100, 750);
            this.Name = "NhapHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NhapHang";
            this.Load += new System.EventHandler(this.NhapHang_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTTNhapHang)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTTChiTiet)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvTTChiTiet;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel pnSPS;
        private System.Windows.Forms.ComboBox cboLoaiSP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSL;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.TextBox txtNCC;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnThemKho;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvTTNhapHang;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNhaphang;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKhoHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn TGNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private System.Windows.Forms.Button btnXoaChiTiet;
        private System.Windows.Forms.TextBox txtMaNH;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNH;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn donGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn thanhTien;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpHanSD;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgaySX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}