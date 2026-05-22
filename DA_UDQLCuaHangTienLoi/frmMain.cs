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
    public partial class frmMain : Form
    {
        public static string inActive = "0";
        public static string mail = "";

        BUS_TK tK = new BUS_TK();
        BUS_NHANVIEN nv = new BUS_NHANVIEN();
        public frmMain()
        {
            InitializeComponent();            
            SetDoubleBuffered(panelNen);
        }
        public static void SetDoubleBuffered(Control control)
        {
            // Sử dụng Reflection để bật DoubleBuffered
            typeof(Control).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, control, new object[] { true });
        }
        public void clearColorButton()
        {
            btnBanHang.FillColor = SystemColors.MenuHighlight;
            btnSP.FillColor = SystemColors.MenuHighlight;
            btnThongKe.FillColor = SystemColors.MenuHighlight;
            btnKhoHang.FillColor = SystemColors.MenuHighlight;
            btnNV.FillColor = SystemColors.MenuHighlight;
            btnKhach.FillColor = SystemColors.MenuHighlight;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        //Tạo form con
        private Form current_form_child;
        //Hàm mở form con
        private void OpenChildForm(Form childForm)
        {
            if(current_form_child!=null)
            {
                current_form_child.Close();
            }
            current_form_child = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock =DockStyle.Fill;
            panel_body.Controls.Add(childForm);
            panel_body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void panel_body_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            //Xóa màu button để đè màu mới và hiện form tương ứng
            clearColorButton();
            btnBanHang.FillColor = Color.MediumBlue;
            OpenChildForm(new banHang());
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            //thoát app và đặt active = 0
            inActive = "0";
			// 1. Yêu cầu Windows mở một phiên bản mới của chính phần mềm này
			System.Diagnostics.Process.Start(Application.ExecutablePath);

			// 2. Ép tắt ngay lập tức phiên bản hiện tại để giải phóng toàn bộ bộ nhớ (Tránh lỗi mảng)
			Environment.Exit(0);
		}

        public static string maNV = "";


        private void Form1_Load(object sender, EventArgs e)
        {
            if(mail != string.Empty)
            {
                DataTable dt = tK.timNVOnl(mail);

                DataRow dr = dt.Rows[0];
                maNV = dr["MaNV"].ToString();
                string tenNV = dr["HoTenNV"].ToString();

                txtNV.Text = tenNV;

                txtChucVu.Text = nv.layCHucVu(dr["MaChucVu"].ToString());
            }

            if(inActive == "1")
            {
                txtActive.Text = "Online";
            }
            else
            {
                txtActive.Text = "Offline";
            }

            //this.Hide();
            //login log = new login();
            //log.Show();
            //OpenChildForm(new banHang());            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnSP_Click(object sender, EventArgs e)
        {
            clearColorButton();
            btnSP.FillColor = Color.MediumBlue;
            OpenChildForm(new TTSPNew());
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            clearColorButton();
            btnThongKe.FillColor = Color.MediumBlue;
            OpenChildForm(new ThongKeTongQuat());
        }

        private void btnNV_Click(object sender, EventArgs e)
        {
            clearColorButton();
            btnNV.FillColor = Color.MediumBlue;
            OpenChildForm(new NhanVien());
        }

        private void btnKhach_Click(object sender, EventArgs e)
        {
            clearColorButton();
            btnKhach.FillColor = Color.MediumBlue;
            OpenChildForm(new KhachHang());
        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnKhoHang_Click(object sender, EventArgs e)
        {
            KhoHang.maNV = maNV;
            clearColorButton();
            btnKhoHang.FillColor = Color.MediumBlue;
            OpenChildForm(new KhoHang());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
