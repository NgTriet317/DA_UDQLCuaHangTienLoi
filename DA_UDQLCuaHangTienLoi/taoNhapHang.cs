using BUS;
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
    public partial class taoNhapHang : Form
    {
        public static string maNV = "";
        public taoNhapHang()
        {
            InitializeComponent();
        }
        BUS_NHAPHANG nh = new BUS_NHAPHANG();
        BUS_KHO kho = new BUS_KHO();
        private void button1_Click(object sender, EventArgs e)
        {
            //Khong cho nhap ki tu dac biet
            if(txtMa.Text.Any(c => !char.IsLetterOrDigit(c)))
            {
                MessageBox.Show("Không nhập ký tự đặc biệt", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMa.Clear();
                return;
            }

            if (nh.themNH(txtMa.Text, maNV, cboKho.SelectedValue.ToString()))
            {                
                NhapHang frm = new NhapHang();
                frm.load();
                this.Close();
            }
            else
            {
                MessageBox.Show("Thất bại");
            }
        }

        private void cboKho_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void taoNhapHang_Load(object sender, EventArgs e)
        {
            cboKho.DisplayMember = "TenKho";
            cboKho.ValueMember = "MaKhoHang";
            cboKho.DataSource = kho.layKho();
        }
    }
}
