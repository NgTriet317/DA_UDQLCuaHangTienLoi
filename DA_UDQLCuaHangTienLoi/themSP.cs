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
    public partial class themSP : Form
    {
        public themSP()
        {
            InitializeComponent();
        }
        BUS_NCC ncc = new BUS_NCC();
        BUS_LSP lsp = new BUS_LSP();
        BUS_SP sp = new BUS_SP();
        BUS_KM km = new BUS_KM();
        private void btnThem_Click(object sender, EventArgs e)
        {            
             ET_SP et = new ET_SP(txtMaSP.Text,txtTenSP.Text,txtFileName.Text,dtpNgaySX.Value,dtpHanSD.Value,Convert.ToInt32(txtSL.Text), txtDVT.Text, Convert.ToInt32(txtGiaSP.Text),cboLSP.SelectedValue.ToString(),cboKM.SelectedValue.ToString(),cboNCC.SelectedValue.ToString());
             if (sp.themSP(et))
             {
                 MessageBox.Show("Thêm thành công");
             }
             this.Close();
        }
        public void ktThongTin()
        {

        }

        private void btnPickPic_Click(object sender, EventArgs e)
        {
            Image img;
            using(OpenFileDialog file = new OpenFileDialog())
            {
                file.Filter = "png file (*.png)|*.png|jpg file (*.jpg)|*.jpg";

                if(file.ShowDialog() == DialogResult.OK)
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
                            pictureBox1.Image = Image.FromStream(fs);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi copy ảnh: " + ex.Message, "Lỗi");
                    }

                    txtFileName.Text = tenFileAnh;
                    img = Image.FromFile(duongDan);
                    pictureBox1.Image = img;
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();            
        }

        private void themSP_Load(object sender, EventArgs e)
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
        }
    }
}
