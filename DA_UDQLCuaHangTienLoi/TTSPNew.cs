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
                    dr["MaSP"].ToString(),
                    img,
                    dr["TenSP"].ToString(),
                    lsp.layTenLoai(dr["MaLoaiSP"].ToString()),
                    (dr["SoLuong"].ToString()),
                    (dr["DonGia"].ToString()),
                    sp.layHanSD(dr["MaSP"].ToString()).ToString()
                );


                item.OnViewClicked += (sender, e) =>
                {
                    ViewSanPham viewForm = new ViewSanPham();
                    ViewSanPham.ma = item.MaSP_Data;
                    viewForm.ShowDialog();
                };

                item.OnXoaClicked += (sender, e) =>
                {
                    //xac nhan xoa
                    DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (sp.xoaSP(item.MaSP_Data))
                        {
                            MessageBox.Show("Xóa thành công");
                            HienThiDanhSachSP(sp.layDSSP());
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại");
                        }
                    }
                };


                item.OnUpdateClicked += (sender, e) =>
                {
                    SuaSanPhamNew quanLySPForm = new SuaSanPhamNew();
                    SuaSanPhamNew.ma = item.MaSP_Data;
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

        private void btnThem_Click(object sender, EventArgs e)
        {

            ThemSanPhamNew themSPForm = new ThemSanPhamNew();
            themSPForm.ShowDialog();
            HienThiDanhSachSP(sp.layDSSP());
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                string keyword = txtName.Text.Trim();
                DataTable dtKetQua = sp.findSP(keyword);
                HienThiDanhSachSP(dtKetQua);
            }
        }

        private void cboLSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!isLoaded)
                return;
           
            string maLoaiSP = cboLSP.SelectedValue.ToString();
            DataTable dtKetQua = sp.timSPTheoMaLoai(maLoaiSP);
            HienThiDanhSachSP(dtKetQua);
        }

		private void btnLamMoi_Click(object sender, EventArgs e)
		{
            DataTable dtSanPham = sp.layDSSP();
			HienThiDanhSachSP(dtSanPham);
		}
	}
}
