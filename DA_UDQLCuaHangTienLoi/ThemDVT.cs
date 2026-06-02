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
    public partial class ThemDVT : Form
    {
        public ThemDVT()
        {
            InitializeComponent();
        }

        BUS_DVT dvt = new BUS_DVT();
        private void ThemDVT_Load(object sender, EventArgs e)
        {
            DataTable dt = dvt.layAllDVT();
            int count = dt.Rows.Count;

            // Tự động tính số tiếp theo và tự bù số 0 (Ví dụ: 1 -> 001, 10 -> 010, 100 -> 100)
            txtMa.Text = $"DVT{(count + 1):D2}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ma = txtMa.Text;
            string ten = txtName.Text;
            

            ET_DVT et = new ET_DVT(ma, ten);

            if (dvt.them(et))
            {
                MessageBox.Show("Thêm đơn vị tính thành công!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm đơn vị tính thất bại!");
            }
        }
    }
}
