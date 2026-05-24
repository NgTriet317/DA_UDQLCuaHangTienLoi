using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA_UDQLCuaHangTienLoi
{
    public partial class ViewSanPham : Form
    {

        public static string ma = "";
        public ViewSanPham()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        BUS_SP sp = new BUS_SP();
        BUS_LSP lsp = new BUS_LSP();
        BUS_KM km = new BUS_KM();
        BUS_NCC ncc = new BUS_NCC();

        private void loadSP()
        {
            DataTable dt = sp.findSPMa(ma);

            foreach (DataRow dr in dt.Rows)
            {
                Image img = null;
                string imageName = dr["Hinh"]?.ToString();
                string full = Path.Combine(Application.StartupPath, "AnhSanPham", imageName ?? "");


                if (File.Exists(full))
                {
                    img = Image.FromFile(full);
                }

                picHinh.Image = img;

                lblMaSP.Text = dr["MaSP"].ToString();
                txtName.Text = dr["TenSP"].ToString();
                lblGiaBan.Text = dr["DonGia"].ToString();
                lblDVT.Text = sp.layDVT(dr["MaDVT"].ToString());
                lblGiaGoc.Text = dr["GiaGoc"].ToString();
                lblSoLuong.Text = dr["SoLuong"].ToString();

                lblMaLoai.Text = dr["MaLoaiSP"].ToString();
                lblTenLoai.Text = lsp.layTenLoai(dr["MaLoaiSP"].ToString());

                lblMaNCC.Text = dr["MaNCC"].ToString();
                lblTenNCC.Text = ncc.layTenNCC(dr["MaNCC"].ToString());

                lblMaKM.Text = dr["MaKM"].ToString();
                lblTenKM.Text = km.layTen(dr["MaKM"].ToString());

                lblNSX.Text = sp.layNgaySX(dr["MaSP"].ToString()).ToString().Split(' ')[0];
                lblHSD.Text = sp.layHanSD(dr["MaSP"].ToString()).ToString().Split(' ')[0];

            }
        }
            
        private void ViewSanPham_Load(object sender, EventArgs e)
        {
            loadSP();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(frmMain.chucVu != "CV01")
            {
                MessageBox.Show("Bạn không có quyền sửa sản phẩm này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SuaSanPhamNew quanLySPForm = new SuaSanPhamNew();
            SuaSanPhamNew.ma = ma;
            quanLySPForm.ShowDialog(); 
            loadSP();
        }
    }
}
