using BUS;
using ET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA_UDQLCuaHangTienLoi
{

    public partial class NhapHang : Form
    {
        public static string mail;
        public static string maNV;
        public static string tenNV;
        public NhapHang()
        {
            InitializeComponent();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
        BUS_TK tk = new BUS_TK();
        BUS_SP sp = new BUS_SP();
        BUS_LSP lsp = new BUS_LSP();
        BUS_SPNH spnh = new BUS_SPNH();
        BUS_KHO kho = new BUS_KHO();
        BUS_NHAPHANG nh = new BUS_NHAPHANG();
        private void NhapHang_Load(object sender, EventArgs e)
        {
            load();
        }
        public void load()
        {
            // 1. Sửa lỗi tiềm ẩn của biến mail (phải dùng IsNullOrEmpty)
            if (!string.IsNullOrEmpty(mail))
            {
                DataTable dt = tk.timNVOnl(mail);
                // Kiểm tra dt có dữ liệu không trước khi lấy Rows[0]
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    maNV = dr["MaNV"].ToString();
                    tenNV = dr["HoTenNV"].ToString();
                }
            }

            // 2. Load danh sách Nhập Hàng
            dgvTTNhapHang.Rows.Clear();
            DataTable dtnh = nh.layTT();
            if (dtnh != null) // Khiên bảo vệ DAL trả về null
            {
                foreach (DataRow dr in dtnh.Rows)
                {
                    if (dr["TrangThai"].ToString() == "Chưa xác nhận")
                    {
                        dgvTTNhapHang.Rows.Add(dr["MaNH"].ToString(), dr["MaNV"].ToString(),
                            dr["MaKhoHang"].ToString(), dr["ThoiGianNhap"].ToString(), dr["TongTien"].ToString(), dr["TrangThai"].ToString());
                    }
                }
            }

            // 3. Load chi tiết của dòng đầu tiên (ĐÃ ĐƯỢC GỘP VÀO TRONG IF)
            dgvTTChiTiet.Rows.Clear(); // Nhớ Clear bảng chi tiết trước khi thêm

            // Kiểm tra: Có dòng nào không? VÀ Giá trị ô đầu tiên có bị null không?
            if (dgvTTNhapHang.Rows.Count > 0 && dgvTTNhapHang.Rows[0].Cells[0].Value != null)
            {
                // Lấy ra 1 lần gán vào biến để dùng chung cho sạch code
                string firstMaNH = dgvTTNhapHang.Rows[0].Cells[0].Value.ToString().Trim();
                txtMaNH.Text = firstMaNH;

                DataTable dtChiTiet = spnh.timChiTietTheoMa(firstMaNH);
                if (dtChiTiet != null)
                {
                    foreach (DataRow dr in dtChiTiet.Rows)
                    {
                        dgvTTChiTiet.Rows.Add(dr["MaNH"].ToString(), dr["MaSP"].ToString(),
                            spnh.timTenSPTheoMa(dr["MaSP"].ToString()), dr["SoLuongNhap"].ToString(),
                            dr["GiaNhap"].ToString(), dr["ThanhTien"].ToString());
                    }
                }
            }

            // 4. Load ComboBox Loại SP
            DataTable dtLSP = lsp.layDSLSP();
            if (dtLSP != null)
            {
                cboLoaiSP.DisplayMember = "TenLoaiSP";
                cboLoaiSP.ValueMember = "MaLoaiSP";
                cboLoaiSP.DataSource = dtLSP;
            }
        }

        
        private void cboLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            //tìm và lưu data sp theo mã
            DataTable dt = sp.timSPTheoMaLoai(cboLoaiSP.SelectedValue.ToString());

            pnSPS.Controls.Clear();

            int toaDoY = 0;

            //tạo các textbox theo lượng sp có trong data
            foreach (DataRow dr in dt.Rows)
            {
                TextBox SP = new TextBox();

                SP.Name = dr["MaSP"].ToString();
                SP.Text = dr["TenSP"].ToString();

                SP.Width = 300;

                SP.Location = new Point(0, toaDoY);

                toaDoY += 20;

                SP.Click += suKienClickSP;

                SP.ReadOnly = true;

                pnSPS.Controls.Add(SP);
            }
        }

        //Gán sự kiện cllick vào textbox đc tạo
        private void suKienClickSP(object sender, EventArgs args)
        {
            TextBox txt = sender as TextBox;

            DataTable dt = sp.findSPMa(txt.Name);

            foreach (DataRow dr in dt.Rows)
            {
                txtTenSP.Text = dr["TenSP"].ToString();
                txtMaSP.Text = dr["MaSP"].ToString();
                txtDonGia.Text = dr["DonGia"].ToString();
                txtNCC.Text = dr["MaNCC"].ToString();
            }
        }


        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu thêm vào DB (SQL tự động lo cột Thành Tiền)
            int soLuong = Convert.ToInt32(txtSL.Text);
            int donGia = Convert.ToInt32(tachDonGia());

            ET_SP_NH et = new ET_SP_NH(txtMaNH.Text, txtMaSP.Text, soLuong, donGia, dtpNgaySX.Value, dtpHanSD.Value);

            // 2. Đẩy xuống Database
            if (spnh.them(et))
            {
                MessageBox.Show("Thành công");

                // 3. XÓA BẢNG VÀ GỌI LẠI DỮ LIỆU TỪ DATABASE (Để lấy Thành Tiền tự động)
                dgvTTChiTiet.Rows.Clear();
                DataTable dtChiTiet = spnh.timChiTietTheoMa(txtMaNH.Text);

                if (dtChiTiet != null)
                {
                    foreach (DataRow dr in dtChiTiet.Rows)
                    {
                        // Gọi thẳng Thành Tiền từ dr["ThanhTien"] do SQL tính toán đẩy lên
                        dgvTTChiTiet.Rows.Add(
                            dr["MaNH"].ToString(),
                            dr["MaSP"].ToString(),
                            spnh.timTenSPTheoMa(dr["MaSP"].ToString()),
                            dr["SoLuongNhap"].ToString(),
                            dr["GiaNhap"].ToString(),
                            dr["ThanhTien"].ToString()
                        );
                    }
                }

                // 4. Tính lại Tổng Tiền dựa trên dữ liệu mới nhất vừa được SQL trả lên
                capNhatTongTien(txtMaNH.Text);
            }

            // 5. Làm mới lại danh sách Phiếu Nhập (Để thấy Tổng Tiền và Trạng Thái cập nhật)
            dgvTTNhapHang.Rows.Clear();
            DataTable dtnh = nh.layTT();
            if (dtnh != null)
            {
                foreach (DataRow dr in dtnh.Rows)
                {
                    if (dr["TrangThai"].ToString() == "Chưa xác nhận")
                    {
                        dgvTTNhapHang.Rows.Add(
                            dr["MaNH"].ToString(),
                            dr["MaNV"].ToString(),
                            dr["MaKhoHang"].ToString(),
                            dr["ThoiGianNhap"].ToString(),
                            dr["TongTien"].ToString(),
                            dr["TrangThai"].ToString()
                        );
                    }
                }
            }
        }
        public void capNhatTongTien(string ma)
        {
            int tt = 0;

            // Duyệt qua đúng bảng CHI TIẾT
            for (int i = 0; i < dgvTTChiTiet.Rows.Count; i++)
            {
                if (dgvTTChiTiet.Rows[i].IsNewRow) continue;

                var cellValue = dgvTTChiTiet.Rows[i].Cells[5].Value; // Lấy Thành Tiền

                if (cellValue != null)
                {
                    // Bỏ dấu phẩy/chấm nếu có trong chuỗi định dạng
                    string giaTri = cellValue.ToString().Split(',')[0].Split('.')[0];

                    if (int.TryParse(giaTri, out int tien))
                    {
                        tt += tien;
                    }
                }
            }

            // Đẩy Tổng Tiền cập nhật xuống Database
            nh.capNhatTongTien(ma, tt);
        }

        public string tachDonGia()
        {
            if (txtDonGia.Text.Split(',').Length == 2)
            {
                return txtDonGia.Text.Split(',')[0];
            }
            return txtDonGia.Text.Split('.')[0];
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            taoNhapHang frm = new taoNhapHang();
            taoNhapHang.maNV = maNV;
            frm.ShowDialog();
            load();
        }

        //load lại app  
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            load();
        }

        //Mã thay đổi thì dgv chi tiết thay đổi
        private void cboMaNH_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvTTChiTiet.Rows.Clear();

            DataTable dt = spnh.timChiTietTheoMa(txtMaNH.Text);

            foreach (DataRow dr in dt.Rows)
            {
                dgvTTChiTiet.Rows.Add(dr["MaNH"].ToString(), dr["MaSP"].ToString(), dr["TenSP"].ToString(), dr["SoLuongNhap"].ToString(), dr["GiaNhap"].ToString());
            }
        }
        private void btnThemKho_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem người dùng có chọn đúng dòng có dữ liệu không
            if (dgvTTNhapHang.CurrentRow == null || dgvTTNhapHang.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn một phiếu nhập hợp lệ!");
                return;
            }

            int dong = dgvTTNhapHang.CurrentCell.RowIndex;

            // 2. Chặn lỗi NULL và khoảng trắng tàng hình
            var cellValue = dgvTTNhapHang.Rows[dong].Cells[0].Value;
            if (cellValue == null) return;

            string maNH = cellValue.ToString().Trim();

            if (nh.duaSPVaoKho(maNH))
            {
                MessageBox.Show("Đã nhập kho thành công!");
                this.Close(); // Hoặc bạn có thể gọi load() thay vì Close() nếu muốn nhập tiếp
            }
            else
            {
                MessageBox.Show("Thêm thất bại mã: " + maNH);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem người dùng có chọn đúng dòng có dữ liệu không
            if (dgvTTNhapHang.CurrentRow == null || dgvTTNhapHang.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn một phiếu nhập hợp lệ!");
                return;
            }

            int dong = dgvTTNhapHang.CurrentCell.RowIndex;

            string maNH = dgvTTNhapHang.Rows[dong].Cells[0].Value.ToString();

            if (nh.xoaNH(maNH))
            {
                MessageBox.Show("Đã xóa đơn thành công!");
                load();
            }
            else
            {
                MessageBox.Show("Thêm thất bại mã: " + maNH);
            }
        }

        //Xóa chi tiết SP
        private void btnXoaChiTiet_Click(object sender, EventArgs e)
        {
            int dong = dgvTTChiTiet.CurrentCell.RowIndex;
            string ma = dgvTTChiTiet.Rows[dong].Cells[1].Value.ToString();

            if (spnh.xoa(ma))
            {
                MessageBox.Show("Xóa thành công");
                load();
            }
            else
            {
                MessageBox.Show("Thất bại");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {            

        }

        
        private void dgvTTNhapHang_Click(object sender, EventArgs e)
        {
            // 1. Khiên bảo vệ: Tránh click vào vùng trống hoặc dòng mới tự sinh
            if (dgvTTNhapHang.CurrentRow == null || dgvTTNhapHang.CurrentRow.IsNewRow) return;

            // 2. Lấy mã Nhập Hàng ở đúng dòng được click
            int dong = dgvTTNhapHang.CurrentCell.RowIndex;
            string maNH = dgvTTNhapHang.Rows[dong].Cells[0].Value.ToString().Trim();

            txtMaNH.Text = maNH;

            // 3. Xóa bảng cũ và load chi tiết đúng theo mã đó
            dgvTTChiTiet.Rows.Clear();
            DataTable dtChiTiet = spnh.timChiTietTheoMa(maNH); // Truyền maNH vào đây

            if (dtChiTiet != null)
            {
                foreach (DataRow dr in dtChiTiet.Rows)
                {
                    dgvTTChiTiet.Rows.Add(
                        dr["MaNH"].ToString(),
                        dr["MaSP"].ToString(),
                        spnh.timTenSPTheoMa(dr["MaSP"].ToString()),
                        dr["SoLuongNhap"].ToString(),
                        dr["GiaNhap"].ToString(),
                        dr["ThanhTien"].ToString()
                    );
                }
            }
        }
    }
}
