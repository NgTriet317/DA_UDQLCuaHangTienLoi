using BUS;
using ET;
using Guna.UI2.WinForms;
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

    public partial class hienthiNVien : Form
    {
        public static string manv = "";

        public hienthiNVien()
        {
            InitializeComponent();
            SetDoubleBuffered(tableLayoutPanel1);
        }
        public static void SetDoubleBuffered(Control control)
        {
            // Sử dụng Reflection để bật DoubleBuffered
            typeof(Control).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, control, new object[] { true });
        }
        BUS_NHANVIEN nv = new BUS_NHANVIEN();

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void hienthiNVien_Load(object sender, EventArgs e)
        {
            cboChucVu.DisplayMember = "TenChucVu";
            cboChucVu.ValueMember = "MaChucVu";
            cboChucVu.DataSource = nv.layAllChucVu();
            cboChucVu.SelectedIndex = 0;
            HienThiDanhSachNhanVien(nv.timKiemNhanVienKoTuKhoa(cboTrangThai.Text, cboChucVu.SelectedValue.ToString()));



        }

        /// <summary>
        /// hien thi ds nhan vien
        /// </summary>
        private void HienThiDanhSachNhanVien(DataTable dtNhanVien)
        {

            foreach (Control ctrl in flpDSNV.Controls)
            {
                ctrl.Dispose();
            }
            flpDSNV.Controls.Clear();


            foreach (DataRow dr in dtNhanVien.Rows)
            {


                dgvFakeNhanVien item = new dgvFakeNhanVien();
                item.LoadData(
                    dr["MaNV"].ToString(),
                    dr["HoTenNV"].ToString(),
                    dr["GioiTInh"].ToString(),
                    nv.layCHucVu(dr["MaChucVu"].ToString())
                );


                item.OnRowClicked += (sender, e) =>
                {
                    string maClick = item.MaNV_Data;


                    DataTable fnv = nv.layNVTheoMa(maClick);

                    foreach (DataRow fnvr in fnv.Rows)
                    {
                        string tenFileAnh = fnvr["Hinh"].ToString();
                        //string duongDan = @"D:\";
                        //string duongDanDayDu = System.IO.Path.Combine(duongDan, tenFileAnh);
                        string duongDanDayDu = Path.Combine(Application.StartupPath, "AnhSanPham", tenFileAnh);

                        if (picHinh.Image != null)
                        {
                            picHinh.Image.Dispose();
                            picHinh.Image = null;
                        }

                        if (System.IO.File.Exists(duongDanDayDu))
                        {
                            using (Image imgTemp = Image.FromFile(duongDanDayDu))
                            {
                                picHinh.Image = new Bitmap(imgTemp);
                            }
                        }

                        lblMaNV.Text = fnvr["MaNV"].ToString();
                        lblHoTen.Text = fnvr["HoTenNV"].ToString();
                        lblNgaySinh.Text = fnvr["NgaySinh"].ToString();
                        lblGioiTinh.Text = fnvr["GioiTinh"].ToString();
                        lblDiaChi.Text = fnvr["DiaChi"].ToString();
                        lblSDT.Text = fnvr["SDT"].ToString();
                        lblChucVu.Text = nv.layCHucVu(fnvr["MaChucVU"].ToString());
                        lblEmail.Text = fnvr["Email"].ToString();
                        lblNgayVaoLam.Text = fnvr["NgayBatDau"].ToString();
                        lblThamNien.Text = fnvr["ThamNien"].ToString() + " Năm";

                        if (fnvr["HoatDong"].ToString() == "Hoạt Động")
                        {
                            btnKhoiPhuc.Visible= false;
                        }
                        else
                        {
                            btnKhoiPhuc.Visible = true;
                        }
                    }
                };

                item.OnXoaClicked += (sender, e) =>
                {
                    DialogResult dialog = MessageBox.Show($"Bạn có chắc muốn xóa nhân viên {item.MaNV_Data} không?", "Xác nhận", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        if (nv.xoaNhanVien(item.MaNV_Data))
                        {
                            MessageBox.Show("Xóa thành công!");
                        }
                        else
                        {
                            MessageBox.Show("Xóa Khong thành công");
                        }

                        // Load lại danh sách sau khi xóa
                        HienThiDanhSachNhanVien(nv.timKiemNhanVienKoTuKhoa(cboTrangThai.Text, cboChucVu.SelectedValue.ToString()));
                        refresh();
                    }
                };
                

                item.OnUpdateClicked += (sender, e) =>
                {
                    SuaNhanVien.manv = item.MaNV_Data;
                    
                    SuaNhanVien snv = new SuaNhanVien();
                    snv.ShowDialog();

                    HienThiDanhSachNhanVien(nv.timKiemNhanVienKoTuKhoa(cboTrangThai.Text, cboChucVu.SelectedValue.ToString()));
                };
                flpDSNV.Controls.Add(item);

            }
        }
        public void refresh()
        {
            lblMaNV.Text = "Mã nhân viên";
            lblHoTen.Text = "Họ tên";
            lblNgaySinh.Text = "Ngày sinh";
            lblGioiTinh.Text = "Giới tính";
            lblDiaChi.Text = "Địa chỉ";
            lblSDT.Text = "Số điện thoại";
            lblChucVu.Text = "Chức vụ";
            lblEmail.Text = "Email";
            lblNgayVaoLam.Text = "Ngày vào làm";
            lblThamNien.Text = "Thâm niên";
        }   
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ThemNhanVien themNV = new ThemNhanVien();
            themNV.ShowDialog();
            refresh();

            HienThiDanhSachNhanVien(nv.timKiemNhanVienKoTuKhoa(cboTrangThai.Text, cboChucVu.SelectedValue.ToString()));
        }

        /// <summary>
        /// Tim kiem nhan vien theo chuc vu va trang thai
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            refresh();
            HienThiDanhSachNhanVien(nv.timKiemNhanVienKoTuKhoa(cboTrangThai.Text, cboChucVu.SelectedValue.ToString()));
        }

        private void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            refresh();
            HienThiDanhSachNhanVien(nv.timKiemNhanVienKoTuKhoa(cboTrangThai.Text, cboChucVu.SelectedValue.ToString()));
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            refresh();
            HienThiDanhSachNhanVien(nv.timKiemNhanVienCoTuKhoa(cboTrangThai.Text, cboChucVu.SelectedValue.ToString(), txtTimKiem.Text));
        }


        //khoi phuc nhan vien da xoa
        private void btnKhoiPhuc_Click(object sender, EventArgs e)
        {
            if (nv.khoiPhucNhanVien(lblMaNV.Text))
            {
                MessageBox.Show("Khôi phục thành công","Thông báo");
                refresh();
                HienThiDanhSachNhanVien(nv.timKiemNhanVienKoTuKhoa(cboTrangThai.Text, cboChucVu.SelectedValue.ToString()));
            }
        }
    }
}
