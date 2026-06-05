using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace DA_UDQLCuaHangTienLoi
{
    public partial class frmMain : Form
    {
        public static string maCH = "CH01";
        public static string inActive = "0";
        public static string mail = "";
        public static string chucVu = "";
        public static string chiNhanh = "";        

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
            btnBaoCao.FillColor = SystemColors.MenuHighlight;
            btnNV.FillColor = SystemColors.MenuHighlight;
            btnKhach.FillColor = SystemColors.MenuHighlight;
            btnLuongBong.FillColor = SystemColors.MenuHighlight;
		}

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        //Tạo form con
        private Form current_form_child;
        //Hàm mở form con
        private void OpenChildForm(Form childForm)
        {
            // 1. Ẩn tất cả các form đang hiển thị trong panel_body
            foreach (Control ctrl in panel_body.Controls)
            {
                ctrl.Hide();
            }

            // 2. Nếu Form này chưa từng được thêm vào panel_body thì mới cấu hình và Add vào
            if (!panel_body.Controls.Contains(childForm))
            {
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                panel_body.Controls.Add(childForm);
            }

            // 3. Đưa Form lên trên cùng và hiển thị
            childForm.BringToFront();
            childForm.Show();
        }

        private void panel_body_Paint(object sender, PaintEventArgs e)
        {

        }        
        // Khai báo các biến lưu trữ toàn cục cho tất cả các Form
        private banHang frmBanHang = null;
        private TTSPNew frmSP = null;
        private ThongKeTongQuat frmThongKe = null;
        private NhanVien frmNV = null;
        private KhachHang frmKhach = null;
        private KhoHang frmKho = null;
        private ThongKe frmBaoCao = null;
        private LuongBong frmLuongBong = null;
		private void btnBanHang_Click(object sender, EventArgs e)
        {
            clearColorButton();
            btnBanHang.FillColor = Color.MediumBlue;

            if (frmBanHang == null || frmBanHang.IsDisposed)
                frmBanHang = new banHang(); // Chỉ tạo mới 1 lần

            OpenChildForm(frmBanHang);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            //thoát app và đặt active = 0
            inActive = "0";
            tK.capNhatHoatDong(mail, "Không hoạt động");
            // 1. Yêu cầu Windows mở một phiên bản mới của chính phần mềm này
            System.Diagnostics.Process.Start(Application.ExecutablePath);

			// 2. Ép tắt ngay lập tức phiên bản hiện tại để giải phóng toàn bộ bộ nhớ (Tránh lỗi mảng)
			Environment.Exit(0);
		}

        public static string maNV = "";

        BUS_CUAHANG ch = new BUS_CUAHANG();
        private void Form1_Load(object sender, EventArgs e)
        {
            DataRow drc = ch.layTTCuaHang(maCH).Rows[0];
             
            chiNhanh = drc["DiaChi"].ToString();

            if (mail != string.Empty)
            {
                DataTable dt = tK.timNVOnl(mail);

                DataRow dr = dt.Rows[0];
                maNV = dr["MaNV"].ToString();
                string tenNV = dr["HoTenNV"].ToString();

                txtNV.Text = tenNV;

                txtChucVu.Text = nv.layCHucVu(dr["MaChucVu"].ToString());                
                chucVu = dr["MaChucVu"].ToString();

                if (dr["MaChucVu"].ToString() != "CV01")
                {
                    labelQL.Visible = false;
                    btnNV.Visible = false;
                    btnKhoHang.Visible = false;
                    btnThongKe.Visible = false;
                }
                else
                {
                    labelQL.Visible = true;
                    btnNV.Visible = true;
                    btnKhoHang.Visible = true;
                    btnThongKe.Visible = true;
                    btnLuongBong.Visible = true;
                }
            }

            if(inActive == "1")
            {
                txtActive.Text = "Online";
                tK.capNhatHoatDong(mail,"hoạt động");
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

            if (frmSP == null || frmSP.IsDisposed)
                frmSP = new TTSPNew();

            OpenChildForm(frmSP);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            clearColorButton();
            btnThongKe.FillColor = Color.MediumBlue;

            if (frmThongKe == null || frmThongKe.IsDisposed)
                frmThongKe = new ThongKeTongQuat();

            OpenChildForm(frmThongKe);
        }

        private void btnNV_Click(object sender, EventArgs e)
        {
            clearColorButton();
            btnNV.FillColor = Color.MediumBlue;

            if (frmNV == null || frmNV.IsDisposed)
                frmNV = new NhanVien();

            OpenChildForm(frmNV);
        }

        private void btnKhach_Click(object sender, EventArgs e)
        {
            clearColorButton();
            btnKhach.FillColor = Color.MediumBlue;

            if (frmKhach == null || frmKhach.IsDisposed)
                frmKhach = new KhachHang();

            OpenChildForm(frmKhach);
        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnKhoHang_Click(object sender, EventArgs e)
        {
            clearColorButton();
            btnKhoHang.FillColor = Color.MediumBlue;

            // Giữ nguyên logic truyền maNV của bạn
            KhoHang.maNV = maNV;

            if (frmKho == null || frmKho.IsDisposed)
                frmKho = new KhoHang();

            OpenChildForm(frmKho);
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            clearColorButton();
            btnBaoCao.FillColor = Color.MediumBlue;
            

            if (frmBaoCao == null || frmBaoCao.IsDisposed)
                frmBaoCao = new ThongKe();

            OpenChildForm(frmBaoCao);
        }

        private void btnBaoCao_Paint(object sender, PaintEventArgs e)
        {

        }

		private void btnLuongBong_Click(object sender, EventArgs e)
		{
			clearColorButton();
			btnLuongBong.FillColor = Color.MediumBlue;


			if (frmLuongBong == null || frmLuongBong.IsDisposed)
				frmLuongBong = new LuongBong();

			OpenChildForm(frmLuongBong);
		}
	}
}
