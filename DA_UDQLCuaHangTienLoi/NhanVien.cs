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
    public partial class NhanVien : Form
    {
        public NhanVien()
        {
            InitializeComponent();
            SetDoubleBuffered(pnMainNV);

        }

        public static void SetDoubleBuffered(Control control)
        {
            typeof(Control).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, control, new object[] { true });
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //Tạo form con
        private Form current_form_child;
        //Hàm mở form con
        // Hàm mở form con đã được tối ưu chống giật/co rút Form cha
        private void OpenChildForm(Form childForm)
        {
            if (current_form_child != null)
            {
                current_form_child.Close();
                current_form_child.Dispose(); // Bắt buộc Dispose để giải phóng RAM các control Guna cũ
            }

            current_form_child = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // 1. BẮT CẢ FORM CHA VÀ FORM CON TẠM DỪNG VẼ GIAO DIỆN
            pnMainNV.SuspendLayout();
            childForm.SuspendLayout();

            // 2. Thêm form con vào Panel một cách "âm thầm"
            pnMainNV.Controls.Clear();
            pnMainNV.Controls.Add(childForm);
            pnMainNV.Tag = childForm;

            // 3. KHÔI PHỤC VẼ GIAO DIỆN (Chú ý từ khóa 'true')
            childForm.ResumeLayout(false);
            pnMainNV.ResumeLayout(true); // Tham số 'true' ép Panel phải tính toán xong xuôi kích thước TRƯỚC KHI hiện

            // 4. HIỂN THỊ SAU CÙNG (Lúc này WinForms đã tính toán xong, sẽ không bị Panic nữa)
            childForm.BringToFront();
            childForm.Show();

            // 5. Giải pháp chốt chặn cuối cùng: Ép Form cha nằm yên ở Maximized
            if (this.WindowState != FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }
        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void pnMainNV_Paint(object sender, PaintEventArgs e)
        {

        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            OpenChildForm(new hienthiNVien());
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new hienthiNVien());
            btnCaLam.FillColor = Color.DarkGray;
            btnNhanVien.FillColor = Color.Gainsboro;
        }

        private void btnCaLam_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DanhSachCaLam());
            btnNhanVien.FillColor = Color.DarkGray;
            btnCaLam.FillColor = Color.Gainsboro;
        }
    }
}
