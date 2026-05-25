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

namespace DA_UDQLCuaHangTienLoi
{
    public partial class SuaSanPhamNew : Form
    {

        public static string ma = "";

        private string tenAnhCu = "";
        private string duongDanAnhMoi = "";
        private bool coThayDoiAnh = false;

        BUS_NCC ncc = new BUS_NCC();
        BUS_LSP lsp = new BUS_LSP();
        BUS_SP sp = new BUS_SP();
        BUS_KM km = new BUS_KM();
        public SuaSanPhamNew()
        {
            InitializeComponent();
        }

        public bool kiemTraInput()
        {
            if (string.IsNullOrEmpty(txtMaSP.Text) ||
                string.IsNullOrEmpty(txtTenSP.Text) ||
                string.IsNullOrEmpty(txtSL.Text) ||
                string.IsNullOrEmpty(txtGiaBan.Text) ||
                string.IsNullOrEmpty(txtGiaGoc.Text) ||
                string.IsNullOrEmpty(txtFileName.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!int.TryParse(txtSL.Text, out _) || !int.TryParse(txtGiaBan.Text, out _) || !int.TryParse(txtGiaGoc.Text, out _))
            {
                MessageBox.Show("Số lượng và giá phải là số nguyên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public string catChuoi(string so)
        {
            if (so.Contains(","))
            {
                return so.Split(',')[0];
            }
            else if (so.Contains("."))
            {
                return so.Split('.')[0];
            }
            return so;
        }

        private void SuaSanPhamNew_Load(object sender, EventArgs e)
        {
            cboLSP.DataSource = lsp.layDSLSP();
            cboLSP.DisplayMember = "TenLoaiSP";
            cboLSP.ValueMember = "MaLoaiSP";

            cboKM.DataSource = km.LayDSKM();
            cboKM.DisplayMember = "TenKM";
            cboKM.ValueMember = "MaKM";

            cboNCC.DataSource = ncc.layNCC();
            cboNCC.DisplayMember = "TenNCC";
            cboNCC.ValueMember = "MaNCC";

            cboDVT.DataSource = sp.layAllDVT();
            cboDVT.DisplayMember = "TenDVT";
            cboDVT.ValueMember = "MaDVT";


            string masp = ma;
            //string thuMucChuaAnh = @"D:\DA_UDQLCuaHangTienLoi\AnhSanPham\";

            DataTable dt = sp.findSPMa(masp);

            foreach (DataRow dr in dt.Rows)
            {
                txtMaSP.Text = dr["MaSP"].ToString();
                txtTenSP.Text = dr["TenSP"].ToString();

                // Vì ComboBox đã có danh sách ở Bước 1, nên lúc này gán SelectedValue mới có tác dụng!
                cboLSP.SelectedValue = dr["MaLoaiSP"].ToString();
                cboNCC.SelectedValue = dr["MaNCC"].ToString();
                cboKM.SelectedValue = dr["MaKM"].ToString();

                txtSL.Text = (dr["SoLuong"].ToString());
                txtGiaGoc.Text = catChuoi(dr["GiaGoc"].ToString());
                txtGiaBan.Text = catChuoi(dr["DonGia"].ToString());
                cboDVT.Text = dr["MaDVT"].ToString();
                txtFileName.Text = dr["Hinh"].ToString();
                tenAnhCu = dr["Hinh"].ToString();

                // BƯỚC 3: LOAD ẢNH AN TOÀN (Không khóa file)
                string duongDanDayDu = Path.Combine(Application.StartupPath, "AnhSanPham", dr["Hinh"].ToString());
                //string duongDanDayDu = Path.Combine(thuMucChuaAnh, dr["Hinh"].ToString());

                // Luôn kiểm tra file tồn tại để chống văng app nếu ai đó lỡ tay xóa ảnh trong folder
                if (System.IO.File.Exists(duongDanDayDu))
                {
                    // Đọc file ảnh gốc vào một biến tạm
                    using (Image imgTemp = Image.FromFile(duongDanDayDu))
                    {
                        // Tạo một bản sao (Bitmap) trên RAM và gán cho PictureBox
                        picHinh.Image = new Bitmap(imgTemp);

                    } // Vừa ra khỏi ngoặc nhọn này là imgTemp bị hủy, nhả file vật lý ra ngay lập tức!
                }
                else
                {
                    picHinh.Image = null;
                }
            }
        }

        /*Nút xác nhận lưu dữ liệu sau khi sửa
         * Sẽ ngưng hoạt động nếu các thông tin chưa được điền đầu đủ hoặc sai định dạng (Số lượng, Giá phải là số)
         * Nếu update DB thành công và có thay đổi ảnh -> sẽ xử lý file ảnh (Copy ảnh mới vào thư mục, xóa ảnh cũ nếu tên khác nhau)
         */
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!kiemTraInput()) return;

            // Tạo đối tượng lấy dữ liệu từ giao diện
            ET_SP et = new ET_SP(txtMaSP.Text, txtTenSP.Text, txtFileName.Text, Convert.ToInt32(txtSL.Text), cboDVT.SelectedValue.ToString(), Convert.ToInt32(txtGiaBan.Text.Split(',')[0]), Convert.ToInt32(txtGiaGoc.Text.Split(',')[0]), cboLSP.SelectedValue.ToString(), cboKM.SelectedValue.ToString(), cboNCC.SelectedValue.ToString());
            //xác nhận có muốn sửa hay không                
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn sửa thông tin sản phẩm này không?", "Xác nhận sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                return; // Nếu người dùng chọn No, thoát khỏi sự kiện mà không làm gì
            }


            // 1. GỌI LỆNH UPDATE DATABASE TRƯỚC
            if (sp.suaSP(et))
            {               

                // 2. NẾU UPDATE DB THÀNH CÔNG VÀ CÓ THAY ĐỔI ẢNH -> XỬ LÝ FILE
                if (coThayDoiAnh == true)
                {
                    //string thuMucAnh = @"D:\DA_UDQLCuaHangTienLoi\AnhSanPham";
                    //string oldDuongDan = System.IO.Path.Combine(thuMucAnh, tenAnhCu);
                    //string newDuongDan = System.IO.Path.Combine(thuMucAnh, txtFileName.Text);
                    string duongDanOld = Path.Combine(Application.StartupPath, "AnhSanPham", tenAnhCu);
                    string duongDanDayDu = Path.Combine(Application.StartupPath, "AnhSanPham", txtFileName.Text);

                    try
                    {
                        // Bước 2.1: Copy ảnh mới vào thư mục (chép đè nếu vô tình trùng tên)
                        System.IO.File.Copy(duongDanAnhMoi, duongDanDayDu, true);

                        // Bước 2.2: Xóa file ảnh cũ (Chỉ xóa nếu tên khác nhau)
                        if (!string.IsNullOrEmpty(tenAnhCu) && tenAnhCu != txtFileName.Text)
                        {
                            // Tránh trường hợp đang bị PictureBox ôm giữ (dù xác suất thấp)
                            if (picHinh.Image != null)
                            {
                                picHinh.Image.Dispose();
                                picHinh.Image = null;
                            }

                            if (System.IO.File.Exists(duongDanOld))
                            {
                                System.IO.File.Delete(duongDanOld); // Bắn bỏ file cũ
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Cập nhật thông tin thành công, nhưng lỗi khi xử lý file ảnh: " + ex.Message, "Cảnh báo");
                    }                    
                }

                MessageBox.Show("Sửa thông tin sản phẩm thành công!", "Thông báo");
            }
            else
            {
                MessageBox.Show("Sửa thất bại! Vui lòng kiểm tra lại thông tin.", "Lỗi");
            }

            this.Close(); // Đóng Form Sửa lại
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            Image img;
            using (OpenFileDialog file = new OpenFileDialog())
            {
                file.Filter = "png file (*.png)|*.png|jpg file (*.jpg)|*.jpg";

                if (file.ShowDialog() == DialogResult.OK)
                {
                    string tenFileAnh = file.SafeFileName;
                    string duongDan = file.FileName;

                    string duongDanDayDu = Path.Combine(Application.StartupPath, "AnhSanPham", tenFileAnh);
                    //string thuMucĐaCo = @"D:\DA_UDQLCuaHangTienLoi\AnhSanPham";
                    //string newDuongDan = System.IO.Path.Combine(thuMucĐaCo, tenFile);

                    try
                    {
                        // Thực hiện copy (chép đè nếu file đã tồn tại)
                        System.IO.File.Copy(duongDan, duongDanDayDu, true);

                        // Hiển thị ảnh lên PictureBox một cách an toàn
                        using (var fs = new System.IO.FileStream(duongDanDayDu, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                        {
                            picHinh.Image = Image.FromStream(fs);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi copy ảnh: " + ex.Message, "Lỗi");
                    }

                    txtFileName.Text = tenFileAnh;
                    img = Image.FromFile(duongDan);
                    picHinh.Image = img;
                }
            }
        }
    }
}
