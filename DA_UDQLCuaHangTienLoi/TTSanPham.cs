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

            // 2. LOAD ẢNH MỚI BẰNG CÁCH NHÂN BẢN (Không khóa file)
            if (System.IO.File.Exists(duongDanDayDu))
            {
                using (Image imgTemp = Image.FromFile(duongDanDayDu))
                {
                    picHinh.Image = new Bitmap(imgTemp);
                } // Thoát khỏi using là nhả file gốc ra ngay!
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
