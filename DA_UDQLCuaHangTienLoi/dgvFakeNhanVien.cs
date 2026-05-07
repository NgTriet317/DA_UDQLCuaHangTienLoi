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
    public partial class dgvFakeNhanVien : UserControl
    {
        public dgvFakeNhanVien()
        {
            InitializeComponent();

            this.Click += Item_Clicked;
            lblMaNV.Click += Item_Clicked;
            lblTenNV.Click += Item_Clicked;
            lblGioiTinh.Click += Item_Clicked;
            lblChucVu.Click += Item_Clicked;
            guna2Panel1.Click += Item_Clicked;
        }

        // 1. Tạo một sự kiện (Event) để Form chính biết khi nào nút Xóa được bấm
        public event EventHandler OnXoaClicked;
        public event EventHandler OnUpdateClicked;
        public event EventHandler OnRowClicked;


        // 2. Biến để lưu trữ Mã NV(dùng để truy vấn Database khi xóa)
        public string MaNV_Data { get; private set; }        

        //truyền dữ liệu vào hiển thị
        public void LoadData(string maNV, string hoTen, string gioiTinh, string maChucVu)
        {
            this.MaNV_Data = maNV;
            
            lblMaNV.Text = maNV;
            lblTenNV.Text = hoTen;
            lblGioiTinh.Text = gioiTinh;
            lblChucVu.Text = maChucVu;
        }

        private void Item_Clicked(object sender, EventArgs e)
        {
            if (OnRowClicked != null)
            {
                OnRowClicked.Invoke(this, EventArgs.Empty);
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Khi nút Xóa trên UserControl được bấm, nó sẽ gọi Event
            // để Form chính nghe thấy và thực hiện việc xóa Database.
            if (OnXoaClicked != null)
            {
                OnXoaClicked.Invoke(this, EventArgs.Empty);
            }
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {            
            if (OnUpdateClicked != null)
            {
                OnUpdateClicked.Invoke(this, EventArgs.Empty);
            }
        }

        private void guna2Panel1_Click(object sender, EventArgs e)
        {
            hienthiNVien.manv=lblMaNV.Text;
        }
    }
}
