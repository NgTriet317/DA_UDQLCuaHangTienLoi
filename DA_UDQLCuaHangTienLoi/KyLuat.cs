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
    public partial class KyLuat : Form
    {
        public KyLuat()
        {
            InitializeComponent();
        }

        BUS_KyLuat kl = new BUS_KyLuat();
        BUS_NHANVIEN nv = new BUS_NHANVIEN();

        private void KyLuat_Load(object sender, EventArgs e)
        {
            LoadDS();
            cboHoTenNV.DataSource = nv.layDSNhanVienHoatDong();
            cboHoTenNV.DisplayMember = "HoTenNV";
            cboHoTenNV.ValueMember = "MaNV";
            dtpNgayVP.Value = DateTime.Now;
        }

        private void LoadDS()
        {
            DataTable dt = kl.LayDSKyLuat();
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
                        dr[4].ToString(),
                        Convert.ToInt32(dr[5])
                    );
                }
            }
        }

        private void ClearAll()
        {
            txtMaKL.Clear();
            cboHoTenNV.SelectedIndex = 0;
            dtpNgayVP.Value = DateTime.Now;
            txtHinhThuc.Clear();
            txtTienPhat.Clear();
            rtbNoiDung.Clear();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra Mã KT
            if (string.IsNullOrWhiteSpace(txtMaKL.Text))
            {
                MessageBox.Show("Vui lòng nhập mã Kỷ Luật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKL.Focus();
                return;
            }

            // 2. Kiểm tra Hình thức
            if (string.IsNullOrWhiteSpace(txtHinhThuc.Text))
            {
                MessageBox.Show("Vui lòng nhập hình thức Kỷ Luật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKL.Focus();
                return;
            }

            // 3. Kiểm tra Nội dung
            if (string.IsNullOrWhiteSpace(rtbNoiDung.Text))
            {
                MessageBox.Show("Vui lòng nhập nội dung Kỷ Luật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rtbNoiDung.Focus();
                return;
            }

            // 4. Kiểm tra Số tiền phạt (Phải là số và không trống)
            if (string.IsNullOrWhiteSpace(txtTienPhat.Text))
            {
                MessageBox.Show("Vui lòng nhập Số tiền phạt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTienPhat.Focus();
                return;
            }

            if (!decimal.TryParse(txtTienPhat.Text, out decimal soTien) || soTien < 0)
            {
                MessageBox.Show("Số tiền phạt không hợp lệ (phải là số dương)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTienPhat.Focus();
                return;
            }

            // 5. Ngày vi phạm không được nhỏ hơn ngày hiện tại
            if (dtpNgayVP.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Ngày vi phạm không được nhỏ hơn ngày hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpNgayVP.Focus();
                return;
            }

            try
            {
                if (kl.ThemKyLuat(new ET_KyLuat(
                    txtMaKL.Text.ToString(),
                    cboHoTenNV.SelectedValue.ToString(),
                    Convert.ToDateTime(dtpNgayVP.Value.ToString()),
                    txtHinhThuc.Text.ToString(),
                    rtbNoiDung.Text.ToString(),
                    Convert.ToInt32(txtTienPhat.Text.ToString())
                    )))
                {
                    MessageBox.Show("Thêm Kỷ Luật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDS();
                    ClearAll();
                }
                else
                {
                    MessageBox.Show("Thêm Kỷ Luật thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Thông báo");
                return;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra Mã KT
            if (string.IsNullOrWhiteSpace(txtMaKL.Text))
            {
                MessageBox.Show("Vui lòng nhập mã Kỷ Luật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKL.Focus();
                return;
            }

            // 2. Kiểm tra Hình thức
            if (string.IsNullOrWhiteSpace(txtHinhThuc.Text))
            {
                MessageBox.Show("Vui lòng nhập hình thức Kỷ Luật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKL.Focus();
                return;
            }

            // 3. Kiểm tra Nội dung
            if (string.IsNullOrWhiteSpace(rtbNoiDung.Text))
            {
                MessageBox.Show("Vui lòng nhập nội dung Kỷ Luật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rtbNoiDung.Focus();
                return;
            }

            // 4. Kiểm tra Số tiền phạt (Phải là số và không trống)
            if (string.IsNullOrWhiteSpace(txtTienPhat.Text))
            {
                MessageBox.Show("Vui lòng nhập Số tiền phạt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTienPhat.Focus();
                return;
            }

            if (!decimal.TryParse(txtTienPhat.Text, out decimal soTien) || soTien < 0)
            {
                MessageBox.Show("Số tiền phạt không hợp lệ (phải là số dương)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTienPhat.Focus();
                return;
            }

            // 5. Ngày vi phạm không được nhỏ hơn ngày hiện tại
            if (dtpNgayVP.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Ngày vi phạm không được nhỏ hơn ngày hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpNgayVP.Focus();
                return;
            }

            try
            {
                if (kl.SuaKyLuat(new ET_KyLuat(
                    txtMaKL.Text.ToString(),
                    cboHoTenNV.SelectedValue.ToString(),
                    Convert.ToDateTime(dtpNgayVP.Value.ToString()),
                    txtHinhThuc.Text.ToString(),
                    rtbNoiDung.Text.ToString(),
                    Convert.ToInt32(txtTienPhat.Text.ToString())
                    )))
                {
                    MessageBox.Show("Sửa Kỷ Luật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDS();
                    ClearAll();
                }
                else
                {
                    MessageBox.Show("Sửa Kỷ Luật thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Thông báo");
                return;
            }
        }

        private void dgvThongTin_Click(object sender, EventArgs e)
        {
            int dong = dgvThongTin.CurrentCell.RowIndex;
            if (dgvThongTin.Rows[dong].IsNewRow)
            {
                ClearAll();
                return;
            }
            txtMaKL.Text = dgvThongTin.Rows[dong].Cells[0].Value.ToString();
            cboHoTenNV.Text = dgvThongTin.Rows[dong].Cells[1].Value.ToString();
            dtpNgayVP.Value = Convert.ToDateTime(dgvThongTin.Rows[dong].Cells[2].Value.ToString());
            txtHinhThuc.Text = dgvThongTin.Rows[dong].Cells[3].Value.ToString();
            rtbNoiDung.Text = dgvThongTin.Rows[dong].Cells[4].Value.ToString();
            txtTienPhat.Text = dgvThongTin.Rows[dong].Cells[5].Value.ToString();
        }
    }
}
