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
    public partial class ThemSanPhamNew : Form
    {
        public ThemSanPhamNew()
        {
            InitializeComponent();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
        //close frm
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        BUS_SP sp = new BUS_SP();
        BUS_LSP lsp = new BUS_LSP();
        BUS_NCC ncc = new BUS_NCC();
        BUS_KM km = new BUS_KM();
        
        //frm load tt cbo
        public void load()
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
        }
        private void ThemSanPhamNew_Load(object sender, EventArgs e)
        {
            load();

        }

        //check input du lieu
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

        //Nut luu thong tin
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!kiemTraInput()) return;

            ET_SP et = new ET_SP(
                txtMaSP.Text,
                txtTenSP.Text,
                txtFileName.Text,
                Convert.ToInt32(txtSL.Text),
                cboDVT.SelectedValue.ToString(),
                Convert.ToInt32(txtGiaBan.Text),
                Convert.ToInt32(txtGiaGoc.Text),
                cboLSP.SelectedValue.ToString(),
                cboKM.SelectedValue.ToString(),
                cboNCC.SelectedValue.ToString());
            if (sp.themSP(et))
            {
                MessageBox.Show("Thêm thành công");
            }
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

        private void btnThemLSP_Click(object sender, EventArgs e)
        {
            themLSP themLSPForm = new themLSP();
            themLSPForm.ShowDialog();
            load();
        }

        private void ThemNCC_Click(object sender, EventArgs e)
        {
            ThemNCC themNCCForm = new ThemNCC();
            themNCCForm.ShowDialog();
            load();
        }

        private void ThemDVT_Click(object sender, EventArgs e)
        {
            ThemDVT themDVTForm = new ThemDVT();
            themDVTForm.ShowDialog();
            load();
        }
    }
}
