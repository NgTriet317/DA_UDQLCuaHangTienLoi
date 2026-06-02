using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace DA_UDQLCuaHangTienLoi
{
    public partial class frmTraHang : Form
    {
        public frmTraHang()
        {
            InitializeComponent();
        }

        BUS_NCC ncc = new BUS_NCC();
        BUS_KHO kho = new BUS_KHO();
        BUS_NHAPHANG nhaphang = new BUS_NHAPHANG();
        BUS_NHANVIEN nv = new BUS_NHANVIEN();
        BUS_SP sp = new BUS_SP();
        BUS_SPNH spnh = new BUS_SPNH();

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmTraHang_Load(object sender, EventArgs e)
        {
            txtKho.Text = frmMain.chiNhanh;

            txtNVName.Text = nv.layNVTheoMa(frmMain.maNV).Rows[0]["HoTenNV"].ToString();

            cboPhieuNhap.Items.Insert(0, "--Chọn phiếu nhập--");

            DataTable dt = nhaphang.layTT();
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["TrangThai"].ToString() == "Đã xác nhận")
                {
                    cboPhieuNhap.Items.Add(dr["MaNH"].ToString());
                }
            }
        }

        private void btnAddDS_Click(object sender, EventArgs e)
        {
            // TRƯỜNG HỢP 1: NGƯỜI DÙNG CÓ GÕ Ô TÌM KIẾM (HOẶC QUÉT MÃ VẠCH)
            if (!string.IsNullOrEmpty(txtSearch.Text.Trim()))
            {
                string tuKhoa = txtSearch.Text.Trim();
                DataTable dtKetQua = sp.timSPTheoTenTrongTraHang(tuKhoa); // Thử tìm theo Tên trước

                if (dtKetQua == null || dtKetQua.Rows.Count == 0)
                {
                    dtKetQua = sp.timSPMaTrongTraHang(tuKhoa); // Nếu không ra, tìm theo Mã
                }

                if (dtKetQua == null || dtKetQua.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy sản phẩm trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Lấy thông tin của sản phẩm tìm thấy
                DataRow drSanPham = dtKetQua.Rows[0];
                string maSP = drSanPham["MaSP"].ToString();
                string tenSP = drSanPham["TenSP"].ToString();
                string DVT = drSanPham["MaDVT"].ToString();
                decimal giaGoc = Convert.ToDecimal(drSanPham["GiaGoc"]);

                // LẤY TÊN NHÀ CUNG CẤP
                string tenNCCCuaSP = drSanPham["TenNCC"].ToString();

                // --- LOGIC CHECK VÀ ĐIỀN NHÀ CUNG CẤP (NHÁNH TÌM KIẾM) ---
                if (dgvTTPhieuXuat.Rows.Count == 0)
                {
                    txtNCC.Text = tenNCCCuaSP; // Sản phẩm đầu tiên -> Điền tên NCC
                }
                else
                {
                    string tenNCCHienTai = txtNCC.Text;
                    if (tenNCCCuaSP != tenNCCHienTai)
                    {
                        MessageBox.Show($"Sản phẩm [{tenSP}] thuộc Nhà cung cấp khác ({tenNCCCuaSP})!\nPhiếu trả hàng này đang được gán cho NCC: {tenNCCHienTai}.",
                                        "Sai Nhà Cung Cấp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSearch.Clear();
                        txtSearch.Focus();
                        return; // Chặn lại, không cho thêm vào lưới
                    }
                }

                // --- KIỂM TRA TRÙNG LẶP TRÊN LƯỚI ---
                bool daTonTai = false;
                foreach (DataGridViewRow row in dgvTTPhieuXuat.Rows)
                {
                    if (row.Cells["colMaSP"].Value != null && row.Cells["colMaSP"].Value.ToString() == maSP)
                    {
                        daTonTai = true;
                        int slHienTai = Convert.ToInt32(row.Cells["colSL"].Value);
                        row.Cells["colSL"].Value = slHienTai + 1;
                        row.Cells["colThanhTien"].Value = (slHienTai + 1) * giaGoc;
                        break;
                    }
                }

                if (!daTonTai)
                {
                    int slMacDinh = 1;
                    decimal thanhTienMacDinh = slMacDinh * giaGoc;
                    dgvTTPhieuXuat.Rows.Add(maSP, tenSP, DVT, 0, slMacDinh, giaGoc, thanhTienMacDinh);
                }

                txtSearch.Clear();
                txtSearch.Focus();
            }
            // TRƯỜNG HỢP 2: Ô TÌM KIẾM TRỐNG -> ĐỔ TOÀN BỘ SẢN PHẨM THEO MÃ PHIẾU NHẬP
            else
            {
                if (cboPhieuNhap.SelectedIndex > 0 && cboPhieuNhap.SelectedItem != null)
                {
                    // Lấy chi tiết các sản phẩm từ phiếu nhập được chọn
                    DataTable dtChiTietPN = spnh.layTT(cboPhieuNhap.SelectedItem.ToString());
                    if (dtChiTietPN == null || dtChiTietPN.Rows.Count == 0) return;

                    // Xóa sạch lưới cũ và xóa luôn tên NCC cũ trước khi đổ phiếu nhập mới
                    dgvTTPhieuXuat.Rows.Clear();
                    txtNCC.Clear();

                    foreach (DataRow dr in dtChiTietPN.Rows)
                    {
                        string maSP = dr["MaSP"].ToString();

                        // Tìm thông tin chi tiết sản phẩm dựa theo mã (Hàm này cũng bắt buộc phải JOIN lấy TenNCC)
                        DataTable dtsp = sp.findSPMa(maSP);
                        if (dtsp.Rows.Count == 0) continue;

                        DataRow drSpChiTiet = dtsp.Rows[0];
                        string tenNCCCuaSP = drSpChiTiet["TenNCC"].ToString();

                        // --- LOGIC ĐIỀN NHÀ CUNG CẤP (NHÁNH PHIẾU NHẬP) ---
                        // Vì một phiếu nhập chắc chắn chỉ thuộc về một NCC, 
                        // nên ta lấy tên NCC từ sản phẩm đầu tiên tìm thấy gán vào txtNCC luôn.
                        if (string.IsNullOrEmpty(txtNCC.Text))
                        {
                            txtNCC.Text = tenNCCCuaSP;
                        }

                        string tenSP = drSpChiTiet["TenSP"].ToString();
                        string DVT = drSpChiTiet["MaDVT"].ToString();
                        int slNhap = Convert.ToInt32(dr["SoLuongNhap"]);
                        decimal giaGoc = Convert.ToDecimal(drSpChiTiet["GiaGoc"]);
                        decimal thanhTienPhaiTra = slNhap * giaGoc;

                        // Thêm sản phẩm vào GridView
                        dgvTTPhieuXuat.Rows.Add(maSP, tenSP, DVT, slNhap, slNhap, giaGoc, thanhTienPhaiTra);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập mã sản phẩm hoặc chọn một phiếu nhập cụ thể!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void ResetForm()
        {
            dgvTTPhieuXuat.Rows.Clear();
            txtSearch.Clear();
            txtNCC.Clear(); // Xóa trắng thông tin nhà cung cấp cũ đi là xong
        }
        private void colXoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvTTPhieuXuat.Columns["colXoa"].Index && e.RowIndex >= 0)
            {
                dgvTTPhieuXuat.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void dgvTTPhieuXuat_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Dùng >= 0 để không bỏ sót dòng đầu tiên (Index 0)
            if (e.RowIndex >= 0 && dgvTTPhieuXuat.Columns[e.ColumnIndex].Name == "colSL")
            {
                // 2. Dùng int.TryParse để tránh phần mềm bị văng (crash) nếu ô bị bỏ trống hoặc gõ chữ
                string cellValue = Convert.ToString(dgvTTPhieuXuat.Rows[e.RowIndex].Cells["colSL"].Value);
                int slNhap = 0;
                int.TryParse(cellValue, out slNhap);

                int slTonKho = Convert.ToInt32(dgvTTPhieuXuat.Rows[e.RowIndex].Cells["colTonKho"].Value);

                // 3. Kiểm tra logic nhập
                if (slNhap < 0 || slNhap > slTonKho)
                {
                    MessageBox.Show("Số lượng trả không hợp lệ hoặc lớn hơn số lượng tồn kho!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Tạm thời gỡ sự kiện để không bị lặp vô hạn khi gán lại giá trị = 0
                    dgvTTPhieuXuat.CellValueChanged -= dgvTTPhieuXuat_CellValueChanged;

                    dgvTTPhieuXuat.Rows[e.RowIndex].Cells["colSL"].Value = 0;
                    dgvTTPhieuXuat.Rows[e.RowIndex].Cells["colThanhTien"].Value = 0;

                    // Gắn sự kiện trở lại
                    dgvTTPhieuXuat.CellValueChanged += dgvTTPhieuXuat_CellValueChanged;

                    // Cập nhật lại tổng tiền sau khi reset số lượng
                    TinhTongTienPhieu();
                    return;
                }

                // 4. Nếu số lượng chuẩn -> Tính Thành Tiền
                decimal giaGoc = Convert.ToDecimal(dgvTTPhieuXuat.Rows[e.RowIndex].Cells["colGiaNhap"].Value);
                dgvTTPhieuXuat.Rows[e.RowIndex].Cells["colThanhTien"].Value = slNhap * giaGoc;

                // 5. Cập nhật lại tổng tiền
                TinhTongTienPhieu();
            }
        }

        private void TinhTongTienPhieu()
        {
            decimal tongTien = 0;

            // Duyệt qua tất cả các dòng hiện có trên DataGridView
            foreach (DataGridViewRow row in dgvTTPhieuXuat.Rows)
            {
                // Bỏ qua dòng trống (nếu có)
                if (!row.IsNewRow)
                {
                    decimal thanhTienDong = 0;
                    if (row.Cells["colThanhTien"].Value != null)
                    {
                        decimal.TryParse(row.Cells["colThanhTien"].Value.ToString(), out thanhTienDong);
                    }
                    tongTien += thanhTienDong;
                }
            }

            // Hiển thị ra một Label hoặc TextBox Tổng Tiền trên giao diện
            lblTongTienHoan.Text = tongTien.ToString("N0") + " VNĐ";
        }
    }
}
