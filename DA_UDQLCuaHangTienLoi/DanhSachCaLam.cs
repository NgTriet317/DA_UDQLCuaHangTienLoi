using BUS;
using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ET;

namespace DA_UDQLCuaHangTienLoi
{
    public partial class DanhSachCaLam : Form
    {
        public DanhSachCaLam()
        {
            InitializeComponent();
        }
        BUS_NHANVIEN nv = new BUS_NHANVIEN();
        BUS_CaLam caLam = new BUS_CaLam();
        BUS_LichLam lichLam = new BUS_LichLam();
        private void DanhSachCaLam_Load(object sender, EventArgs e)
        {
			//Load Thông tin
			dtpChonNgayLam.Value = DateTime.Now;
			dtpNgayLam.Value = DateTime.Now;
			cboTenNV.ValueMember = "MaNV";
			cboTenNV.DisplayMember = "HoTenNV";
			cboTenNV.DataSource = nv.layTTNhanVienCalam();
			cboMaCa.ValueMember = "MaCa";
			cboMaCa.DisplayMember = "MaCa";
			cboMaCa.DataSource = caLam.LayDSCalam();
			cboCaLam.ValueMember = "MaCa";
			cboCaLam.DisplayMember = "MaCa";
			cboCaLam.DataSource = caLam.LayDSCalam();
			dgvThongTin.CellBorderStyle = DataGridViewCellBorderStyle.Single;
			LoadTT();
        }

        //ham load thong tin len datagridview
        public void LoadTT()
        {
			DataTable dt = lichLam.LayTTCaLam();
            if (dt != null)
            {
                dgvThongTin.Rows.Clear();
                foreach (DataRow dr in dt.Rows)
                {
					dgvThongTin.Rows.Add(
			            dr["MaCa"].ToString(),
			            dr["MaNV"].ToString(),
			            dr["HoTenNV"].ToString(),
			            dr["TenChucVu"].ToString(),
			            Convert.ToDateTime(dr["NgayLamViec"]).ToString("dd/MM/yyyy"),
			            dr["GioBatDau"].ToString(),
			            dr["GioKetThuc"].ToString()
		            );
				}    
            }
			TongThongKe();
		}

        //ham tong thong ke so luong ca lam va nhan vien
        public void TongThongKe()
		{
			int tongCa = 0;
			// Sử dụng HashSet để tự động lọc các Mã NV trùng lặp
			HashSet<string> danhSachNhanVien = new HashSet<string>();
			foreach (DataGridViewRow row in dgvThongTin.Rows)
			{
				if (!row.IsNewRow)
				{
					tongCa++; // Mỗi dòng là 1 ca làm

					// Lấy giá trị của cột Mã NV
					var cellMaNV = row.Cells[1].Value;
					if (cellMaNV != null && !string.IsNullOrWhiteSpace(cellMaNV.ToString()))
					{
						danhSachNhanVien.Add(cellMaNV.ToString());
					}
				}
			}
			lblNV.Text = danhSachNhanVien.Count.ToString();
			lblCaDK.Text = tongCa.ToString();
		}


        // Sự kiện khi chọn một nhân viên trong ComboBox, hiển thị chức vụ tương ứng
        private void cboTenNV_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboTenNV.SelectedIndex != -1 && cboTenNV.SelectedItem is DataRowView)
			{
				// Ép kiểu item đang chọn về DataRowView
				DataRowView row = (DataRowView)cboTenNV.SelectedItem;

				// Giả sử TextBox hiển thị chức vụ của bạn tên là txtChucVu 
				// và tên cột chức vụ trong Database của bạn là "ChucVu"
				txtChucVu.Text = row["TenChucVu"].ToString();
			}
            else
            {
				txtChucVu.Clear();
			}    
		}


        // Sự kiện khi chọn một ca làm trong ComboBox, hiển thị giờ bắt đầu và giờ kết thúc tương ứng
        private void cboMaCa_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboMaCa.SelectedIndex != -1 && cboMaCa.SelectedItem is DataRowView)
			{
				// Ép kiểu item đang chọn về DataRowView
				DataRowView row = (DataRowView)cboMaCa.SelectedItem;

                // Giả sử TextBox hiển thị chức vụ của bạn tên là txtChucVu 
                // và tên cột chức vụ trong Database của bạn là "ChucVu"
                txtGioBatDau.Text = row["GioBatDau"].ToString();
                txtGioKetThuc.Text = row["GioKetThuc"].ToString();
			}
            else
            {
				txtGioBatDau.Clear();
				txtGioKetThuc.Clear();
			}    
		}
		private string maCaCu = "";
		private string maNVCu = "";
        // Sự kiện khi click vào một dòng trong DataGridView, hiển thị thông tin chi tiết của ca làm đó lên các control tương ứng
        private void dgvThongTin_Click(object sender, EventArgs e)
		{
            try
            {
                int dong = dgvThongTin.CurrentCell.RowIndex;
                cboMaCa.SelectedValue = dgvThongTin.Rows[dong].Cells[0].Value;
                cboTenNV.SelectedValue = dgvThongTin.Rows[dong].Cells[1].Value;
                dtpNgayLam.Value = Convert.ToDateTime(dgvThongTin.Rows[dong].Cells[4].Value);
				maCaCu = cboMaCa.SelectedValue.ToString();
				maNVCu =cboTenNV.SelectedValue.ToString();
			}
            catch
            {
                return;
            }
		}
        // Sự kiện khi click vào nút "Xác nhận", thêm một ca làm mới vào cơ sở dữ liệu dựa trên thông tin đã nhập trong các control tương ứng
        private void btnXacNhan_Click(object sender, EventArgs e)
		{
            try
			{
				string maNV = cboTenNV.SelectedValue == null ? "" : cboTenNV.SelectedValue.ToString();
				string maCa = cboMaCa.SelectedValue == null ? "" : cboMaCa.SelectedValue.ToString();
				DateTime ngayLamViec = Convert.ToDateTime(dtpNgayLam.Value);
				if (maNV != string.Empty && maCa != string.Empty)
				{
					if (lichLam.ThemLichLam(new ET_LichLam(maNV, maCa, ngayLamViec)))
					{
						MessageBox.Show("Thêm thành công", "Thông báo");
					}
					else
					{
						MessageBox.Show("Thêm không thành công", "Thông báo");
					}
					LoadTT();
				}
				else
				{
					MessageBox.Show("Thêm không thành công", "Thông báo");
				}
			}
			catch
			{
				return;
			}
		}

        // Sự kiện khi click vào nút "Hủy", xóa thông tin đã nhập trong các control tương ứng để chuẩn bị cho việc nhập thông tin của một ca làm mới
        private void btnHuy_Click(object sender, EventArgs e)
		{
			for (int i = 1; i <= 2; i++)
            {
				cboMaCa.SelectedIndex = -1;
				cboTenNV.SelectedIndex = -1;
				dtpNgayLam.Value = DateTime.Now;
			}    
		}
        // Sự kiện khi click vào nút "Sửa", cập nhật thông tin của một ca làm đã tồn tại trong cơ sở dữ liệu dựa trên thông tin đã chỉnh sửa trong các control tương ứng
        private void btnSua_Click(object sender, EventArgs e)
		{
			try
			{
				string maNVMoi = cboTenNV.SelectedValue == null ? "" : cboTenNV.SelectedValue.ToString();
				string maCaMoi = cboMaCa.SelectedValue == null ? "" : cboMaCa.SelectedValue.ToString();
				DateTime ngayLamViec = Convert.ToDateTime(dtpNgayLam.Value.ToString());
				if (maNVMoi != string.Empty && maCaMoi != string.Empty)
				{
					if (lichLam.SuaLichLam(maNVCu, maCaCu, new ET_LichLam(maNVMoi, maCaMoi, ngayLamViec)))
					{
						MessageBox.Show("Sửa thành công", "Thông báo");
					}
					else
					{
						MessageBox.Show("Sửa không thành công", "Thông báo");
					}
					LoadTT();
				}
				else
				{
					MessageBox.Show("Sửa không thành công", "Thông báo");
				}
			}
			catch
			{
				return;
			}
		}
        // Sự kiện khi click vào nút "Làm mới", xóa thông tin đã nhập trong các control tương ứng và tải lại thông tin của tất cả các ca làm từ cơ sở dữ liệu để hiển thị trên DataGridView
        private void btnLamMoi_Click(object sender, EventArgs e)
		{
			txtNhanVien.Clear();
			cboCaLam.SelectedIndex = 0;
			dtpChonNgayLam.Value = DateTime.Now;
			LoadTT();
		}
        // Sự kiện khi click vào nút "Lọc", lọc thông tin của các ca làm dựa trên tên nhân viên, ca làm và ngày làm việc đã chọn trong các control tương ứng và hiển thị kết quả lọc trên DataGridView
        private void btnLoc_Click(object sender, EventArgs e)
		{
			DataTable dt = new DataTable();
			if (txtNhanVien.Text == string.Empty)
			{
				string caLam = cboCaLam.SelectedValue.ToString();
				DateTime ngayLam = Convert.ToDateTime(dtpChonNgayLam.Value);
				dt = lichLam.TimKiemTheoCaLamVaNgayLam(caLam, ngayLam);
				if (dt != null)
				{
					dgvThongTin.Rows.Clear();
					foreach (DataRow dr in dt.Rows)
					{
						dgvThongTin.Rows.Add(
							dr["MaCa"].ToString(),
							dr["MaNV"].ToString(),
							dr["HoTenNV"].ToString(),
							dr["TenChucVu"].ToString(),
							Convert.ToDateTime(dr["NgayLamViec"]).ToString("dd/MM/yyyy"),
							dr["GioBatDau"].ToString(),
							dr["GioKetThuc"].ToString()
						);
					}
				}
			}
			else
			{
				string tenNV = txtNhanVien.Text;
				string caLam = cboCaLam.SelectedValue.ToString();
				DateTime ngayLam = Convert.ToDateTime(dtpChonNgayLam.Value);
				dt = lichLam.TimKiemTheoTenNV(tenNV, caLam, ngayLam);
				if (dt != null)
				{
					dgvThongTin.Rows.Clear();
					foreach (DataRow dr in dt.Rows)
					{
						dgvThongTin.Rows.Add(
							dr["MaCa"].ToString(),
							dr["MaNV"].ToString(),
							dr["HoTenNV"].ToString(),
							dr["TenChucVu"].ToString(),
							Convert.ToDateTime(dr["NgayLamViec"]).ToString("dd/MM/yyyy"),
							dr["GioBatDau"].ToString(),
							dr["GioKetThuc"].ToString()
						);
					}
				}
			}	
		}
	}
}
