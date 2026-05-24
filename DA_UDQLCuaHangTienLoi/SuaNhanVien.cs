using BUS;
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
using System.Xaml;

namespace DA_UDQLCuaHangTienLoi
{

    
    public partial class SuaNhanVien : Form
    {
        public static string tenAnhCu = "";
        public SuaNhanVien()
        {
            InitializeComponent();
        }

        public static string manv = "";

        BUS_NHANVIEN nv = new BUS_NHANVIEN();
        
        private void SuaNhanVien_Load(object sender, EventArgs e)
        {
            lblMaNV.Text = manv;
            DataTable dt = nv.layNVTheoMa(manv);

            //load thong tin vao form
            foreach (DataRow dr in dt.Rows)
            {
                string tenFileAnh = dr["Hinh"].ToString();
                //string duongDan = @"D:\";
                string duongDanDayDu = System.IO.Path.Combine(Application.StartupPath,"AnhSanPham", tenFileAnh);

                if (picHinh.Image != null)
                {
                    picHinh.Image.Dispose();
                    picHinh.Image = null;
                }

                if (System.IO.File.Exists(duongDanDayDu))
                {
                    using (Image imgTemp = Image.FromFile(duongDanDayDu))
                    {
                        picHinh.Image = new Bitmap(imgTemp);
                    }
                }

                picHinh.Tag = tenFileAnh;

                txtHoTen.Text = dr["HoTenNV"].ToString();
                dtpDOB.Value = Convert.ToDateTime(dr["NgaySinh"].ToString());
                cboGioiTinh.Text = dr["GioiTinh"].ToString();
                txtDiaChi.Text = dr["DiaChi"].ToString();
                txtSDT.Text = dr["SDT"].ToString();
                txtEmail.Text = dr["Email"].ToString();
            }  

            cboChucVu.DisplayMember = "TenChucVu";
            cboChucVu.ValueMember = "MaChucVu";
            cboChucVu.DataSource = nv.layAllChucVu();
        }
        //timhinh theo ma nhan vien
        public string timHinhTheoMaNV(string manv)
        {
            DataTable dt = nv.layNVTheoMa(manv);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["Hinh"].ToString();
            }
            return null;
        }
        private void btnHoanThanh_Click(object sender, EventArgs e)
        {

            // Kiểm tra dữ liệu nhập vào
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //check email có hợp lệ hay không
            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                MessageBox.Show("Email không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }            
            //Check name hợp lệ
            if (!txtHoTen.Text.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                MessageBox.Show("Họ tên không được chứa số và kí tự đặc biệt!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //check sdt có phải là số hay không
            if (!txtSDT.Text.Any(char.IsDigit) || txtSDT.Text.Length != 10)
            {
                MessageBox.Show("Số điện thoại phải là số và phải đúng 10 số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //check ngày sinh có hợp lệ hay không
            if (dtpDOB.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày sinh không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

            string duongDanOld = Path.Combine(Application.StartupPath, "AnhSanPham", timHinhTheoMaNV(manv));
            string duongDanDayDu = Path.Combine(Application.StartupPath, "AnhSanPham", tenFileAnh);

            //xac nhan cap  nhat thong tin nhan vien
            DialogResult result = MessageBox.Show("Bạn có muốn hoàn thành thao tác ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes)
            {
                ET_NHANVIEN et = new ET_NHANVIEN(lblMaNV.Text, txtHoTen.Text, tenFileAnh, dtpDOB.Value, cboGioiTinh.Text, txtDiaChi.Text, Convert.ToInt32(txtSDT.Text), cboChucVu.SelectedValue.ToString(), txtEmail.Text);

                if (nv.suaNhanVien(et))
                {
                    MessageBox.Show("Cập nhật thông tin nhân viên thành công!", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Thêm nhân viên thất bại!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }            
        }
        //nut huy
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //cap nhat hinh anh
        private void btnDoiHinh_Click(object sender, EventArgs e)
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
                    //string thuMucLuu = Path.Combine(Application.StartupPath, "AnhNhanVien");
                    string thuMucLuu = Path.Combine(duongDanLuu);
                    if (!Directory.Exists(thuMucLuu))
                    {
                        Directory.CreateDirectory(thuMucLuu);
                    }

                    string duongDanDayDu = Path.Combine(thuMucLuu, tenFileAnh);

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
