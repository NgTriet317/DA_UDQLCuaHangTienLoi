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
using ZXing;

namespace DA_UDQLCuaHangTienLoi
{
    public partial class TTSanPham : Form
    {
        public TTSanPham()
        {
            InitializeComponent();
        }        

        BUS_SP sp = new BUS_SP();
        BUS_KM km = new BUS_KM();
        BUS_LSP lsp = new BUS_LSP();
        BUS_NCC ncc = new BUS_NCC();
        public static string role = "";

        private void TTSanPham_Load(object sender, EventArgs e)
        {            
            panel2.Visible = false;
            dgvTT.DataSource = sp.layDSSP();

            string check = role;
            if (check == "Admin")
            {
                btnQuanLy.Visible = true;
                btnThem.Visible = true;
            }
            else
            {
                btnQuanLy.Visible = false;
                btnThem.Visible = false;
            }

            try
            {
                // 1. Lấy toàn bộ danh sách sản phẩm từ CSDL
                BUS_SP sp = new BUS_SP();
                DataTable dt = sp.layDSSP();

                // 2. Tạo đường dẫn thư mục lưu ảnh QR (nằm cùng thư mục chạy của app)
                string folderPath = Path.Combine(Application.StartupPath, "QRCodes");

                // Nếu thư mục chưa tồn tại thì tạo mới
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // 3. Duyệt qua từng sản phẩm và tạo ảnh
                foreach (DataRow row in dt.Rows)
                {
                    string maSP = row["MaSP"].ToString();

                    // Dùng lại hàm TaoMaQR ở Cách 1
                    Bitmap qrCode = TaoMaQR(maSP);

                    // Đường dẫn lưu file: Tên file chính là MaSP.png (Ví dụ: SP001.png)
                    string filePath = Path.Combine(folderPath, maSP + ".png");

                    // Lưu ảnh xuống ổ cứng
                    qrCode.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);

                    // Giải phóng bộ nhớ của biến bitmap để tránh đầy RAM
                    qrCode.Dispose();
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo QR Code hàng loạt: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private Bitmap TaoMaQR(string maSP)
        {
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            barcodeWriter.Format = BarcodeFormat.QR_CODE;

            // Cấu hình kích thước và viền
            barcodeWriter.Options = new ZXing.Common.EncodingOptions
            {
                Width = 200,   // Chiều rộng
                Height = 200,  // Chiều cao
                Margin = 1     // Viền trắng
            };

            // Sinh ảnh và trả về
            return barcodeWriter.Write(maSP);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvTT_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;                       

            int dong = dgvTT.CurrentCell.RowIndex;
            txtMaSP.Text = dgvTT.Rows[dong].Cells[0].Value.ToString();
            txtTenSP.Text = dgvTT.Rows[dong].Cells[1].Value.ToString();
            txtGiaGoc.Text = dgvTT.Rows[dong].Cells[5].Value.ToString();
            txtLoaiSP.Text = lsp.layTenLoai(dgvTT.Rows[dong].Cells[6].Value.ToString());
            txtNCC.Text = ncc.layTenNCC(dgvTT.Rows[dong].Cells[8].Value.ToString());
            txtSL.Text = dgvTT.Rows[dong].Cells[3].Value.ToString();            
            txtGiaSP.Text = dgvTT.Rows[dong].Cells[4].Value.ToString();
            txtDVT.Text = dgvTT.Rows[dong].Cells[9].Value.ToString();
            txtKM.Text = km.layTen(dgvTT.Rows[dong].Cells[7].Value.ToString());


            string qr = Path.Combine(Application.StartupPath, "QRCodes", dgvTT.Rows[dong].Cells[0].Value.ToString())+".png";


            //string thuMucChuaAnh = @"D:\DA_UDQLCuaHangTienLoi\AnhSanPham\";
            string tenFileAnh = dgvTT.Rows[dong].Cells[2].Value.ToString();
            string duongDanDayDu = Path.Combine(Application.StartupPath, "AnhSanPham", tenFileAnh);
            //string duongDanDayDu = Path.Combine(thuMucChuaAnh, tenFileAnh);

            // 1. GIẢI PHÓNG ẢNH CŨ TRƯỚC KHI LOAD ẢNH MỚI (Chống tràn RAM)
            if (picHinh.Image != null)
            {
                picHinh.Image.Dispose();
                picHinh.Image = null;
            }

            if (picQRCode.Image != null)
            {
                picQRCode.Image.Dispose();
                picQRCode.Image = null;
            }

            // 2. LOAD ẢNH MỚI BẰNG CÁCH NHÂN BẢN (Không khóa file)
            if (System.IO.File.Exists(duongDanDayDu))
            {
                using (Image imgTemp = Image.FromFile(duongDanDayDu))
                {
                    picHinh.Image = new Bitmap(imgTemp);
                } // Thoát khỏi using là nhả file gốc ra ngay!
            }

            if (System.IO.File.Exists(qr))
            {
                using (Image imgTemp = Image.FromFile(qr))
                {
                    picQRCode.Image = new Bitmap(imgTemp);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            themSP frm = new themSP();
            frm.ShowDialog();
            dgvTT.DataSource = sp.layDSSP();
            panel2.Visible = false;
        }

        private void btnQuanLy_Click(object sender, EventArgs e)
        {
            string ma = txtMaSP.Text;
            quanLySP frm = new quanLySP();
            quanLySP.ma = ma;
            frm.ShowDialog();
            dgvTT.DataSource = sp.layDSSP();
            panel2.Visible = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dgvTT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
