using BUS;
using CrystalDecisions.CrystalReports.ViewerObjectModel;
using ET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA_UDQLCuaHangTienLoi
{
    public partial class ThemNhanVien : Form
    {
        public ThemNhanVien()
        {
            InitializeComponent();
        }
        BUS_NHANVIEN nv = new BUS_NHANVIEN();
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Nut hoan thanh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            string role = "User";
            string tenFileAnh = "user.png";
            if (picHinh.Tag != null)
            {
                tenFileAnh = picHinh.Tag.ToString();
            }
            if (cboChucVu.Text == "Quản lý")
            {
                role = "Admin";
            }
            DialogResult result = MessageBox.Show("Bạn có muốn hoàn thành thao tác ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes)
            {
                ET_NHANVIEN et = new ET_NHANVIEN(txtMa.Text, txtHoTen.Text, tenFileAnh, dtpNgaySinh.Value, cboGioiTinh.Text, txtDiaChi.Text, Convert.ToInt32(txtSDT.Text), cboChucVu.SelectedValue.ToString(), txtEmail.Text);

                if (nv.themNhanVien(et))
                {
                    MessageBox.Show("Thêm nhân viên thành công!", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm nhân viên thất bại!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (checkTTk.Checked)
                {
                    nv.taoTaiKhoan(txtEmail.Text, role);                    
                }
            }
        }

        //load thong tin chuc vu len combobox
        private void ThemNhanVien_Load(object sender, EventArgs e)
        {
            cboChucVu.DisplayMember = "TenChucVu";
            cboChucVu.ValueMember = "MaChucVu";
            cboChucVu.DataSource = nv.layAllChucVu();
        }


        //tai hinh anh len picturebox
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog file = new OpenFileDialog())
            {
                file.Filter = "Image files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";

                if (file.ShowDialog() == DialogResult.OK)
                {
                    string tenFileAnh = file.SafeFileName;
                    string duongDanGoc = file.FileName;

                    // Lấy đường dẫn thư mục gốc của app + tạo thư mục AnhNhanVien nếu chưa có
                    string duongDanLuu = @"D:\";                    
                    string thuMucLuu = Path.Combine(duongDanLuu);

                    if (!Directory.Exists(thuMucLuu))
                    {
                        Directory.CreateDirectory(thuMucLuu);
                    }

                    //string duongDanDayDu = Path.Combine(thuMucLuu, tenFileAnh);
                    string duongDanDayDu = Path.Combine(Application.StartupPath, "AnhSanPham", tenFileAnh);

                    try
                    {
                        // Thực hiện copy (chép đè nếu file đã tồn tại)
                        System.IO.File.Copy(duongDanGoc, duongDanDayDu, true);

                        // Hiển thị ảnh lên PictureBox một cách an toàn
                        using (var fs = new System.IO.FileStream(duongDanDayDu, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                        {
                            picHinh.Image = Image.FromStream(fs);
                        }

                        // LƯU Ý QUAN TRỌNG: Lưu tên file vào Tag để nút Hoàn Thành lấy ra xài
                        picHinh.Tag = tenFileAnh;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xử lý ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
