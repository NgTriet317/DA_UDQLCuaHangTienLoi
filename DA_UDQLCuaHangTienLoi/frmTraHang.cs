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
        public static string maTraNCC = "";
        public static string tenKho = "";
        public static string trangThai = "Phiếu tạm";

        // Cờ hiệu kiểm tra trạng thái Form: false = Tạo mới, true = Xem/Sửa cũ
        private bool isEditMode = false;

        public frmTraHang()
        {
            InitializeComponent();
        }

        BUS_TRAHANGNCC traHangNcc = new BUS_TRAHANGNCC();
        BUS_NCC ncc = new BUS_NCC();
        BUS_KHO kho = new BUS_KHO();
        BUS_NHAPHANG nhaphang = new BUS_NHAPHANG();
        BUS_NHANVIEN nv = new BUS_NHANVIEN();
        BUS_SP sp = new BUS_SP();
        BUS_SPNH spnh = new BUS_SPNH();

        private void label14_Click(object sender, EventArgs e) { }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e) { }

        private void frmTraHang_Load(object sender, EventArgs e)
        {
            lblTrangThai.Text = trangThai;
            lblTrangThai.ForeColor = (trangThai == "Đã duyệt") ? Color.Green : Color.OrangeRed;

            // === BƯỚC 1: NẠP SẴN CÁC DỮ LIỆU ĐỒNG BỘ LÊN FORM TRƯỚC ===
            lblMaPhieu.Text = maTraNCC;
            txtKho.Text = tenKho;
            txtNVName.Text = nv.layNVTheoMa(frmMain.maNV).Rows[0]["HoTenNV"].ToString();

            // Nạp danh sách phiếu nhập hợp lệ vào ComboBox trước để sẵn sàng hiển thị dữ liệu nếu sửa phiếu
            cboPhieuNhap.Items.Clear();
            cboPhieuNhap.Items.Insert(0, "--Chọn phiếu nhập--");
            DataTable dt = nhaphang.layTT();
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["TrangThai"].ToString() == "Đã xác nhận")
                {
                    cboPhieuNhap.Items.Add(dr["MaNH"].ToString());
                }
            }

            // === BƯỚC 2: PHÂN TÁCH CHẾ ĐỘ FORM (TẠO MỚI HOẶC XEM/SỬA) ===
            if (string.IsNullOrEmpty(maTraNCC))
            {
                // CHẾ ĐỘ 1: TẠO MỚI PHIẾU
                isEditMode = false;
                maTraNCC = traHangNcc.taoPhieuTraHang();
                lblMaPhieu.Text = maTraNCC;
            }
            else
            {
                // CHẾ ĐỘ 2: XEM VÀ CẬP NHẬT PHIẾU CŨ (EDIT MODE)
                isEditMode = true;

                DataTable dtLayTT = traHangNcc.layCTPhieuTraHang(maTraNCC);
                if (dtLayTT != null && dtLayTT.Rows.Count > 0)
                {
                    // Lấy thông tin master chung của phiếu (Lấy từ dòng đầu tiên)
                    string maNCC = dtLayTT.Rows[0]["MaNCC"].ToString();
                    txtNCC.Text = ncc.layTenNCC(maNCC);
                    rtbLiDo.Text = dtLayTT.Rows[0]["LyDoTraHang"].ToString();

                    // Tìm và hiển thị chính xác mã phiếu nhập cũ trên ComboBox công bằng
                    string maNH = dtLayTT.Rows[0]["MaNH"]?.ToString();
                    if (!string.IsNullOrEmpty(maNH))
                    {
                        foreach (var item in cboPhieuNhap.Items)
                        {
                            if (item.ToString() == maNH)
                            {
                                cboPhieuNhap.Text = maNH;
                                break;
                            }
                        }
                    }

                    // Tải TOÀN BỘ sản phẩm của phiếu lên GridView
                    dgvTTPhieuXuat.Rows.Clear();
                    foreach (DataRow drSanPham in dtLayTT.Rows)
                    {
                        string maSP = drSanPham["MaSP"].ToString();
                        string tenSP = drSanPham["TenSP"].ToString();
                        string DVT = drSanPham["MaDVT"].ToString();

                        // Lấy số lượng tồn kho hiện thời của sản phẩm
                        var dtKho = kho.timSPKho(maSP, kho.layMaKho(txtKho.Text));
                        string slKho = (dtKho != null && dtKho.Rows.Count > 0) ? dtKho.Rows[0]["SoLuongTonKho"].ToString() : "0";

                        decimal giaGoc = Convert.ToDecimal(drSanPham["GiaGoc"]);
                        int slMacDinh = Convert.ToInt32(drSanPham["SoLuong"]);
                        decimal thanhTienMacDinh = drSanPham["ThanhTien"] != DBNull.Value ? Convert.ToDecimal(drSanPham["ThanhTien"]) : 0;
                        string lyDoChiTiet = drSanPham["LyDoChiTiet"] != DBNull.Value ? drSanPham["LyDoChiTiet"].ToString() : "";

                        dgvTTPhieuXuat.Rows.Add(maSP, tenSP, DVT, slKho, slMacDinh, giaGoc, thanhTienMacDinh, lyDoChiTiet);
                    }

                    // Cập nhật lại các nhãn tổng tiền, tổng sản phẩm ngay khi load xong phiếu cũ
                    TinhTongTienPhieu();
                }
            }

            // === BƯỚC 3: KIỂM TRA TRẠNG THÁI KHÓA FORM NẾU PHIẾU ĐÃ DUYỆT ===
            KiemTraVaKhoaGiaoDien();
        }

        // Tách riêng hàm kiểm tra trạng thái để dùng chung cho cả Form_Load và sau khi nhấn duyệt thành công
        private void KiemTraVaKhoaGiaoDien()
        {
            if (lblTrangThai.Text == "Đã duyệt")
            {
                btnXacNhanTra.Enabled = false;
                btnLuuPhieu.Enabled = false;
                btnAddDS.Enabled = false;
                txtSearch.Enabled = false;
                cboPhieuNhap.Enabled = false;
                rtbLiDo.Enabled = false;
                dgvTTPhieuXuat.ReadOnly = true; // Không cho sửa số lượng trực tiếp trên lưới nữa
            }
            else
            {
                btnXacNhanTra.Enabled = true;
                btnLuuPhieu.Enabled = true;
                btnAddDS.Enabled = true;
                txtSearch.Enabled = true;
                cboPhieuNhap.Enabled = true;
                rtbLiDo.Enabled = true;
                dgvTTPhieuXuat.ReadOnly = false;
            }
        }

        private void btnAddDS_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text.Trim()))
            {
                string tuKhoa = txtSearch.Text.Trim();
                DataTable dtKetQua = sp.timSPTheoTenTrongTraHang(tuKhoa);

                if (dtKetQua == null || dtKetQua.Rows.Count == 0)
                {
                    dtKetQua = sp.timSPMaTrongTraHang(tuKhoa);
                }

                if (dtKetQua == null || dtKetQua.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy sản phẩm trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DataRow drSanPham = dtKetQua.Rows[0];
                string maSP = drSanPham["MaSP"].ToString();
                string tenSP = drSanPham["TenSP"].ToString();

                DataTable dtKho = kho.timSPKho(maSP, kho.layMaKho(txtKho.Text));
                if (dtKho == null || dtKho.Rows.Count == 0)
                {
                    MessageBox.Show($"Sản phẩm [{tenSP}] không có trong kho!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSearch.Clear();
                    txtSearch.Focus();
                    return;
                }

                string DVT = drSanPham["MaDVT"].ToString();
                string slKho = dtKho.Rows[0]["SoLuongTonKho"].ToString(); // Sửa tối ưu: Lấy từ dtKho đã kiểm tra ở trên thay vì truy vấn lại lần nữa
                decimal giaGoc = Convert.ToDecimal(drSanPham["GiaGoc"]);
                string tenNCCCuaSP = drSanPham["TenNCC"].ToString();

                if (dgvTTPhieuXuat.Rows.Count == 0)
                {
                    txtNCC.Text = tenNCCCuaSP;
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
                        return;
                    }
                }

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
                    dgvTTPhieuXuat.Rows.Add(maSP, tenSP, DVT, slKho, slMacDinh, giaGoc, thanhTienMacDinh, "");
                }

                txtSearch.Clear();
                txtSearch.Focus();
            }
            else
            {
                if (cboPhieuNhap.SelectedIndex > 0 && cboPhieuNhap.SelectedItem != null)
                {
                    DataTable dtChiTietPN = spnh.layTT(cboPhieuNhap.SelectedItem.ToString());
                    if (dtChiTietPN == null || dtChiTietPN.Rows.Count == 0) return;

                    dgvTTPhieuXuat.Rows.Clear();
                    txtNCC.Clear();

                    foreach (DataRow dr in dtChiTietPN.Rows)
                    {
                        string maSP = dr["MaSP"].ToString();
                        DataTable dtsp = sp.timSPMaTrongTraHang(maSP);
                        if (dtsp.Rows.Count == 0) continue;

                        DataRow drSpChiTiet = dtsp.Rows[0];
                        string tenNCCCuaSP = drSpChiTiet["TenNCC"].ToString();

                        if (string.IsNullOrEmpty(txtNCC.Text))
                        {
                            txtNCC.Text = tenNCCCuaSP;
                        }

                        string tenSP = drSpChiTiet["TenSP"].ToString();
                        string DVT = drSpChiTiet["MaDVT"].ToString();

                        DataTable dtKho = kho.timSPKho(maSP, kho.layMaKho(txtKho.Text));
                        if (dtKho == null || dtKho.Rows.Count == 0)
                        {
                            MessageBox.Show($"Sản phẩm [{tenSP}] không có trong kho!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtSearch.Clear();
                            txtSearch.Focus();
                            return;
                        }

                        int slNhap = Convert.ToInt32(dr["SoLuongNhap"]);
                        decimal giaGoc = Convert.ToDecimal(drSpChiTiet["GiaGoc"]);
                        decimal thanhTienPhaiTra = slNhap * giaGoc;

                        dgvTTPhieuXuat.Rows.Add(maSP, tenSP, DVT, slNhap, slNhap, giaGoc, thanhTienPhaiTra, "");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập mã sản phẩm hoặc chọn một phiếu nhập cụ thể!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            TinhTongTienPhieu();
        }

        private void ResetForm()
        {
            dgvTTPhieuXuat.Rows.Clear();
            txtSearch.Clear();
            txtNCC.Clear();
        }

        private void colXoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvTTPhieuXuat.Columns["colXoa"].Index && e.RowIndex >= 0)
            {
                dgvTTPhieuXuat.Rows.RemoveAt(e.RowIndex);
                TinhTongTienPhieu();
            }
        }

        private void dgvTTPhieuXuat_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvTTPhieuXuat.Columns[e.ColumnIndex].Name == "colSL")
            {
                string cellValue = Convert.ToString(dgvTTPhieuXuat.Rows[e.RowIndex].Cells["colSL"].Value);
                int slNhap = 0;
                int.TryParse(cellValue, out slNhap);

                int slTonKho = Convert.ToInt32(dgvTTPhieuXuat.Rows[e.RowIndex].Cells["colTonKho"].Value);

                if (slNhap < 0 || slNhap > slTonKho)
                {
                    MessageBox.Show("Số lượng trả không hợp lệ hoặc lớn hơn số lượng tồn kho!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    dgvTTPhieuXuat.CellValueChanged -= dgvTTPhieuXuat_CellValueChanged;
                    dgvTTPhieuXuat.Rows[e.RowIndex].Cells["colSL"].Value = 0;
                    dgvTTPhieuXuat.Rows[e.RowIndex].Cells["colThanhTien"].Value = 0;
                    dgvTTPhieuXuat.CellValueChanged += dgvTTPhieuXuat_CellValueChanged;

                    TinhTongTienPhieu();
                    return;
                }

                decimal giaGoc = Convert.ToDecimal(dgvTTPhieuXuat.Rows[e.RowIndex].Cells["colGiaNhap"].Value);
                dgvTTPhieuXuat.Rows[e.RowIndex].Cells["colThanhTien"].Value = slNhap * giaGoc;

                TinhTongTienPhieu();
            }
        }

        private void TinhTongTienPhieu()
        {
            decimal tongTien = 0;
            int tongSoSP = 0;
            int SoLuong = 0;

            foreach (DataGridViewRow row in dgvTTPhieuXuat.Rows)
            {
                if (!row.IsNewRow)
                {
                    tongSoSP++;
                    int tongSoLuongSP = 0;
                    if (row.Cells["colSL"].Value != null)
                    {
                        int.TryParse(row.Cells["colSL"].Value.ToString(), out tongSoLuongSP);
                    }
                    SoLuong += tongSoLuongSP;

                    decimal thanhTienDong = 0;
                    if (row.Cells["colThanhTien"].Value != null)
                    {
                        decimal.TryParse(row.Cells["colThanhTien"].Value.ToString(), out thanhTienDong);
                    }
                    tongTien += thanhTienDong;
                }
            }

            lblSLMH.Text = tongSoSP.ToString();
            lblSLXuatTra.Text = SoLuong.ToString();
            lblTongTienHoan.Text = tongTien.ToString("N0") + " VNĐ";
        }

        private bool ThucHienLuuPhieu(bool hienThongBao = true)
        {
            // 1. Kiểm tra dữ liệu trên DataGridView
            if (dgvTTPhieuXuat.Rows.Count == 0 || (dgvTTPhieuXuat.Rows.Count == 1 && dgvTTPhieuXuat.Rows[0].IsNewRow))
            {
                MessageBox.Show("Không tìm thấy sản phẩm nào trong danh sách trả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 2. Kiểm tra bắt buộc nhập lý do chi tiết cho từng dòng
            foreach (DataGridViewRow row in dgvTTPhieuXuat.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["colLyDoCT"].Value == null || string.IsNullOrWhiteSpace(row.Cells["colLyDoCT"].Value.ToString()))
                {
                    MessageBox.Show($"Dòng số {row.Index + 1}: Lý do trả hàng từng sản phẩm không được phép để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            // 3. Xóa chi tiết cũ và nạp lại chi tiết mới từ GridView
            traHangNcc.xoaCTTraHang(lblMaPhieu.Text);

            bool tatCaThanhCong = true;
            foreach (DataGridViewRow row in dgvTTPhieuXuat.Rows)
            {
                if (row.IsNewRow) continue;

                var chiTiet = new ET.ET_CHITIETTRAHANGNCC
                {
                    MaTraNCC = lblMaPhieu.Text,
                    MaSP = row.Cells["colMaSP"].Value?.ToString(),
                    SoLuong = Convert.ToInt32(row.Cells["colSL"].Value),
                    GiaHoan = Convert.ToDecimal(row.Cells["colGiaNhap"].Value),
                    LyDo = row.Cells["colLyDoCT"].Value?.ToString()
                };

                if (!traHangNcc.luuCTTraHang(chiTiet))
                {
                    tatCaThanhCong = false;
                    break;
                }
            }

            // 4. Xử lý cập nhật thông tin chung của phiếu trả hàng
            if (tatCaThanhCong)
            {
                string maPhieu = lblMaPhieu.Text;
                string maNCC = ncc.layMaNCC(txtNCC.Text);
                string maKho = kho.layMaKho(txtKho.Text);
                string maNV = frmMain.maNV;
                string lyDoTongPhieu = rtbLiDo.Text;

                string chuoiTienSach = lblTongTienHoan.Text.Replace(" VNĐ", "").Replace(",", "").Replace(".", "").Trim();
                int tongTien = Convert.ToInt32(chuoiTienSach);

                bool ketQuaCapNhatPhieu = false;

                if (cboPhieuNhap.SelectedIndex > 0 && cboPhieuNhap.SelectedItem != null)
                {
                    string maNH = cboPhieuNhap.SelectedItem.ToString();
                    ketQuaCapNhatPhieu = traHangNcc.capNhatTTPhieuTraHang(maPhieu, maKho, maNCC, maNH, maNV, lyDoTongPhieu, tongTien);
                }
                else
                {
                    ketQuaCapNhatPhieu = traHangNcc.capNhatTTPhieuTraHangKoNH(maPhieu, maKho, maNCC, maNV, lyDoTongPhieu, tongTien);
                }

                if (ketQuaCapNhatPhieu)
                {
                    if (hienThongBao)
                    {
                        if (isEditMode)
                            MessageBox.Show("Cập nhật thông tin phiếu trả hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Lưu phiếu trả hàng và cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    return true; // Thành công
                }
                else
                {
                    MessageBox.Show("Lưu được chi tiết sản phẩm nhưng cập nhật thông tin tổng của phiếu bị thất bại!", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Lưu phiếu trả hàng thất bại do lỗi lưu chi tiết sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            if (ThucHienLuuPhieu(true))
            {
                this.Close();
            }
        }

        private void btnXacNhanTra_Click(object sender, EventArgs e)
        {
            if (lblTrangThai.Text == "Đã duyệt")
            {
                btnXacNhanTra.Enabled = false;
                MessageBox.Show("Phiếu này đã được duyệt trước đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dgvTTPhieuXuat.Rows.Count == 0 || (dgvTTPhieuXuat.Rows.Count == 1 && dgvTTPhieuXuat.Rows[0].IsNewRow))
            {
                MessageBox.Show("Không có sản phẩm nào trong danh sách để xác nhận trả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xác nhận duyệt phiếu trả hàng này không?\nHành động này sẽ lưu lại phiếu, trừ số lượng trong kho và không thể sửa đổi nữa!",
                                              "Xác nhận duyệt phiếu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    // ==========================================
                    // BƯỚC QUAN TRỌNG: ÉP BUỘC LƯU PHIẾU TRƯỚC
                    // Truyền false để không hiện popup thông báo lưu thành công làm phiền người dùng
                    // ==========================================
                    if (!ThucHienLuuPhieu(false))
                    {
                        // Nếu hàm trả về false (nghĩa là lưu thất bại hoặc thiếu thông tin) -> Dừng luôn quá trình duyệt
                        return;
                    }

                    // 1. DUYỆT QUA GRIDVIEW ĐỂ TRỪ SỐ LƯỢNG TRONG KHO
                    foreach (DataGridViewRow row in dgvTTPhieuXuat.Rows)
                    {
                        if (row.IsNewRow) continue;

                        if (row.Cells["colMaSP"].Value != null && row.Cells["colSL"].Value != null)
                        {
                            string maSP = row.Cells["colMaSP"].Value.ToString();
                            int slTra = Convert.ToInt32(row.Cells["colSL"].Value);
                            int slTonKho = Convert.ToInt32(row.Cells["colTonKho"].Value);

                            bool updateKhoThanhCong = kho.updateKho(maSP, slTonKho-slTra);

                            if (!updateKhoThanhCong)
                            {
                                MessageBox.Show($"Lỗi khi cập nhật trừ kho cho sản phẩm mã: {maSP}", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                    // 2. CẬP NHẬT TRẠNG THÁI PHIẾU SANG "ĐÃ DUYỆT" TRONG DATABASE
                    string maPhieuTra = lblMaPhieu.Text;
                    bool updatePhieuThanhCong = traHangNcc.capNhatTrangThaiPhieuTraHang(maPhieuTra, "Đã duyệt");

                    if (updatePhieuThanhCong)
                    {
                        // 3. CẬP NHẬT GIAO DIỆN SAU KHI DUYỆT THÀNH CÔNG
                        lblTrangThai.Text = "Đã duyệt";
                        lblTrangThai.ForeColor = Color.Green;
                        trangThai = "Đã duyệt";

                        // Khóa giao diện
                        KiemTraVaKhoaGiaoDien();

                        MessageBox.Show("Xác nhận trả hàng và cập nhật trừ tồn kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật trạng thái phiếu thất bại tại cơ sở dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHuyThaoTac_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}