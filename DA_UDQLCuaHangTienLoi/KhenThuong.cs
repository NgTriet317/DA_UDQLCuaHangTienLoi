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
    public partial class KhenThuong : Form
    {
        public KhenThuong()
        {
            InitializeComponent();
        }

        BUS_KhenThuong kthuong = new BUS_KhenThuong();
        BUS_NHANVIEN nv = new BUS_NHANVIEN();

        private void KhenThuong_Load(object sender, EventArgs e)
        {
            LoadDS();
            cboHoTenNV.DataSource = nv.layDSNhanVienHoatDong();
            cboHoTenNV.DisplayMember = "HoTenNV";
            cboHoTenNV.ValueMember = "MaNV";
            dtpNgayQD.Value = DateTime.Now;
        }

        private void LoadDS()
        {
            DataTable dt = kthuong.LayDSKhenThuong();
            if (dt != null)
            {
                dgvThongTin.Rows.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    dgvThongTin.Rows.Add(
                        dr[0].ToString(),
                        dr[1].ToString(),
                        Convert.ToDateTime(dr[2]).ToString("dd/MM/yyyy"),
                        dr[3].ToString(),
                        Convert.ToInt32(dr[4])
                    );
                }
            }
        }

        public void ClearALL()
        {
            txtMaKT.Clear();
            cboHoTenNV.SelectedIndex = 0;
            dtpNgayQD.Value = DateTime.Now;
            txtTienThuong.Clear();
            rtbNoiDung.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            // 1. Kiểm tra Mã KT
            if (string.IsNullOrWhiteSpace(txtMaKT.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã Khen Thưởng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKT.Focus();
                return;
            }

            // 2. Kiểm tra Nội dung
            if (string.IsNullOrWhiteSpace(rtbNoiDung.Text))
            {
                MessageBox.Show("Vui lòng nhập Nội dung khen thưởng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rtbNoiDung.Focus();
                return;
            }

            // 3. Kiểm tra Số tiền thưởng (Phải là số và không trống)
            if (string.IsNullOrWhiteSpace(txtTienThuong.Text))
            {
                MessageBox.Show("Vui lòng nhập Số tiền thưởng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTienThuong.Focus();
                return;
            }

            if (!decimal.TryParse(txtTienThuong.Text, out decimal soTien) || soTien < 0)
            {
                MessageBox.Show("Số tiền thưởng không hợp lệ (phải là số dương)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTienThuong.Focus();
                return;
            }

            // 4. Ngày quyết định không được nhỏ hơn ngày hiện tại
            if (dtpNgayQD.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Ngày quyết định không được nhỏ hơn ngày hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpNgayQD.Focus();
                return;
            }

            try
            {
                if (kthuong.ThemKhenThuong(new ET_KhenThuong(
                    txtMaKT.Text.ToString(),
                    cboHoTenNV.SelectedValue.ToString(),
                    Convert.ToDateTime(dtpNgayQD.Value.ToString()),
                    rtbNoiDung.Text.ToString(),
                    Convert.ToInt32(txtTienThuong.Text.ToString())
                    )))
                {
                    MessageBox.Show("Thêm khen thưởng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm khen thưởng thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LoadDS();
                ClearALL();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Thông báo");
                return;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearALL();
        }

        private void dgvThongTin_Click(object sender, EventArgs e)
        {

            int dong = dgvThongTin.CurrentCell.RowIndex;
            if (dgvThongTin.Rows[dong].IsNewRow)
            {
                ClearALL();
                return;
            }    
            txtMaKT.Text = dgvThongTin.Rows[dong].Cells[0].Value.ToString();
            cboHoTenNV.Text = dgvThongTin.Rows[dong].Cells[1].Value.ToString();
            dtpNgayQD.Value = Convert.ToDateTime(dgvThongTin.Rows[dong].Cells[2].Value);
            rtbNoiDung.Text = dgvThongTin.Rows[dong].Cells[3].Value.ToString();
            txtTienThuong.Text = dgvThongTin.Rows[dong].Cells[4].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra Mã KT
            if (string.IsNullOrWhiteSpace(txtMaKT.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã Khen Thưởng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKT.Focus();
                return;
            }

            // 2. Kiểm tra Nội dung
            if (string.IsNullOrWhiteSpace(rtbNoiDung.Text))
            {
                MessageBox.Show("Vui lòng nhập Nội dung khen thưởng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rtbNoiDung.Focus();
                return;
            }

            // 3. Kiểm tra Số tiền thưởng (Phải là số và không trống)
            if (string.IsNullOrWhiteSpace(txtTienThuong.Text))
            {
                MessageBox.Show("Vui lòng nhập Số tiền thưởng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTienThuong.Focus();
                return;
            }

            if (!decimal.TryParse(txtTienThuong.Text, out decimal soTien) || soTien < 0)
            {
                MessageBox.Show("Số tiền thưởng không hợp lệ (phải là số dương)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTienThuong.Focus();
                return;
            }

            // 4. Ngày quyết định không được nhỏ hơn ngày hiện tại
            if (dtpNgayQD.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Ngày quyết định không được nhỏ hơn ngày hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpNgayQD.Focus();
                return;
            }

            try
            {
                if (kthuong.SuaKhenThuong(new ET_KhenThuong(
                    txtMaKT.Text.ToString(),
                    cboHoTenNV.SelectedValue.ToString(),
                    Convert.ToDateTime(dtpNgayQD.Value.ToString()),
                    rtbNoiDung.Text.ToString(),
                    Convert.ToInt32(txtTienThuong.Text.ToString())
                    )))
                {
                    MessageBox.Show("Sửa khen thưởng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sửa khen thưởng thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LoadDS();
                ClearALL();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Thông báo");
                return;
            }
        }
    }
}
