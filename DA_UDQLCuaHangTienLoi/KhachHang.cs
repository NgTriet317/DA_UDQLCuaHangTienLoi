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
    public partial class KhachHang : Form
    {
        BUS_KHACHHANG kh = new BUS_KHACHHANG();
        public static string maKH = "";
        public KhachHang()
        {
            InitializeComponent();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void LoadDanhSachKhachHang()
        {
            int slkh = 0;
            // Xóa các thẻ cũ nếu có để load lại từ đầu
            flpDSKhachHang.Controls.Clear();
            try
            {
                BUS_KHACHHANG kh = new BUS_KHACHHANG();

                DataTable dt = kh.GetAllKhachHang();


                // Duyệt qua từng dòng dữ liệu trong CSDL
                foreach (DataRow row in dt.Rows)
                {
                    string maKH = row["MaKH"].ToString();
                    string tenKH = row["HoTenKH"].ToString();
                    string sdt = row["SDT"].ToString();
                    string diemTichLuy = row["SoDiemDaTich"].ToString();

                    // 1. Tạo một thẻ khách hàng mới (truyền cả MaKH vào để ẩn đi)
                    theKhachHang card = new theKhachHang(maKH, tenKH, sdt, diemTichLuy);

                    // Thêm viền (tùy chọn cho giống ảnh)                    
                    card.Margin = new Padding(20); // Tạo khoảng cách giữa các thẻ

                    card.SanPhamClicked += Card_Clicked;
                    // 2. Thêm thẻ vào FlowLayoutPanel
                    flpDSKhachHang.Controls.Add(card);

                    slkh++;
                }

                lblTong.Text = slkh.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải khách hàng: " + ex.Message);
            }
        }

        private void Card_Clicked(object sender, EventArgs e)
        {
            // Xác định xem thẻ nào vừa bị click
            theKhachHang clickedCard = sender as theKhachHang;
            if (clickedCard == null) return;

            string ma = clickedCard.MaKH;
            string ten = clickedCard.TenKH;
            string sdt = clickedCard.SDT;
            string diemTichLuy = clickedCard.DiemTichLuy;

            txtName.Text = ten;
            txtSDT.Text = sdt;    
            maKH = ma;
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            LoadDanhSachKhachHang();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtSDT.Clear();
            LoadDanhSachKhachHang();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin khách hàng.");
                return;
            }

            if (maKH == "")
            {
                // Thêm mới khách hàng
                ET_KHACHHANG et = new ET_KHACHHANG(txtName.Text, txtSDT.Text,0 , 0, 0);

                bool success = kh.AddKhachHang(et);
                if (success)
                {
                    MessageBox.Show("Thêm khách hàng thành công!");
                    LoadDanhSachKhachHang();

                    btnLamMoi.PerformClick(); // Xóa thông tin sau khi thêm
                }
                else
                {
                    MessageBox.Show("Thêm khách hàng thất bại.");
                }
            }
            else
            {
                // Cập nhật khách hàng
                ET_KHACHHANG et = new ET_KHACHHANG(maKH, txtName.Text, txtSDT.Text,0 , 0,0);   
                bool success = kh.UpdateKhachHang(et);
                if (success)
                {
                    MessageBox.Show("Cập nhật khách hàng thành công!");
                    LoadDanhSachKhachHang();

                    btnLamMoi.PerformClick(); // Xóa thông tin sau khi cập nhật
                    maKH = ""; // Reset mã khách hàng sau khi cập nhật
                }
                else
                {
                    MessageBox.Show("Cập nhật khách hàng thất bại.");
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = kh.SearchKhachHang(txtSearch.Text);
            flpDSKhachHang.Controls.Clear();
            foreach (DataRow row in dt.Rows)
            {
                string maKH = row["MaKH"].ToString();
                string tenKH = row["HoTenKH"].ToString();
                string sdt = row["SDT"].ToString();
                string diemTichLuy = row["SoDiemDaTich"].ToString();

                theKhachHang card = new theKhachHang(maKH, tenKH, sdt, diemTichLuy);
                card.Margin = new Padding(20);
                card.SanPhamClicked += Card_Clicked;
                flpDSKhachHang.Controls.Add(card);
            }
        }

        private void lblTong_Click(object sender, EventArgs e)
        {

        }
    }
}
