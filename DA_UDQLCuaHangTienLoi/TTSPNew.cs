using BUS;
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
using ZXing.Aztec.Internal;

namespace DA_UDQLCuaHangTienLoi
{
    public partial class TTSPNew : Form
    {
        public TTSPNew()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        BUS_SP sp = new BUS_SP();
        BUS_LSP lsp = new BUS_LSP();
        bool isLoaded = false;
        private System.Threading.CancellationTokenSource _cts = null;

        //Hàm hiển thị danh sách sản phẩm lên giao diện, nhận vào một DataTable chứa dữ liệu sản phẩm
        //Khi gọi hàm này, nó sẽ tạo ra các control hiển thị thông tin sản phẩm và thêm vào FlowLayoutPanel
        //Nếu được gọi lại trong khi đang hiển thị, nó sẽ hủy bỏ quá trình hiển thị cũ để tránh lỗi và tăng hiệu suất        
        private async void HienThiDanhSachSP(DataTable dtSanPham)
        {

            if (_cts != null)
            {
                _cts.Cancel(); // Phát tín hiệu hủy
                _cts.Dispose(); // Giải phóng bộ nhớ của bộ phát cũ
            }

            // 2. Tạo một bộ phát tín hiệu MỚI cho lần load này
            _cts = new System.Threading.CancellationTokenSource();

            //Ghi đè lên token cũ bằng token mới
            System.Threading.CancellationToken token = _cts.Token;

            foreach (Control ctrl in flpSP.Controls)
            {
                ctrl.Dispose();
            }
            flpSP.Controls.Clear();

            int index = 0;
            foreach (DataRow dr in dtSanPham.Rows)
            {
                string maSPHienTai = dr["MaSP"].ToString();

                string imagePath = dr["Hinh"].ToString();
                Image img = null;

                string fullPath = Path.Combine(Application.StartupPath, "AnhSanPham", imagePath);
                if (File.Exists(fullPath))
                {
                    img = Image.FromFile(fullPath);
                }

                dgvFakeTTSP item = new dgvFakeTTSP();                

                if (index % 2 == 0)
                {
                    item.BackColor = Color.White;
                }
                else
                {
                    item.BackColor = Color.FromArgb(240, 240, 240);
                }
                item.loadData(
                    maSPHienTai,
                    img,
                    dr["TenSP"].ToString(),
                    lsp.layTenLoai(dr["MaLoaiSP"].ToString()),
                    (dr["SoLuong"].ToString()),
                    (dr["DonGia"].ToString()),
                    sp.layHanSD(dr["MaSP"].ToString()).ToString()
                );

                //gan su kien vao icon view
                item.OnViewClicked += (sender, e) =>
                {
                    ViewSanPham viewForm = new ViewSanPham();
                    ViewSanPham.ma = maSPHienTai;
                    viewForm.ShowDialog();
                };

                //gan su kien vao icon remove
                item.OnXoaClicked += (sender, e) =>
                {
                    if (dr["HoatDong"].ToString() == "Không hoạt động")
                    {
                        MessageBox.Show("Sản phẩm đã ngưng hoạt động, Không thể thao tác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    //xac nhan xoa
                    DialogResult result = MessageBox.Show("Bạn có chắc muốn dừng hoạt động sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (sp.xoaSP(maSPHienTai))
                        {
                            MessageBox.Show("thành công");
                            HienThiDanhSachSP(sp.layDSSP());
                        }
                        else
                        {
                            MessageBox.Show("thất bại");
                        }
                    }
                };

                //gan su kien vao icon update
                item.OnUpdateClicked += (sender, e) =>
                {
                    if (frmMain.chucVu == "CV02")
                    {
                        MessageBox.Show("Bạn không có quyền sửa sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    SuaSanPhamNew quanLySPForm = new SuaSanPhamNew();
                    SuaSanPhamNew.ma = maSPHienTai;
                    quanLySPForm.ShowDialog();
                    HienThiDanhSachSP(sp.layDSSP());
                };
                flpSP.Controls.Add(item);

                index++;

                try
                {
                    await Task.Delay(10, token);
                }
                catch (TaskCanceledException)
                {
                    // Bị hủy trong lúc đang ngủ delay -> Thoát luôn
                    return;
                }
            }
        }

        //load sp moi
        private void TTSPNew_Load(object sender, EventArgs e)
        {

            cboLSP.DisplayMember = "TenLoaiSP";
            cboLSP.ValueMember = "MaLoaiSP";
            cboLSP.DataSource = lsp.layDSLSP();

            HienThiDanhSachSP(sp.layDSSP());

            isLoaded = true;
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        //Open new form Them
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (frmMain.chucVu == "CV02")
            {
                MessageBox.Show("Bạn không có quyền thêm sản phẩm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ThemSanPhamNew themSPForm = new ThemSanPhamNew();
            themSPForm.ShowDialog();
            HienThiDanhSachSP(sp.layDSSP());
        }

        //Tim kiem sp theo ten
        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cboHoatDong.SelectedIndex == 1)
                {
                    DataTable dtKetQua = sp.timSPKHDTheoTen(txtName.Text.Trim());
                    HienThiDanhSachSP(dtKetQua);
                    return;
                }
                else
                {

                    string keyword = txtName.Text.Trim();
                    DataTable dtKetQua = sp.findSP(keyword);
                    HienThiDanhSachSP(dtKetQua);
                }
            }
        }

        //Tim kiem san pham theo loai
        private void cboLSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoaded)
                return;

            string maLoaiSP = cboLSP.SelectedValue.ToString();
            DataTable dtKetQua = sp.timSPTheoMaLoai(maLoaiSP);
            cboHoatDong.SelectedIndex = 0;
            HienThiDanhSachSP(dtKetQua);
        }

        //lam moi san pham
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            DataTable dtSanPham = sp.layDSSP();
            HienThiDanhSachSP(dtSanPham);
        }

        private void cboHoatDong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoaded)
                return;

            if (cboHoatDong.Text == "Hoạt động")
            {
                DataTable dtSanPham = sp.layDSSP();
                HienThiDanhSachSP(dtSanPham);
            }
            else
            {
                DataTable dtSanPham = sp.layDSSPKHD();
                HienThiDanhSachSP(dtSanPham);
            }
        }
    }
}
