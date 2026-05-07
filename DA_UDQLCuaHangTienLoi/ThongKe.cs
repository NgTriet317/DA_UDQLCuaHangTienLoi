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
    public partial class ThongKe : Form
    {
        public ThongKe()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ThongKe_Load(object sender, EventArgs e)
        {

        }
        private Form current_form_child;
        private void OpenChildForm(Form childForm)
        {
            if (current_form_child != null)
            {
                current_form_child.Close();
            }
            current_form_child = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnHienThi.Controls.Add(childForm);
            pnHienThi.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new InDoanhThuNgay());
        }

        private void pnHienThi_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDoanhThuThang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new InDoanhThuThang());
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new InThongKeNhapHang());
        }
    }
}
