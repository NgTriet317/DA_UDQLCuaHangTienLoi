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
    public partial class themLSP : Form
    {
        public themLSP()
        {
            InitializeComponent();
        }

        BUS_LSP LSP = new BUS_LSP();
        private void themLSP_Load(object sender, EventArgs e)
        {            
            DataTable dt = LSP.layDSLSP();
            int count = dt.Rows.Count;

            // Tự động tính số tiếp theo và tự bù số 0 (Ví dụ: 1 -> 001, 10 -> 010, 100 -> 100)
            txtMa.Text = $"LSP{(count + 1):D2}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ma = txtMa.Text;
            string ten = txtName.Text;

            if (LSP.themLSP(ma, ten))
            {
                MessageBox.Show("Thêm loại sản phẩm thành công!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm loại sản phẩm thất bại!");
            }
        }
    }
}
