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
    public partial class LuongBong : Form
    {
        public LuongBong()
        {
            InitializeComponent();
        }

        //Tạo form con
        private Form current_form_child;
        //Hàm mở form con cho thao tác
        // Hàm mở form con đã được tối ưu chống giật/co rút Form cha
        private void OpenChildForm(Form childForm)
        {
            if (current_form_child != null)
            {
                current_form_child.Close();
                current_form_child.Dispose(); // Bắt buộc Dispose để giải phóng RAM các control Guna cũ
            }

            current_form_child = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // 1. BẮT CẢ FORM CHA VÀ FORM CON TẠM DỪNG VẼ GIAO DIỆN
            pnKT_KL.SuspendLayout();
            childForm.SuspendLayout();

            // 2. Thêm form con vào Panel một cách "âm thầm"
            pnKT_KL.Controls.Clear();
            pnKT_KL.Controls.Add(childForm);
            pnKT_KL.Tag = childForm;

            // 3. KHÔI PHỤC VẼ GIAO DIỆN (Chú ý từ khóa 'true')
            childForm.ResumeLayout(false);
            pnKT_KL.ResumeLayout(true); // Tham số 'true' ép Panel phải tính toán xong xuôi kích thước TRƯỚC KHI hiện

            // 4. HIỂN THỊ SAU CÙNG (Lúc này WinForms đã tính toán xong, sẽ không bị Panic nữa)
            childForm.BringToFront();
            childForm.Show();

            // 5. Giải pháp chốt chặn cuối cùng: Ép Form cha nằm yên ở Maximized
            if (this.WindowState != FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }
        BUS_NHANVIEN nv = new BUS_NHANVIEN();
        BUS_BangLuong bl = new BUS_BangLuong();
        private void btnKhenThuong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new KhenThuong());
            btnKyLuat.FillColor = Color.FromName("ControlLight");
            btnKyLuat.ForeColor = Color.Black;
            btnKhenThuong.FillColor = Color.FromArgb(0, 192, 192);
            btnKhenThuong.ForeColor = Color.White;
        }

        private void LuongBong_Load(object sender, EventArgs e)
        {
            //Mở form con mặc định khi load form cha
            OpenChildForm(new KhenThuong());
            btnKhenThuong.FillColor = Color.FromArgb(0, 192, 192);
            btnKhenThuong.ForeColor = Color.White;
            // Load dữ liệu nhân viên vào ComboBox
            cboHoTenNV.DataSource = nv.layTTNhanVienCalam();
            cboHoTenNV.DisplayMember = "HoTenNV";
            cboHoTenNV.ValueMember = "MaNV";
            // Load danh sách bảng lương
            LoadLichSuBangLuong();
            // Load Ngày chốt lương đặt ở hiện tại
            dtpNgayChotLuong.Value = DateTime.Now;
        }

        private void LoadLichSuBangLuong()
        {
            DataTable dt = bl.LayDSBangLuong();
            if (dt != null)
            {
                dgvBangLuong.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    dgvBangLuong.Rows.Add(
                        row["MaBangLuong"].ToString(),
                        row["HoTenNV"].ToString(),

                        // Ép kiểu trực tiếp từ object và định dạng hiển thị tiền tệ (ví dụ: 500,000)
                        row["TongThuong"] != DBNull.Value ? Convert.ToDecimal(row["TongThuong"]).ToString("N0") : "0",
                        row["TongPhat"] != DBNull.Value ? Convert.ToDecimal(row["TongPhat"]).ToString("N0") : "0",
                        row["TongTienLuong"] != DBNull.Value ? Convert.ToDecimal(row["TongTienLuong"]).ToString("N0") : "0",

                        // Định dạng lại ngày tháng chốt lương
                        row["NgayChotLuong"] != DBNull.Value ? Convert.ToDateTime(row["NgayChotLuong"]).ToString("dd/MM/yyyy") : "",

                        // Cột Thực lĩnh cuối cùng
                        row["ThucLanh"] != DBNull.Value ? Convert.ToDecimal(row["ThucLanh"]).ToString("N0") : "0"
                    );
                }
            }
        }

        private void btnKyLuat_Click(object sender, EventArgs e)
        {
            OpenChildForm(new KyLuat());
            btnKhenThuong.FillColor = Color.FromName("ControlLight");
            btnKhenThuong.ForeColor = Color.Black;
            btnKyLuat.FillColor = Color.FromArgb(0, 192, 192);
            btnKyLuat.ForeColor = Color.White;
        }

        private void cboHoTenNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboHoTenNV.SelectedIndex != -1 && cboHoTenNV.SelectedItem is DataRowView)
            {
                // Ép kiểu item đang chọn về DataRowView
                DataRowView row = (DataRowView)cboHoTenNV.SelectedItem;

                // Giả sử TextBox hiển thị chức vụ của bạn tên là txtChucVu 
                // và tên cột chức vụ trong Database của bạn là "ChucVu"
                txtChucVu.Text = row["TenChucVu"].ToString();
            }
        }

        private void btnTHLuongThang_Click(object sender, EventArgs e)
        {
            string maNV = cboHoTenNV.SelectedValue.ToString();
            DateTime ngayChot = dtpNgayChotLuong.Value;
            int thang = ngayChot.Month;
            int nam = ngayChot.Year;
            if (ngayChot < DateTime.Now)
            {
                MessageBox.Show("Ngày chốt lương phải là ngày hiện tại hoặc tương lai!", "Lỗi ngày chốt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }    
            try
            {
                // 1. Gọi tầng BLL để chạy Stored Procedure và hứng kết quả trả về DataTable
                DataTable dt = bl.TongHopLuongThang(maNV, thang, nam, ngayChot);

                // 2. Kiểm tra nếu có dữ liệu trả về (chạy Insert và Select trong SP thành công)
                if (dt != null && dt.Rows.Count > 0)
                {
                    // Lấy dòng đầu tiên của kết quả
                    DataRow row = dt.Rows[0];

                    // 3. Rút dữ liệu từ DataRow đổ lên các ô hiển thị chi tiết
                    txtMaBangLuong.Text = row["MaBangLuong"].ToString();
                    txtMaLuongThang.Text = row["MaLuongThang"].ToString();
                    txtHoTenNV.Text = cboHoTenNV.Text; // Tên nhân viên lấy từ ComboBox

                    txtLuongCoBan.Text = Convert.ToDecimal(row["LuongCoBan"]).ToString("N0");
                    txtTongSoCa.Text = row["TongSoCa"].ToString();
                    txtTongTienCa.Text = Convert.ToDecimal(row["TongTienCa"]).ToString("N0");
                    txtTienPhuCap.Text = Convert.ToDecimal(row["PhuCap"]).ToString("N0");

                    txtTongTienThuong.Text = Convert.ToDecimal(row["TongThuong"]).ToString("N0");
                    txtTongTienPhat.Text = Convert.ToDecimal(row["TongPhat"]).ToString("N0");
                    txtTongTienLuong.Text = Convert.ToDecimal(row["TongTienLuong"]).ToString("N0");
                    txtNgayChotLuong.Text = Convert.ToDateTime(row["NgayChotLuong"]).ToString("dd/MM/yyyy");

                    // Ô Thực Lãnh hiển thị to màu xanh
                    txtThucLanh.Text = Convert.ToDecimal(row["ThucLanh"]).ToString("N0") + " VND";

                    // 4. Làm mới lại DataGridView danh sách lịch sử bảng lương ở dưới cùng
                    LoadLichSuBangLuong();

                    MessageBox.Show($"Đã tổng hợp thành công bảng lương tháng {thang}/{nam}!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thông báo hệ thống: " + ex.Message, "Lỗi tính lương", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadLichSuBangLuong();
            txtMaBangLuong.Clear();
            txtMaLuongThang.Clear();
            txtHoTenNV.Clear();
            txtLuongCoBan.Clear();
            txtTongSoCa.Clear();
            txtTongTienCa.Clear();
            txtTienPhuCap.Clear();
            txtTongTienThuong.Clear();
            txtTongTienPhat.Clear();
            txtTongTienLuong.Clear();
            txtNgayChotLuong.Clear();
            txtThucLanh.Clear();
        }

        private void btnLocTheoThangNam_Click(object sender, EventArgs e)
        {
            int thang = dtpNgayChotLuong.Value.Month;
            int nam = dtpNgayChotLuong.Value.Year;
            DataTable dt = bl.LocBangLuongTheoThangNam(thang, nam);
            if (dt != null)
            {
                dgvBangLuong.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    dgvBangLuong.Rows.Add(
                        row["MaBangLuong"].ToString(),
                        row["HoTenNV"].ToString(),

                        // Ép kiểu trực tiếp từ object và định dạng hiển thị tiền tệ (ví dụ: 500,000)
                        row["TongThuong"] != DBNull.Value ? Convert.ToDecimal(row["TongThuong"]).ToString("N0") : "0",
                        row["TongPhat"] != DBNull.Value ? Convert.ToDecimal(row["TongPhat"]).ToString("N0") : "0",
                        row["TongTienLuong"] != DBNull.Value ? Convert.ToDecimal(row["TongTienLuong"]).ToString("N0") : "0",

                        // Định dạng lại ngày tháng chốt lương
                        row["NgayChotLuong"] != DBNull.Value ? Convert.ToDateTime(row["NgayChotLuong"]).ToString("dd/MM/yyyy") : "",

                        // Cột Thực lĩnh cuối cùng
                        row["ThucLanh"] != DBNull.Value ? Convert.ToDecimal(row["ThucLanh"]).ToString("N0") : "0"
                    );
                }
            }    
        }

        private void btnLocTheoTenNV_Click(object sender, EventArgs e)
        {
            string tenNV = cboHoTenNV.Text;
            DataTable dt = bl.LocBangLuongTheoTenNV(tenNV);
            if (dt != null)
            {
                dgvBangLuong.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    dgvBangLuong.Rows.Add(
                        row["MaBangLuong"].ToString(),
                        row["HoTenNV"].ToString(),

                        // Ép kiểu trực tiếp từ object và định dạng hiển thị tiền tệ (ví dụ: 500,000)
                        row["TongThuong"] != DBNull.Value ? Convert.ToDecimal(row["TongThuong"]).ToString("N0") : "0",
                        row["TongPhat"] != DBNull.Value ? Convert.ToDecimal(row["TongPhat"]).ToString("N0") : "0",
                        row["TongTienLuong"] != DBNull.Value ? Convert.ToDecimal(row["TongTienLuong"]).ToString("N0") : "0",

                        // Định dạng lại ngày tháng chốt lương
                        row["NgayChotLuong"] != DBNull.Value ? Convert.ToDateTime(row["NgayChotLuong"]).ToString("dd/MM/yyyy") : "",

                        // Cột Thực lĩnh cuối cùng
                        row["ThucLanh"] != DBNull.Value ? Convert.ToDecimal(row["ThucLanh"]).ToString("N0") : "0"
                    );
                }
            }
        }
    }
}
