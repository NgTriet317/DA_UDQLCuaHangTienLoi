using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA_UDQLCuaHangTienLoi
{
    public partial class KhoHang : Form
    {
        public static string maNV;
        public KhoHang()
        {
            InitializeComponent();
        }

        BUS_KHO kho = new BUS_KHO();
        BUS_SP sp = new BUS_SP();
        private void KhoHang_Load(object sender, EventArgs e)
        {
            cboKhoHang.DataSource = kho.layKho();
            cboKhoHang.DisplayMember = "TenKho";
            cboKhoHang.ValueMember = "MaKhoHang";

            laydsTonkho();
            layDiaChiKho();
        }

        //Hàm lấy địa chỉ kho
        public void layDiaChiKho()
        {                        
            //DataTable dt = kho.layKho();

            //foreach (DataRow dr in dt.Rows)
            //{
            //    if (dr["MaKhoHang"].ToString() == cboKhoHang.SelectedValue.ToString())
            //    {
            //        txtDiaChi.Text = dr["DiaChiKho"].ToString();
            //    }
            //}
            txtDiaChi.Text = kho.layDiaChiKho(cboKhoHang.SelectedValue.ToString());
        }


        //hàm clear bảng
        public void clearbang()
        {
            dgvTTKho.Rows.Clear();
        }


        //Hàm lấy ds tồn kho
        public void laydsTonkho()
        {
            DataTable dt = kho.laySPTonKho();
            string maKho;
            string maSP;
            string tenSP;
            string loaiSP;
            string ncc;
            decimal donGia;
            decimal giaGoc;
            int soLuongTonKho;
            int soLuong;

            foreach (DataRow dr in dt.Rows)
            {
                maKho = dr["MaKhoHang"].ToString();
                if (maKho == cboKhoHang.SelectedValue.ToString())
                {                    
                    maSP = dr["MaSP"].ToString();
                    tenSP = dr["TenSP"].ToString();
                    loaiSP = dr["MaLoaiSP"].ToString();
                    ncc = dr["MaNCC"].ToString();
                    donGia = Convert.ToInt32(dr["DonGia"]);
                    giaGoc = Convert.ToInt32(dr["GiaGoc"]);
                    soLuongTonKho = Convert.ToInt32(dr["SoLuongTonKho"]);
                    soLuong = Convert.ToInt32(dr["SoLuong"]);

                    dgvTTKho.Rows.Add(maSP, tenSP, loaiSP, ncc, donGia, giaGoc, soLuongTonKho, soLuong);
                }
            }
        }

        /// <summary>
        /// Lấy thông tin kho
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvTTKho_Click(object sender, EventArgs e)
        {
            int dong = dgvTTKho.CurrentCell.RowIndex;
            txtTenSP.Text = dgvTTKho.Rows[dong].Cells[0].Value.ToString();
            txtSLTK.Text = dgvTTKho.Rows[dong].Cells[6].Value.ToString();
            txtSLSP.Text = dgvTTKho.Rows[dong].Cells[7].Value.ToString();

        }

        private void dgvTTKho_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        
        private void btnXuatKho_Click(object sender, EventArgs e)
        {
            try
            {
                int slLay = Convert.ToInt32(txtSoLuong.Text.ToString());
                int slTonKho = Convert.ToInt32(txtSLTK.Text.ToString());
                int slSanPham = Convert.ToInt32(txtSLSP.Text.ToString());

                //Tăng giảm SLSP
                kho.updateKho(txtTenSP.Text, slTonKho - slLay);
                sp.updateSLSP(txtTenSP.Text, slSanPham + slLay);

                clearbang();
                laydsTonkho();
            }
            catch
            {
                MessageBox.Show("Hãy chọn 1 hàng trước khi thêm");
            }
            
        }

        //Clear nội dung
        public void clear()
        {
            txtTenSP.Clear();
            txtSLSP.Clear();
            txtSLTK.Clear();
            txtSoLuong.Clear();
        }

        //nút làm mới
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            clear();
            clearbang();
            laydsTonkho();
        }

        //Nhập hàng vào kho
        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            NhapHang nhap = new NhapHang();
            NhapHang.maNV = maNV;
            nhap.ShowDialog();
            clear();
            clearbang();
            laydsTonkho();
        }

        //Chọn kho hàng
        private void cboKhoHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            layDiaChiKho();
            clearbang();
            laydsTonkho();
        }
    }
}
