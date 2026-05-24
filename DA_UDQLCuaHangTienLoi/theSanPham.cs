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
    public partial class theSanPham : UserControl
    {
        public string MaSP { get;private set; }
        public string TenSP { get; private set; }
        public decimal DonGia { get; private set; }

        public string khuyenMai { get; private set; }

        public theSanPham(string ma, string ten, decimal gia, Image hinh, string khuyenMai)
        {
            InitializeComponent();
            this.MaSP = ma;
            this.TenSP = ten;
            this.DonGia = gia;
            this.khuyenMai = khuyenMai;

            // Hiển thị dữ liệu
            lblName.Text = ten;
            lblGia.Text = gia.ToString("N0");
            picImg.Image = hinh;

            // GÁN SỰ KIỆN CLICK CHO TẤT CẢ THÀNH PHẦN CON
            this.Click += Control_Click;
            foreach (Control c in this.Controls)
            {
                c.Click += Control_Click;
            }
        }

        private void picImg_Click(object sender, EventArgs e)
        {

        }

        public event EventHandler SanPhamClicked;

        private void Control_Click(object sender, EventArgs e)
        {
            // Khi bất kỳ cái gì trên thẻ được click, nó sẽ kích hoạt sự kiện này
            if (SanPhamClicked != null)
            {
                SanPhamClicked(this, e);
            }
        }

        private void theSanPham_Load(object sender, EventArgs e)
        {
            // Gắn sự kiện click của Thẻ, Hình ảnh, Label Tên, Label Giá vào chung 1 hàm
            this.Click += Control_Click;
            picImg.Click += Control_Click;
            lblName.Click += Control_Click;
            lblGia.Click += Control_Click;
            // Nếu có Panel nền nào thì cũng gọi Panel.Click += Control_Click luôn nhé
        }
    }
}
