using AForge.Video.DirectShow;
using BUS;
using ET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA_UDQLCuaHangTienLoi
{
	public partial class banHang : Form
	{
		public static string maKH;
		public static int trcGiam;
		public banHang()
		{
			InitializeComponent();
			SetDoubleBuffered(flowLayoutPanelSP);
		}

		public static void SetDoubleBuffered(Control control)
		{
			// Sử dụng Reflection để bật DoubleBuffered
			typeof(Control).InvokeMember("DoubleBuffered",
				System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
				null, control, new object[] { true });
		}


		BUS_SP sp = new BUS_SP();
		BUS_LSP lsp = new BUS_LSP();
		BUS_KHACHHANG Kh = new BUS_KHACHHANG();
		private async void banHang_Load(object sender, EventArgs e)
		{
			//Hien thi thong tin khi app vua bat
			await LoadDanhSachSanPham();


			cbLSP.DataSource = lsp.layDSLSP();
			cbLSP.DisplayMember = "TenLoaiSP";
			cbLSP.ValueMember = "MaLoaiSP";
			cbLSP.SelectedIndex = -1;

		}
		private async Task LoadDanhSachSanPham()
		{
			// Xóa các thẻ cũ nếu có để load lại từ đầu
			flowLayoutPanelSP.Controls.Clear();
			flowLayoutPanelSP.SuspendLayout();
			try
			{
				BUS_SP sp = new BUS_SP();

				DataTable dt = await Task.Run(() => sp.layDSSP());


				// Duyệt qua từng dòng dữ liệu trong CSDL
				foreach (DataRow row in dt.Rows)
				{

					await Task.Delay(1);

					string maSP = row["MaSP"].ToString();
					string tenSP = row["TenSP"].ToString();
					decimal gia = Convert.ToDecimal(row["DonGia"]);
					Image img = null;

					string tenFileAnh = row["Hinh"].ToString();

					string duongDanDayDu = Path.Combine(Application.StartupPath, "AnhSanPham", tenFileAnh);
					// Xử lý hình ảnh từ CSDL (Giả sử bạn lưu dạng mảng byte - varbinary)
					//string thuMucChuaAnh = @"D:\DA_UDQLCuaHangTienLoi\AnhSanPham\";

					//string duongDanDayDu = Path.Combine(thuMucChuaAnh, tenFileAnh);

					if (File.Exists(duongDanDayDu))
					{
						img = Image.FromFile(duongDanDayDu);
					}

					// 1. Tạo một thẻ sản phẩm mới (truyền cả MaSP vào để ẩn đi)
					theSanPham card = new theSanPham(maSP, tenSP, gia, img);

					// Thêm viền (tùy chọn cho giống ảnh)
					card.BorderStyle = BorderStyle.FixedSingle;
					card.Margin = new Padding(10); // Tạo khoảng cách giữa các thẻ

					card.SanPhamClicked += Card_Clicked;
					// 2. Thêm thẻ vào FlowLayoutPanel
					flowLayoutPanelSP.Controls.Add(card);
				}
				flowLayoutPanelSP.ResumeLayout();

			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi tải sản phẩm: " + ex.Message);
			}
		}

		private void textBox4_TextChanged(object sender, EventArgs e)
		{

		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void Card_Clicked(object sender, EventArgs e)
		{
			// Xác định xem thẻ nào vừa bị click
			theSanPham clickedCard = sender as theSanPham;
			if (clickedCard == null) return;

			string ma = clickedCard.MaSP;
			string ten = clickedCard.TenSP;
			decimal gia = clickedCard.DonGia;

			bool daCoTrongHoaDon = false;

			// 1. Kiểm tra xem sản phẩm này đã có trong hóa đơn chưa
			foreach (DataGridViewRow row in dgvHoaDon.Rows)
			{
				if (row.IsNewRow) continue; // Bỏ qua dòng trống mặc định cuối cùng

				// Nếu mã sản phẩm đã tồn tại trong DataGridView
				if (row.Cells["colMaSP"].Value?.ToString() == ma)
				{
					// Tăng số lượng lên 1
					int soLuongHienTai = Convert.ToInt32(row.Cells["colSL"].Value);
					int soLuongMoi = soLuongHienTai + 1;

					row.Cells["colSL"].Value = soLuongMoi;

					// Tính lại tổng tiền của dòng đó (Số lượng * Đơn giá)
					row.Cells["colTong"].Value = soLuongMoi * gia;

					daCoTrongHoaDon = true;
					break; // Thoát vòng lặp vì đã xử lý xong
				}
			}

			// 2. Nếu sản phẩm chưa có trong hóa đơn, thêm dòng mới
			if (!daCoTrongHoaDon)
			{
				// Thứ tự truyền vào phải khớp với thứ tự các cột trong DataGridView của bạn
				// Ví dụ: Tên, Đơn Giá, Khuyến Mãi (0), Số lượng (1), Tổng tiền, Mã SP (ẩn)
				dgvHoaDon.Rows.Add(ten, gia, 0, 1, gia, ma);
			}

			// 3. Cập nhật dòng chữ "Tổng hóa đơn: xxx đ" ở dưới cùng
			TinhTongHoaDon();
		}


		// Hàm phụ để cộng dồn tất cả các dòng tiền lại
		private void TinhTongHoaDon()
		{
			int tongTien = 0;
			foreach (DataGridViewRow row in dgvHoaDon.Rows)
			{
				//if (row.IsNewRow) continue;
				//tongTien += Convert.ToDecimal(row.Cells["colTong"].Value);
				if (row.Cells["colTong"].Value != null)
				{
					tongTien += Convert.ToInt32(row.Cells["colTong"].Value);
				}
			}

			// lblTongTien là cái chữ màu xanh lá cây trong thiết kế của bạn
			lblMoney.Text = (Convert.ToDecimal(tongTien)).ToString();
			trcGiam = Convert.ToInt32(lblMoney.Text);
		}

		private void btnApDung_Click(object sender, EventArgs e)
		{
			flowLayoutPanelSP.Controls.Clear();
			string name = txtNameSP.Text;
			BUS_SP sp = new BUS_SP();
			DataTable dt = sp.findSP(name);

			foreach (DataRow row in dt.Rows)
			{
				string maSP = row["MaSP"].ToString();
				string tenSP = row["TenSP"].ToString();
				decimal gia = Convert.ToDecimal(row["DonGia"]);
				Image img = null;

				string tenFileAnh = row["Hinh"].ToString();

				//string duongDanDayDu = Path.Combine(Application.StartupPath, "AnhSanPham", tenFileAnh);
				// Xử lý hình ảnh từ CSDL (Giả sử bạn lưu dạng mảng byte - varbinary)
				string thuMucChuaAnh = @"D:\Hoc Tap\TrienKhaiHeThong\SD003_DoAn_Nhom1_UngDungQLCHTL_Sprint5\DA_UDQLCuaHangTienLoi\AnhSanPham";

				string duongDanDayDu = Path.Combine(thuMucChuaAnh, tenFileAnh);

				if (File.Exists(duongDanDayDu))
				{
					img = Image.FromFile(duongDanDayDu);
				}

				// 1. Tạo một thẻ sản phẩm mới (truyền cả MaSP vào để ẩn đi)
				theSanPham card = new theSanPham(maSP, tenSP, gia, img);

				// Thêm viền (tùy chọn cho giống ảnh)
				card.BorderStyle = BorderStyle.FixedSingle;
				card.Margin = new Padding(10); // Tạo khoảng cách giữa các thẻ

				card.SanPhamClicked += Card_Clicked;
				// 2. Thêm thẻ vào FlowLayoutPanel
				flowLayoutPanelSP.Controls.Add(card);
			}
		}

		private void btnLamMoi_Click(object sender, EventArgs e)
		{
			LoadDanhSachSanPham();
			cbLSP.SelectedIndex = -1;
			txtNameSP.Clear();

		}

		private void cbLSP_SelectedIndexChanged(object sender, EventArgs e)
		{
			flowLayoutPanelSP.Controls.Clear();
			DataTable dt = sp.layDSSP();
			if (cbLSP.SelectedIndex != -1)
			{
				string name = cbLSP.SelectedValue.ToString();
				dt = lsp.findLSP(name);
			}


			foreach (DataRow row in dt.Rows)
			{
				string maSP = row["MaSP"].ToString();
				string tenSP = row["TenSP"].ToString();
				decimal gia = Convert.ToDecimal(row["DonGia"]);
				Image img = null;

				string tenFileAnh = row["Hinh"].ToString();

				// Xử lý hình ảnh từ CSDL (Giả sử bạn lưu dạng mảng byte - varbinary)
				//string duongDanDayDu = Path.Combine(Application.StartupPath, "AnhSanPham", tenFileAnh);

				string thuMucChuaAnh = @"D:\Hoc Tap\TrienKhaiHeThong\SD003_DoAn_Nhom1_UngDungQLCHTL_Sprint5\DA_UDQLCuaHangTienLoi\AnhSanPham";

				string duongDanDayDu = Path.Combine(thuMucChuaAnh, tenFileAnh);

				if (File.Exists(duongDanDayDu))
				{
					img = Image.FromFile(duongDanDayDu);
				}

				// 1. Tạo một thẻ sản phẩm mới (truyền cả MaSP vào để ẩn đi)
				theSanPham card = new theSanPham(maSP, tenSP, gia, img);

				// Thêm viền (tùy chọn cho giống ảnh)
				card.BorderStyle = BorderStyle.FixedSingle;
				card.Margin = new Padding(10); // Tạo khoảng cách giữa các thẻ

				card.SanPhamClicked += Card_Clicked;
				// 2. Thêm thẻ vào FlowLayoutPanel
				flowLayoutPanelSP.Controls.Add(card);
			}
		}

		private void txtNameSP_TextChanged(object sender, EventArgs e)
		{

		}

		private void btnHuy_Click(object sender, EventArgs e)
		{
			dgvHoaDon.Rows.Clear();
			txtTraTien.Clear();
			lblMoney.Text = "0đ";
			txtTienThua.Clear();
		}

		private void btnThanhToan_Click(object sender, EventArgs e)
		{
			if(lblNhapDiem.Visible == false)
			{
				//Xuất hóa đơn không dùng điểm
				if (dgvHoaDon.Rows.Count < 0)
				{
					MessageBox.Show("Không tìm thấy sản phẩm để tạo hóa đơn");
				}
				else
				{
					try
					{
						ET_HoaDon et = new ET_HoaDon(DateTime.Now, Convert.ToInt32(lblMoney.Text), Convert.ToInt32(lblMoney.Text), Convert.ToInt32(txtTraTien.Text), Convert.ToInt32(txtTienThua.Text), frmMain.maNV);

						BUS_HoaDon hd = new BUS_HoaDon();
						if (hd.ThemHoaDon(et))
						{
							string maHDVuaTao = hd.LayMaHoaDonMoiNhat();
							foreach (DataGridViewRow row in dgvHoaDon.Rows)
							{
								if (row.IsNewRow) continue;
								ET_SPHD etSphd = new ET_SPHD(maHDVuaTao, row.Cells["colMaSP"].Value.ToString(), Convert.ToInt32(row.Cells["colSL"].Value), Convert.ToInt32(row.Cells["colDonGia"].Value));
								BUS_SPHD sphd = new BUS_SPHD();
								sphd.ThemChiTietHoaDon(etSphd);
							}
							InHoaDonKhongDungDiem(maHDVuaTao);
						}
						dgvHoaDon.Rows.Clear();
						txtNhapDiem.Clear();
					}
					catch (Exception ex)
					{
						MessageBox.Show("Lỗi thanh toán: " + ex.Message);
					}
				}
			}	
			else
			{
				//Xử lý điểm tích lũy và điểm đã dùng
				int diemDaDung = 0, nhapDiem = 0;
				if (!int.TryParse(lblDiemDaDung.Text, out diemDaDung) || !int.TryParse(txtNhapDiem.Text, out nhapDiem))
				{
					MessageBox.Show("Vui lòng nhập số hợp lệ cho điểm!", "Lỗi");
					return;
				}
				diemDaDung += nhapDiem;

				int diemHienTai = Convert.ToInt32(lblDiemHienTai.Text) - nhapDiem;

				if (diemHienTai < 0)
				{
					MessageBox.Show("Bạn không dủ điểm!", "Thông báo");
				}
				else
				{

					ET_KHACHHANG et = new ET_KHACHHANG(maKH, Convert.ToInt32(lblDiemDaTich.Text), diemDaDung, diemHienTai);
					//Cập nhật điểm
					Kh.capNhatDiem(et);
				}
				//Xuất hóa đơn dùng điểm
				if (dgvHoaDon.Rows.Count < 0)
				{
					MessageBox.Show("Không tìm thấy sản phẩm để tạo hóa đơn");
				}
				else
				{
					try
					{
						ET_HoaDon et = new ET_HoaDon(DateTime.Now, trcGiam, Convert.ToInt32(lblMoney.Text), Convert.ToInt32(txtTraTien.Text), Convert.ToInt32(txtTienThua.Text), banHang.maKH, frmMain.maNV);

						BUS_HoaDon hd = new BUS_HoaDon();
						if (hd.ThemHoaDonDungDiem(et))
						{
							string maHDVuaTao = hd.LayMaHoaDonMoiNhat();
							foreach (DataGridViewRow row in dgvHoaDon.Rows)
							{
								if (row.IsNewRow) continue;
								ET_SPHD etSphd = new ET_SPHD(maHDVuaTao, row.Cells["colMaSP"].Value.ToString(), Convert.ToInt32(row.Cells["colSL"].Value), Convert.ToInt32(row.Cells["colDonGia"].Value));
								BUS_SPHD sphd = new BUS_SPHD();
								sphd.ThemChiTietHoaDon(etSphd);
							}
							InHoaDonDungDiem(maHDVuaTao, nhapDiem);
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show("Lỗi thanh toán: " + ex.Message);
					}
				}
			}
		}

		private void InHoaDonKhongDungDiem(string maHD)
		{
			InHoaDon frm = new InHoaDon();
			rptXuatHoaDon inHoaDon = new rptXuatHoaDon();

			try
			{
				// 1. Tầng BUS/DAL lấy dữ liệu và TỰ ĐÓNG KẾT NỐI DATABASE (nhờ finally { conn.Close(); })
				BUS_HoaDon hd = new BUS_HoaDon();
				DataTable dtHoaDon = hd.layFullHoaDon(maHD);

				// 2. Bơm dữ liệu vào Report (Report lúc này là vỏ rỗng, xài dataset xsd)
				inHoaDon.SetDataSource(dtHoaDon);

				// 3. Không dùng SetParameterValue để gọi xuống DB nữa!
				// inHoaDon.SetParameterValue("@MaHD", maHD); // BỎ DÒNG NÀY ĐI

				frm.crystalReportViewer1.ReportSource = inHoaDon;
				frm.ShowDialog();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi in hóa đơn: " + ex.Message);
			}
			finally
			{
				// 4. Ngắt connection và dọn rác của riêng Crystal Report
				if (frm.crystalReportViewer1 != null) frm.crystalReportViewer1.ReportSource = null;
				if (inHoaDon != null)
				{
					inHoaDon.Close();
					inHoaDon.Dispose();
				}
				if (frm != null) frm.Dispose();
			}
		}

		private void InHoaDonDungDiem(string maHD, int diemDung)
		{
			InHoaDonDungDiem frm = new InHoaDonDungDiem();
			rptXuatHoaDonDungDiem inHoaDon = new rptXuatHoaDonDungDiem();

			try
			{
				// 1. Tầng BUS/DAL lấy dữ liệu và TỰ ĐÓNG KẾT NỐI DATABASE (nhờ finally { conn.Close(); })
				BUS_HoaDon hd = new BUS_HoaDon();
				DataTable HoaDonDungDiem = hd.layFullHoaDonDungDiem(maHD, diemDung);

				// 2. Bơm dữ liệu vào Report (Report lúc này là vỏ rỗng, xài dataset xsd)
				inHoaDon.SetDataSource(HoaDonDungDiem);

				// 3. Không dùng SetParameterValue để gọi xuống DB nữa!
				// inHoaDon.SetParameterValue("@MaHD", maHD); // BỎ DÒNG NÀY ĐI

				frm.crystalReportViewer1.ReportSource = inHoaDon;
				frm.ShowDialog();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi in hóa đơn: " + ex.Message);
			}
			finally
			{
				// 4. Ngắt connection và dọn rác của riêng Crystal Report
				if (frm.crystalReportViewer1 != null) frm.crystalReportViewer1.ReportSource = null;
				if (inHoaDon != null)
				{
					inHoaDon.Close();
					inHoaDon.Dispose();
				}
				if (frm != null) frm.Dispose();
			}
		}

		private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0 || dgvHoaDon.Rows[e.RowIndex].IsNewRow) return;

			DataGridViewRow row = dgvHoaDon.Rows[e.RowIndex];

			try
			{
				// Lấy giá trị hiện tại
				decimal gia = Convert.ToDecimal(row.Cells["colDonGia"].Value);
				int soLuongHienTai = Convert.ToInt32(row.Cells["colSL"].Value);
				int soLuongMoi = soLuongHienTai - 1;

				if (soLuongMoi <= 0)
				{
					// Xóa hẳn dòng khỏi DataGridView
					dgvHoaDon.Rows.Remove(row);
				}
				else
				{
					// Cập nhật số lượng và tổng tiền
					row.Cells["colSL"].Value = soLuongMoi;
					row.Cells["colTong"].Value = soLuongMoi * gia;
				}

				// Cập nhật lại tổng tiền toàn hóa đơn ở đây (nếu có)
				// CapNhatTongTienChung(); 
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi xử lý: " + ex.Message);
			}
			TinhTongHoaDon();
			if (txtTraTien.Text != string.Empty)
			{

				int tienThua = Convert.ToInt32(txtTraTien.Text.ToString()) - Convert.ToInt32(lblMoney.Text.ToString());
				if (tienThua < 0)
				{
					txtTienThua.Text = "0";
				}
				else
				{
					txtTienThua.Text = tienThua.ToString();
				}

			}
		}


		private void txtTraTien_TextChanged(object sender, EventArgs e)
		{
			TinhTienThua();
			//try
			//{
			//    //Kiểm tra giá trị nếu không rỗng
			//    if (txtTraTien.Text != string.Empty)
			//    {
			//        int tienThua = Convert.ToInt32(txtTraTien.Text.ToString()) - Convert.ToInt32(lblMoney.Text.ToString());
			//        if (tienThua < 0) //Nếu tiền thừa < 0 thì cho text = 0
			//        {
			//            txtTienThua.Text = "0";
			//        }
			//        else //còn ko thì cho text = tienThua
			//        {
			//            txtTienThua.Text = tienThua.ToString();
			//        }
			//    }
			//}
			////Bắt lỗi
			//catch
			//{
			//    MessageBox.Show("Chỉ được nhập số");
			//}
		}

		private void lblRank_Click(object sender, EventArgs e)
		{

		}

		private void checkDungDiem_CheckedChanged(object sender, EventArgs e)
		{
			if (checkDungDiem.Checked)
			{
				txtNhapDiem.Visible = true;
				lblNhapDiem.Visible = true;
			}
			else
			{
				txtNhapDiem.Visible = false;
				lblNhapDiem.Visible = false;
				// Xóa text để lần sau bật lên không bị lưu số cũ (tùy chọn)
				txtNhapDiem.Clear();
			}

			// GỌI HÀM CẬP NHẬT TỔNG TIỀN
			CapNhatTongTien();
		}

		private void CheckTichDiem_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void txtSdt_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (txtSdt.Text == "")
				{
					MessageBox.Show("Vui lòng nhập số điện thoại khách hàng");
					pnTTKH.Visible = false;
					return;
				}
				pnTTKH.Visible = true;

				DataTable dt = Kh.GetKhachHangBySDT(txtSdt.Text);

				if (dt.Rows.Count > 0)
				{
					DataRow dr = dt.Rows[0];
					maKH = dr["MaKH"].ToString();
					lblName.Text = dr["HoTenKH"].ToString();
					lblDiemDaTich.Text = dr["SoDiemDaTich"].ToString();
					lblDiemHienTai.Text = dr["SoDiemHienTai"].ToString();
					lblRank.Text = Kh.GetRankByMaRank(dr["MaRank"].ToString());
					lblDiemDaDung.Text = dr["SoDiemDaDung"].ToString();
				}

				// Ngăn tiếng beep mặc định
				e.SuppressKeyPress = true;
			}
		}

		private void txtNhapDiem_TextChanged(object sender, EventArgs e)
		{

		}

		private void txtNhapDiem_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				// Chỉ cần gọi hàm này, nó sẽ tự động lấy số tiền gốc trừ đi số trong txtNhapDiem
				CapNhatTongTien();

				// Ngăn tiếng beep
				e.SuppressKeyPress = true;
			}
		}

		// 1. Hàm chỉ làm nhiệm vụ tính tổng tiền gốc của các sản phẩm trong DataGridView
		private int TinhTongTienGoc()
		{
			int tongTien = 0;
			foreach (DataGridViewRow row in dgvHoaDon.Rows)
			{
				if (row.Cells["colTong"].Value != null)
				{
					tongTien += Convert.ToInt32(row.Cells["colTong"].Value);
				}
			}
			return tongTien;
		}

		// 2. Hàm TÍNH TỔNG CHÍNH - xử lý cả tiền gốc và điểm giảm giá
		private void CapNhatTongTien()
		{
			// Lấy tổng tiền gốc từ giỏ hàng
			int tongTienGoc = TinhTongTienGoc();
			int soTienGiam = 0;

			// Kiểm tra xem khách có check vào ô "Dùng điểm" không
			if (checkDungDiem.Checked && !string.IsNullOrWhiteSpace(txtNhapDiem.Text))
			{
				// Kiểm tra xem dữ liệu nhập vào có phải là số hợp lệ không
				if (int.TryParse(txtNhapDiem.Text, out int diemNhap))
				{
					soTienGiam = diemNhap; // Giả sử 1 điểm = 1 VNĐ
				}
			}

			// Tính tổng tiền cuối cùng
			int tongTienCuoiCung = tongTienGoc - soTienGiam;

			// Đảm bảo tổng tiền không bị âm (nếu điểm nhập lớn hơn hoặc bằng tổng tiền)
			if (tongTienCuoiCung < 0)
			{
				tongTienCuoiCung = 0;
			}

			// Cập nhật lên Label hiển thị
			lblMoney.Text = tongTienCuoiCung.ToString();

			// Gọi luôn hàm tính tiền thừa để cập nhật ô Tiền thừa nếu khách đã nhập tiền trả
			TinhTienThua();
		}

		// 3. Hàm tính tiền thừa tách riêng cho gọn và an toàn
		private void TinhTienThua()
		{
			if (!string.IsNullOrWhiteSpace(txtTraTien.Text) && int.TryParse(txtTraTien.Text, out int tienKhachDua))
			{
				int tongTienPhaiTra = Convert.ToInt32(lblMoney.Text);
				int tienThua = tienKhachDua - tongTienPhaiTra;

				txtTienThua.Text = tienThua < 0 ? "0" : tienThua.ToString();
			}
			else
			{
				txtTienThua.Text = "0";
			}
		}


		private void btnQuetMa_Click(object sender, EventArgs e)
		{
			// Mở form quét mã dưới dạng Popup
			using (quetMa frm = new quetMa())
			{
				// Nếu quét thành công (form kia trả về DialogResult.OK)
				if (frm.ShowDialog() == DialogResult.OK)
				{
					string maSP = frm.MaSPQuetDuoc;

					// --- BẮT ĐẦU TÌM TRONG SQL ---
					// Gọi xuống tầng BUS để tìm sản phẩm theo Mã. 
					// (Lưu ý: Nếu BUS_SP của bạn chưa có hàm findSPByMaSP, hãy tạo nó nhé. Hàm này trả về DataTable chứa 1 dòng SP)
					BUS_SP sp = new BUS_SP();
					DataTable dt = sp.findSPMa(maSP);

					if (dt != null && dt.Rows.Count > 0)
					{
						// Lấy dữ liệu từ CSDL
						DataRow row = dt.Rows[0];
						string ma = row["MaSP"].ToString();
						string ten = row["TenSP"].ToString();
						decimal gia = Convert.ToDecimal(row["DonGia"]);

						// Thêm vào DataGridView hóa đơn (logic giống hệt lúc bạn click tay vào thẻ SP)
						ThemVaoGioHang(ma, ten, gia);

						// Cập nhật lại tổng tiền theo logic chuẩn mình đã bàn ở trên
						CapNhatTongTien();
					}
					else
					{
						MessageBox.Show("Mã sản phẩm (" + maSP + ") không có trong CSDL!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}
			}
		}
		private void ThemVaoGioHang(string ma, string ten, decimal gia)
		{
			bool daCo = false;
			foreach (DataGridViewRow r in dgvHoaDon.Rows)
			{
				if (r.IsNewRow) continue;
				if (r.Cells["colMaSP"].Value?.ToString() == ma)
				{
					int slMoi = Convert.ToInt32(r.Cells["colSL"].Value) + 1;
					r.Cells["colSL"].Value = slMoi;
					r.Cells["colTong"].Value = slMoi * gia;
					daCo = true;
					break;
				}
			}

			if (!daCo)
			{
				// Thêm dòng mới: Tên, Đơn Giá, Khuyến Mãi (0), Số lượng (1), Tổng tiền, Mã SP
				dgvHoaDon.Rows.Add(ten, gia, 0, 1, gia, ma);
			}
		}
	}
}
