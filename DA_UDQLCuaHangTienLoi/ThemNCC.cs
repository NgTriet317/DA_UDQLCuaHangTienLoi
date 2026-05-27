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
    public partial class ThemNCC : Form
    {
        public ThemNCC()
        {
            InitializeComponent();
        }
        BUS_NCC ncc = new BUS_NCC();
        private void themNCC_Load(object sender, EventArgs e)
        {
            DataTable dt = ncc.layNCC();
            int count = dt.Rows.Count;

            //Tự động tính số tiếp theo và tự bù số 0 (Ví dụ: 1 -> 01, 1 -> 10)
            txtMa.Text = $"NCC{(count + 1):D2}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ma = txtMa.Text;
            string ten = txtName.Text;
            string diaChi = txtDiaChi.Text;
            string sdt = txtTongDai.Text;

            ET_NCC et = new ET_NCC(ma, ten, diaChi, sdt);

            if (ncc.themNCC(et))
            {
                MessageBox.Show("Thêm nhà cung cấp thành công!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm nhà cung cấp thất bại!");
            }
        }        
    }
}
