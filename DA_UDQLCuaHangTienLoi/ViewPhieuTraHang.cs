using BUS;
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
    public partial class ViewPhieuTraHang : Form
    {
        public ViewPhieuTraHang()
        {
            InitializeComponent();
        }



        private void label5_Click(object sender, EventArgs e)
        {

        }

        public static string TenKho = "";

        BUS_NCC ncc = new BUS_NCC();
        BUS_TRAHANGNCC thncc = new BUS_TRAHANGNCC();
        private void ViewPhieuTraHang_Load(object sender, EventArgs e)
        {
            DataTable dt = thncc.layAllTT();

            foreach (DataRow dr in dt.Rows)
            {
                // Thêm một dòng trống mới vào Grid và lấy chỉ số (index) của dòng đó
                int rowIndex = dgvTraHang.Rows.Add();

                //bỏ hiệu ứng click dòng đổi màu chữ của dgv



                // Gán giá trị từ DataRow vào đúng tên cột (Name) tương ứng trên Grid
                // Hãy đổi chữ "colMa", "colThoiGian",... thành CHÍNH XÁC tên cột bạn đặt trên giao diện nhé
                dgvTraHang.Rows[rowIndex].Cells["MaTraNCC"].Value = dr["MaTraNCC"]?.ToString();
                dgvTraHang.Rows[rowIndex].Cells["colNCC"].Value = ncc.layTenNCC(dr["MaNCC"]?.ToString());
                dgvTraHang.Rows[rowIndex].Cells["colTime"].Value = dr["ThoiGianTra"] != DBNull.Value ? Convert.ToDateTime(dr["ThoiGianTra"]).ToString("dd/MM/yyyy HH:mm") : "";
                dgvTraHang.Rows[rowIndex].Cells["colMoney"].Value = dr["TongTien"] != DBNull.Value ? string.Format("{0:N0} đ", dr["TongTien"]) : "0 đ";
                dgvTraHang.Rows[rowIndex].Cells["colNV"].Value = dr["MaNV"]?.ToString();
                dgvTraHang.Rows[rowIndex].Cells["colTrangThai"].Value = dr["TrangThai"]?.ToString();
                //chỉnh màu trạng thái
                if (dgvTraHang.Rows[rowIndex].Cells["colTrangThai"].Value.ToString() == "Phiếu tạm")
                {
                    dgvTraHang.Rows[rowIndex].Cells["colTrangThai"].Style.ForeColor = Color.Orange;
                }
                else if (dgvTraHang.Rows[rowIndex].Cells["colTrangThai"].Value.ToString() == "Đã duyệt")
                {
                    dgvTraHang.Rows[rowIndex].Cells["colTrangThai"].Style.ForeColor = Color.Green;
                }                
                else
                {
                    dgvTraHang.Rows[rowIndex].Cells["colTrangThai"].Style.ForeColor = Color.Black;
                }                
            }

            lblKho.Text = TenKho;

            cboNCC.DataSource = ncc.layNCC();
            cboNCC.DisplayMember = "TenNCC";
            cboNCC.ValueMember = "MaNCC";
            cboNCC.SelectedIndex = -1;
        }

        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            frmTraHang.maTraNCC = "";
            frmTraHang.trangThai = "Phiếu tạm";
            frmTraHang.tenKho = "";
            frmTraHang.tenKho = TenKho;

            // Gọi hàm và hứng trực tiếp Mã phiếu từ SQL Server trả về

            // Mở form và TRUYỀN THẲNG MÃ VỪA TẠO sang
            frmTraHang traHang = new frmTraHang();
            traHang.ShowDialog();
            resetForm();
        }

        private void dgvTraHang_Click(object sender, EventArgs e)
        {
            dgvTraHang.ClearSelection(); // Bỏ chọn tất cả các dòng trước đó

            //đưa mã lên textbox
            if (dgvTraHang.CurrentRow.Selected = true)
            {
                txtMaPhieu.Text = dgvTraHang.CurrentRow.Cells["MaTraNCC"].Value.ToString();
            }
        }
        //reset form khi đóng form con
        public void resetForm()
        {
            txtMaPhieu.Clear();
            cboNCC.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = 0;
            dgvTraHang.Rows.Clear();
            ViewPhieuTraHang_Load(null, null); // Tải lại dữ liệu từ đầu
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            frmTraHang.tenKho = "";
            frmTraHang.tenKho = TenKho;

            // Gọi hàm và hứng trực tiếp Mã phiếu từ SQL Server trả về
            string maPhieuHienTai = txtMaPhieu.Text.Trim();

            if (!string.IsNullOrEmpty(maPhieuHienTai))
            {
                string trangThaiPhieu = dgvTraHang.CurrentRow.Cells["colTrangThai"].Value.ToString();
                frmTraHang.trangThai = trangThaiPhieu; // Truyền trạng thái hiện tại của phiếu
                // Mở form và TRUYỀN THẲNG MÃ VỪA TẠO sang
                frmTraHang traHang = new frmTraHang();
                frmTraHang.maTraNCC = maPhieuHienTai; // Nhận mã chuẩn từ DB (Ví dụ: MTNCC01 hoặc MTNCC0001)
                traHang.ShowDialog();
                resetForm();

            }
            else
            {
                MessageBox.Show("Tạo phiếu trả hàng thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaPhieu.Text))
            {
                MessageBox.Show("Vui lòng chọn phiếu trả hàng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //nếu trạng thái là phiếu tạm thì mới cho xóa
            if (dgvTraHang.CurrentRow.Cells["colTrangThai"].Value.ToString() == "Phiếu tạm")
            {
                string maPhieu = txtMaPhieu.Text.Trim();
                bool xoaCT = thncc.xoaCTTraHang(maPhieu);
                if (xoaCT)
                {
                    MessageBox.Show("Xóa chi tiết trả hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Cập nhật lại DataGridView sau khi xóa
                    dgvTraHang.Rows.Remove(dgvTraHang.CurrentRow);
                    txtMaPhieu.Clear();
                    resetForm();
                }
                else
                {
                    MessageBox.Show("Xóa chi tiết trả hàng thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Chỉ có thể xóa phiếu trả hàng có trạng thái 'Phiếu tạm'!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }       

        // 1. Tạo hàm dùng chung để xử lý lọc và đổ dữ liệu
        private void LocDuLieuTraHang()
        {
            // Lấy toàn bộ dữ liệu gốc
            DataTable dt = thncc.layAllTT();
            if (dt == null || dt.Rows.Count == 0)
            {
                dgvTraHang.Rows.Clear();
                return;
            }

            // Khởi tạo biến truy vấn (chưa chạy ngay)
            var query = dt.AsEnumerable();

            // Bước 1: Áp dụng bộ lọc Nhà Cung Cấp (Nếu có chọn)
            if (cboNCC.SelectedIndex != -1 && cboNCC.SelectedValue != null)
            {
                string maNCC = cboNCC.SelectedValue.ToString();
                query = query.Where(row => row.Field<string>("MaNCC") == maNCC);
            }

            // Bước 2: Áp dụng thêm bộ lọc Trạng Thái (Nếu index > 0, mặc định 0 là "Tất cả")
            if (cboTrangThai.SelectedIndex > 0 && cboTrangThai.SelectedItem != null)
            {
                string trangThai = cboTrangThai.SelectedItem.ToString();
                query = query.Where(row => row.Field<string>("TrangThai") == trangThai);
            }

            // Xóa dữ liệu cũ trên GridView
            dgvTraHang.Rows.Clear();

            // Bước 3: Kiểm tra xem có dòng nào thỏa mãn điều kiện không trước khi copy
            if (query.Any())
            {
                DataTable filteredData = query.CopyToDataTable();

                foreach (DataRow dr in filteredData.Rows)
                {
                    int rowIndex = dgvTraHang.Rows.Add();
                    dgvTraHang.Rows[rowIndex].Cells["MaTraNCC"].Value = dr["MaTraNCC"]?.ToString();
                    dgvTraHang.Rows[rowIndex].Cells["colNCC"].Value = ncc.layTenNCC(dr["MaNCC"]?.ToString());
                    dgvTraHang.Rows[rowIndex].Cells["colTime"].Value = dr["ThoiGianTra"] != DBNull.Value ? Convert.ToDateTime(dr["ThoiGianTra"]).ToString("dd/MM/yyyy HH:mm") : "";
                    dgvTraHang.Rows[rowIndex].Cells["colMoney"].Value = dr["TongTien"] != DBNull.Value ? string.Format("{0:N0} đ", dr["TongTien"]) : "0 đ";
                    dgvTraHang.Rows[rowIndex].Cells["colNV"].Value = dr["MaNV"]?.ToString();

                    string trangThaiPhieu = dr["TrangThai"]?.ToString();
                    dgvTraHang.Rows[rowIndex].Cells["colTrangThai"].Value = trangThaiPhieu;

                    // Chỉnh màu trạng thái
                    if (trangThaiPhieu == "Phiếu tạm")
                    {
                        dgvTraHang.Rows[rowIndex].Cells["colTrangThai"].Style.ForeColor = Color.Orange;
                    }
                    else if (trangThaiPhieu == "Đã duyệt")
                    {
                        dgvTraHang.Rows[rowIndex].Cells["colTrangThai"].Style.ForeColor = Color.Green;
                    }
                    else
                    {
                        dgvTraHang.Rows[rowIndex].Cells["colTrangThai"].Style.ForeColor = Color.Black;
                    }
                }
            }
        }

        // 2. Gọi hàm lọc ở các sự kiện SelectedIndexChanged
        private void cboNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocDuLieuTraHang();
        }

        private void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Nếu chọn index 0 (ví dụ: "Tất cả"), dữ liệu vẫn sẽ được load đúng nhờ hàm LocDuLieuTraHang
            LocDuLieuTraHang();
        }

        private void btnLamMOi_Click(object sender, EventArgs e)
        {
            resetForm();
        }
    }
}
