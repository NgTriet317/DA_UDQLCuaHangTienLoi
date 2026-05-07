using ET;
using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA_UDQLCuaHangTienLoi
{
    public partial class banHang : Form
    {
        public banHang()
        {
            InitializeComponent();
            SetDoubleBuffered(flowLayoutPanelSP);
        }

        public static void SetDoubleBuffered(Control control)
        {
            // Sử dụng Reflection để bật DoubleBuffered
            typeof(Control).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, control, new object[] { true });
        }
        private Form current_form_child;


        BUS_SP sp = new BUS_SP();
        BUS_LSP lsp = new BUS_LSP();
        private void banHang_Load(object sender, EventArgs e)
        {
            //Hien thi thong tin khi app vua bat
            LoadDanhSachSanPham();
            cbLSP.DataSource = lsp.layDSLSP();
            cbLSP.DisplayMember = "TenLoaiSP";
            cbLSP.ValueMember = "MaLoaiSP";
            cbLSP.SelectedIndex = -1;

        }
        private void LoadDanhSachSanPham()
        {
            // Xóa các thẻ cũ nếu có để load lại từ đầu
            flowLayoutPanelSP.Controls.Clear();
            try
            {
                BUS_SP sp = new BUS_SP();

                DataTable dt = sp.layDSSP();


                // Duyệt qua từng dòng dữ liệu trong CSDL
                foreach (DataRow row in dt.Rows)
                {
                    string maSP = row["MaSP"].ToString();
                    string tenSP = row["TenSP"].ToString();
                    decimal gia = Convert.ToDecimal(row["DonGia"]);
                    Image img = null;

                    string tenFileAnh = row["Hinh"].ToString();

                    string duongDanDayDu = Path.Combine(Application.StartupPath, "AnhSanPham", tenFileAnh);
                    // Xử lý hình ảnh từ CSDL (Giả sử bạn lưu dạng mảng byte - varbinary)
                    //string thuMucChuaAnh = @"D:\DA_UDQLCuaHangTienLoi\AnhSanPham\";

                    //string duongDanDayDu = Path.Combine(thuMucChuaAnh, tenFileAnh);

                    if (File.Exists(duongDanDayDu))
                    {
                        img = Image.FromFile(duongDanDayDu);
                    }

                    // 1. Tạo một thẻ sản phẩm mới (truyền cả MaSP vào để ẩn đi)
                    theSanPham card = new theSanPham(maSP, tenSP, gia, img);

                    // Thêm viền (tùy chọn cho giống ảnh)
                    card.BorderStyle = BorderStyle.FixedSingle;
                    card.Margin = new Padding(10); // Tạo khoảng cách giữa các thẻ

                    card.SanPhamClicked += Card_Clicked;
                    // 2. Thêm thẻ vào FlowLayoutPanel
                    flowLayoutPanelSP.Controls.Add(card);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải sản phẩm: " + ex.Message);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Card_Clicked(object sender, EventArgs e)
        {
            // Xác định xem thẻ nào vừa bị click
            theSanPham clickedCard = sender as theSanPham;
            if (clickedCard == null) return;

            string ma = clickedCard.MaSP;
            string ten = clickedCard.TenSP;
            decimal gia = clickedCard.DonGia;

            bool daCoTrongHoaDon = false;

            // 1. Kiểm tra xem sản phẩm này đã có trong hóa đơn chưa
            foreach (DataGridViewRow row in dgvHoaDon.Rows)
            {
                if (row.IsNewRow) continue; // Bỏ qua dòng trống mặc định cuối cùng

                // Nếu mã sản phẩm đã tồn tại trong DataGridView
                if (row.Cells["colMaSP"].Value?.ToString() == ma)
                {
                    // Tăng số lượng lên 1
                    int soLuongHienTai = Convert.ToInt32(row.Cells["colSL"].Value);
                    int soLuongMoi = soLuongHienTai + 1;

                    row.Cells["colSL"].Value = soLuongMoi;

                    // Tính lại tổng tiền của dòng đó (Số lượng * Đơn giá)
                    row.Cells["colTong"].Value = soLuongMoi * gia;

                    daCoTrongHoaDon = true;
                    break; // Thoát vòng lặp vì đã xử lý xong
                }
            }

            // 2. Nếu sản phẩm chưa có trong hóa đơn, thêm dòng mới
            if (!daCoTrongHoaDon)
            {
                // Thứ tự truyền vào phải khớp với thứ tự các cột trong DataGridView của bạn
                // Ví dụ: Tên, Đơn Giá, Khuyến Mãi (0), Số lượng (1), Tổng tiền, Mã SP (ẩn)
                dgvHoaDon.Rows.Add(ten, gia, 0, 1, gia, ma);
            }

            // 3. Cập nhật dòng chữ "Tổng hóa đơn: xxx đ" ở dưới cùng
            TinhTongHoaDon();
        }


        // Hàm phụ để cộng dồn tất cả các dòng tiền lại
        private void TinhTongHoaDon()
        {
            int tongTien = 0;
            foreach (DataGridViewRow row in dgvHoaDon.Rows)
            {
                //if (row.IsNewRow) continue;
                //tongTien += Convert.ToDecimal(row.Cells["colTong"].Value);
                if (row.Cells["colTong"].Value != null)
                {
                    tongTien += Convert.ToInt32(row.Cells["colTong"].Value);
                }
            }

            // lblTongTien là cái chữ màu xanh lá cây trong thiết kế của bạn
            lblMoney.Text = (Convert.ToDecimal(tongTien)).ToString();
        }

        private void btnApDung_Click(object sender, EventArgs e)
        {
            flowLayoutPanelSP.Controls.Clear();
            string name = txtNameSP.Text;
            BUS_SP sp = new BUS_SP();
            DataTable dt = sp.findSP(name);

            foreach (DataRow row in dt.Rows)
            {
                string maSP = row["MaSP"].ToString();
                string tenSP = row["TenSP"].ToString();
                decimal gia = Convert.ToDecimal(row["DonGia"]);
                Image img = null;

                string tenFileAnh = row["Hinh"].ToString();

                string duongDanDayDu = Path.Combine(Application.StartupPath, "AnhSanPham", tenFileAnh);
                // Xử lý hình ảnh từ CSDL (Giả sử bạn lưu dạng mảng byte - varbinary)
                //string thuMucChuaAnh = @"D:\DA_UDQLCuaHangTienLoi\AnhSanPham\";

                //string duongDanDayDu = Path.Combine(thuMucChuaAnh, tenFileAnh);

                if (File.Exists(duongDanDayDu))
                {
                    img = Image.FromFile(duongDanDayDu);
                }

                // 1. Tạo một thẻ sản phẩm mới (truyền cả MaSP vào để ẩn đi)
                theSanPham card = new theSanPham(maSP, tenSP, gia, img);

                // Thêm viền (tùy chọn cho giống ảnh)
                card.BorderStyle = BorderStyle.FixedSingle;
                card.Margin = new Padding(10); // Tạo khoảng cách giữa các thẻ

                card.SanPhamClicked += Card_Clicked;
                // 2. Thêm thẻ vào FlowLayoutPanel
                flowLayoutPanelSP.Controls.Add(card);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadDanhSachSanPham();
            cbLSP.SelectedIndex = -1;
            txtNameSP.Clear();

        }

        private void cbLSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            flowLayoutPanelSP.Controls.Clear();
            DataTable dt = sp.layDSSP();
            if (cbLSP.SelectedIndex != -1)
            {
                string name = cbLSP.SelectedValue.ToString();
                dt = lsp.findLSP(name);
            }


            foreach (DataRow row in dt.Rows)
            {
                string maSP = row["MaSP"].ToString();
                string tenSP = row["TenSP"].ToString();
                decimal gia = Convert.ToDecimal(row["DonGia"]);
                Image img = null;

                string tenFileAnh = row["Hinh"].ToString();

                // Xử lý hình ảnh từ CSDL (Giả sử bạn lưu dạng mảng byte - varbinary)
                string duongDanDayDu = Path.Combine(Application.StartupPath, "AnhSanPham", tenFileAnh);

                //string thuMucChuaAnh = @"D:\DA_UDQLCuaHangTienLoi\AnhSanPham\";

                //string duongDanDayDu = Path.Combine(thuMucChuaAnh, tenFileAnh);

                if (File.Exists(duongDanDayDu))
                {
                    img = Image.FromFile(duongDanDayDu);
                }

                // 1. Tạo một thẻ sản phẩm mới (truyền cả MaSP vào để ẩn đi)
                theSanPham card = new theSanPham(maSP, tenSP, gia, img);

                // Thêm viền (tùy chọn cho giống ảnh)
                card.BorderStyle = BorderStyle.FixedSingle;
                card.Margin = new Padding(10); // Tạo khoảng cách giữa các thẻ

                card.SanPhamClicked += Card_Clicked;
                // 2. Thêm thẻ vào FlowLayoutPanel
                flowLayoutPanelSP.Controls.Add(card);
            }
        }

        private void txtNameSP_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            dgvHoaDon.Rows.Clear();
            txtTraTien.Clear();
            lblMoney.Text = "0đ";
            txtTienThua.Clear();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.Rows.Count < 0)
            {
                MessageBox.Show("Không tìm thấy sản phẩm để tạo hóa đơn");
            }
            else
            {
                try
                {
                    ET_HoaDon et = new ET_HoaDon(DateTime.Now, Convert.ToInt32(lblMoney.Text), Convert.ToInt32(lblMoney.Text), Convert.ToInt32(txtTraTien.Text), Convert.ToInt32(txtTienThua.Text), frmMain.maNV);

                    BUS_HoaDon hd = new BUS_HoaDon();
                    if (hd.ThemHoaDon(et))
                    {
                        string maHDVuaTao = hd.LayMaHoaDonMoiNhat();
                        foreach (DataGridViewRow row in dgvHoaDon.Rows)
                        {
                            if (row.IsNewRow) continue;
                            ET_SPHD etSphd = new ET_SPHD(maHDVuaTao, row.Cells["colMaSP"].Value.ToString(), Convert.ToInt32(row.Cells["colSL"].Value), Convert.ToInt32(row.Cells["colDonGia"].Value));
                            BUS_SPHD sphd = new BUS_SPHD();
                            sphd.ThemChiTietHoaDon(etSphd);
                        }
                        InHoa1Don(maHDVuaTao);
                    }
                    dgvHoaDon.Rows.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thanh toán: " + ex.Message);
                }
            }
        }

        private void InHoa1Don(string maHD)
        {
            InHoaDon frm = new InHoaDon();
            rptXuatHoaDon inHoaDon = new rptXuatHoaDon();

            try
            {
                // 1. Tầng BUS/DAL lấy dữ liệu và TỰ ĐÓNG KẾT NỐI DATABASE (nhờ finally { conn.Close(); })
                BUS_HoaDon hd = new BUS_HoaDon();
                DataTable dtHoaDon = hd.layFullHoaDon(maHD);

                // 2. Bơm dữ liệu vào Report (Report lúc này là vỏ rỗng, xài dataset xsd)
                inHoaDon.SetDataSource(dtHoaDon);

                // 3. Không dùng SetParameterValue để gọi xuống DB nữa!
                // inHoaDon.SetParameterValue("@MaHD", maHD); // BỎ DÒNG NÀY ĐI

                frm.crystalReportViewer1.ReportSource = inHoaDon;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi in hóa đơn: " + ex.Message);
            }
            finally
            {
                // 4. Ngắt connection và dọn rác của riêng Crystal Report
                if (frm.crystalReportViewer1 != null) frm.crystalReportViewer1.ReportSource = null;
                if (inHoaDon != null)
                {
                    inHoaDon.Close();
                    inHoaDon.Dispose();
                }
                if (frm != null) frm.Dispose();
            }
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvHoaDon.Rows[e.RowIndex].IsNewRow) return;

            DataGridViewRow row = dgvHoaDon.Rows[e.RowIndex];

            try
            {
                // Lấy giá trị hiện tại
                decimal gia = Convert.ToDecimal(row.Cells["colDonGia"].Value);
                int soLuongHienTai = Convert.ToInt32(row.Cells["colSL"].Value);
                int soLuongMoi = soLuongHienTai - 1;

                if (soLuongMoi <= 0)
                {
                    // Xóa hẳn dòng khỏi DataGridView
                    dgvHoaDon.Rows.Remove(row);
                }
                else
                {
                    // Cập nhật số lượng và tổng tiền
                    row.Cells["colSL"].Value = soLuongMoi;
                    row.Cells["colTong"].Value = soLuongMoi * gia;
                }

                // Cập nhật lại tổng tiền toàn hóa đơn ở đây (nếu có)
                // CapNhatTongTienChung(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xử lý: " + ex.Message);
            }
            TinhTongHoaDon();
            if (txtTraTien.Text != string.Empty)
            {

                int tienThua = Convert.ToInt32(txtTraTien.Text.ToString()) - Convert.ToInt32(lblMoney.Text.ToString());
                if (tienThua < 0)
                {
                    txtTienThua.Text = "0";
                }
                else
                {
                    txtTienThua.Text = tienThua.ToString();
                }

            }
        }

        
        private void txtTraTien_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Kiểm tra giá trị nếu không rỗng
                if (txtTraTien.Text != string.Empty)
                {
                    int tienThua = Convert.ToInt32(txtTraTien.Text.ToString()) - Convert.ToInt32(lblMoney.Text.ToString());
                    if (tienThua < 0) //Nếu tiền thừa < 0 thì cho text = 0
                    {
                        txtTienThua.Text = "0";
                    }
                    else //còn ko thì cho text = tienThua
                    {
                        txtTienThua.Text = tienThua.ToString();
                    }
                }
            }
            //Bắt lỗi
            catch
            {
                MessageBox.Show("Chỉ được nhập số");
            }
        }
    }
}
