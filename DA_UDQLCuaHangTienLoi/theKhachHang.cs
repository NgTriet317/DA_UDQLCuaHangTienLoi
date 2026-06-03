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
    public partial class theKhachHang : UserControl
    {
        private Point originalLocation;
        public string MaKH { get; private set; }
        public string TenKH { get; private set; }
        public string SDT { get; private set; }
        public string DiemTichLuy { get; private set; }
        public string DiemHienTai { get; private set; }
        public string TenRank { get; private set; }

        public theKhachHang(string ma, string ten, string sdt, string diemTichLuy, string diemHienTai, string tenRank)
        {
            InitializeComponent();


            this.MouseEnter += new EventHandler(theKhachHang_MouseEnter);
            this.MouseLeave += new EventHandler(theKhachHang_MouseLeave);


            this.MaKH = ma;
            this.TenKH = ten;
            this.SDT = sdt;
            this.DiemTichLuy = diemTichLuy;
            this.DiemHienTai = diemHienTai;
            this.TenRank = tenRank;

            // Hiển thị dữ liệu
            lblHoTen.Text = ten;
            lblSDT.Text = sdt;
            lblDiemDaTich.Text = diemTichLuy;
            lblDiemHienTai.Text = diemHienTai;
            lblRank.Text = tenRank;

            // GÁN SỰ KIỆN CLICK CHO TẤT CẢ THÀNH PHẦN CON
            this.Click += Control_Click;
            foreach (Control c in this.Controls)
            {
                c.Click += Control_Click;
            }
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

        private void theKhachHang_Load(object sender, EventArgs e)
        {
            originalLocation = this.Location;

            guna2Panel1.Click += Control_Click;
            lblHoTen.Click += Control_Click;
            lblSDT.Click += Control_Click;
            lblDiemDaTich.Click += Control_Click;

            guna2Panel1.MouseEnter += theKhachHang_MouseEnter;
            guna2Panel1.MouseLeave += theKhachHang_MouseLeave;
            lblHoTen.MouseEnter += theKhachHang_MouseEnter;
            lblHoTen.MouseLeave += theKhachHang_MouseLeave;
            panel1.MouseEnter += theKhachHang_MouseEnter;
            lblSDT.MouseEnter += theKhachHang_MouseEnter;
            lblSDT.MouseLeave += theKhachHang_MouseLeave;
            lblDiemDaTich.MouseEnter += theKhachHang_MouseEnter;
            lblDiemDaTich.MouseLeave += theKhachHang_MouseLeave;
        }

        private void theKhachHang_MouseEnter(object sender, EventArgs e)
        {
            guna2Panel1.FillColor = Color.Silver;            
        }

        private void theKhachHang_MouseLeave(object sender, EventArgs e)
        {
            guna2Panel1.FillColor = SystemColors.Control;            
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
