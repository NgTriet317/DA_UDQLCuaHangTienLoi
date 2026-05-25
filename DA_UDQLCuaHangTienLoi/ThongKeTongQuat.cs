using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts.Wpf;
using LiveCharts;
using System.Windows.Media;
using BUS;

namespace DA_UDQLCuaHangTienLoi
{
	public partial class ThongKeTongQuat : Form
	{
		public ThongKeTongQuat()
		{
			InitializeComponent();
		}

		private void ThongKeTongQuat_Load(object sender, EventArgs e)
		{
			LoadDataGridView();
			LoadThongKeTongQuat();
			LoadThongTinHoaDon();
			LoadMockData();
		}
		BUS_HoaDon hd = new BUS_HoaDon();

		private void LoadThongKeTongQuat()
		{
			DataTable dt = hd.ThongKeTongQuat();
			if(dt.Rows.Count > 0)

	{
				DataRow r = dt.Rows[0];

				// 1. Hiển thị Tổng doanh thu (Định dạng tiền tệ VNĐ)
				double doanhThu = Convert.ToDouble(r["TongDoanhThu"]);
				lblTongDoanhThu.Text = doanhThu.ToString("N0") + " đ";

				// 2. Hiển thị Tổng hóa đơn
				lblTongHoaDon.Text = r["TongHoaDon"].ToString();

				// 3. Hiển thị Tổng số lượng hàng bán
				lblTongSoLuong.Text = r["TongSL"].ToString();

				// 4. Hiển thị Khách hàng mới
				lblKhachHangMoi.Text = r["KhachHangMoi"].ToString();
			}
		}

		private void LoadDataGridView()
		{
			//Thiết lập giao diện cho DataGridView
			dgvThongTin.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.LightGrid;
			dgvThongTin.EnableHeadersVisualStyles = false;

			// 2. Ép trực tiếp Font chữ và cỡ chữ cho Header của cột
			dgvThongTin.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);

			// 3. Chỉnh luôn màu nền và màu chữ cho Header
			dgvThongTin.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 240, 240); // Màu xám nhạt
			dgvThongTin.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black; // Chữ màu đen

			// 4. Ép Font cho các hàng dữ liệu bên dưới luôn cho đồng bộ
			dgvThongTin.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);

			// 5. Chỉnh màu lưới cho DataGridView để nó nổi bật hơn
			dgvThongTin.ThemeStyle.GridColor = System.Drawing.Color.Black; // Màu đường lưới
		}

		private void LoadChartDoanhThuVaHoaDon(DateTime tuNgay, DateTime denNgay)
		{
			// 1. Gọi DAL để lấy dữ liệu DataTable
			DataTable dt = hd.LayDuLieuChoBieuDoDoanhThuVaHoaDon(tuNgay, denNgay);

			// 2. Khởi tạo các danh sách để hứng dữ liệu cho LiveCharts
			ChartValues<double> doanhThuValues = new ChartValues<double>();
			ChartValues<int> hoaDonValues = new ChartValues<int>();
			List<string> labels = new List<string>();

			// 3. Duyệt DataTable để đổ vào các danh sách
			foreach (DataRow row in dt.Rows)
			{
				// Chuyển đổi ngày tháng sang định dạng dd/MM để làm nhãn trục X
				DateTime ngay = Convert.ToDateTime(row["Ngay"]);
				labels.Add(ngay.ToString("dd/MM"));

				// Thêm giá trị Doanh thu và Số hóa đơn (Tên cột phải khớp với Stored Procedure)
				doanhThuValues.Add(Convert.ToDouble(row["DoanhThu"]));
				hoaDonValues.Add(Convert.ToInt32(row["SoHoaDon"]));
			}

			// 4. Gán dữ liệu vào biểu đồ Doanh thu (chartDoanhThu)
			chartDoanhThu.Series = new SeriesCollection
			{
				new LineSeries
				{
					Title = "Doanh thu",
					Values = doanhThuValues,
					LabelPoint = point => point.Y.ToString("N0") + " VNĐ",
					PointGeometrySize = 12,
					StrokeThickness = 4,
					// Thêm màu sắc cho biểu đồ đường (Xanh dương)
					Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(33, 150, 243)), // Màu của đường kẻ
					Fill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(60, 33, 150, 243)) // Màu nền dưới đường kẻ (trong suốt 60/255)
				}
			};

			// 5. Gán dữ liệu vào biểu đồ Hóa đơn (chartHoaDon)
			chartHoaDon.Series = new SeriesCollection
			{
				new ColumnSeries
				{
					Title = "Số hóa đơn",
					Values = hoaDonValues,
					Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 152, 0))
				}
			};

			// 6. Cấu hình trục X cho cả 2 biểu đồ
			chartDoanhThu.AxisX.Clear();
			chartDoanhThu.AxisX.Add(new Axis
			{
				Title = "Ngày/Tháng",
				Labels = labels,
				FontSize = 14, // Tăng kích thước chữ
				Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(70, 70, 70)), // Làm màu chữ đậm hơn
				Separator = new Separator { Step = 1, IsEnabled = false }
			});

			chartHoaDon.AxisX.Clear();
			chartHoaDon.AxisX.Add(new Axis
			{
				Title = "Ngày/Tháng",
				Labels = labels,
				FontSize = 14, // Tăng kích thước chữ
				Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(70, 70, 70)),
				Separator = new Separator { Step = 1, IsEnabled = false }
			});

			// 6. Cấu hình trục Y cho cả 2 biểu đồ
			// Trục Y - Doanh thu
			chartDoanhThu.AxisY.Clear();
			chartDoanhThu.AxisY.Add(new Axis
			{
				Title = "Doanh thu (triệu VND)",
				LabelFormatter = value =>
				{
					if (value >= 1000000)
						return (value / 1000000).ToString("N1") + "tr"; 
					if (value >= 1000)
						return (value / 1000).ToString("N0") + "K";   
					return value.ToString("N0");                    
				},
				MinValue = 0,
				FontSize = 14, // Tăng kích thước chữ
				Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(70, 70, 70)) // Làm màu chữ đậm hơn
			});

			// Trục Y - Hóa đơn
			chartHoaDon.AxisY.Clear();
			chartHoaDon.AxisY.Add(new Axis
			{
				Title = "Số lượng (đơn)",
				LabelFormatter = value => value.ToString("N0"),
				MinValue = 0,
				FontSize = 14, // Tăng kích thước chữ
				Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(70, 70, 70)),
				Separator = new Separator { Step = 1, IsEnabled = false }
			});
		}

		private void LoadChartLoaiBanDuoc(DateTime tuNgay, DateTime denNgay)
		{
			// 1. Gọi DAL để lấy dữ liệu DataTable
			DataTable dt = hd.LayDuLieuBieuDoLoaiBanDuoc(tuNgay, denNgay);

			// 2. Khởi tạo một tập hợp Series mới cho biểu đồ tròn
			SeriesCollection pieSeriesCollection = new SeriesCollection();

			// 3. Chỉnh màu cho từng loại trong biểu đồ tròn
			List<System.Windows.Media.Color> bangMau = new List<System.Windows.Media.Color>
			{
				System.Windows.Media.Color.FromRgb(33, 150, 243),  // Blue (Nước giải khát)
				System.Windows.Media.Color.FromRgb(233, 30, 99),   // Pink (Bánh kẹo)
				System.Windows.Media.Color.FromRgb(76, 175, 80),   // Green (Gia vị)
				System.Windows.Media.Color.FromRgb(255, 152, 0),  // Orange (Thực phẩm hộp)
				System.Windows.Media.Color.FromRgb(156, 39, 176),  // Purple (Hóa mỹ phẩm)
				System.Windows.Media.Color.FromRgb(255, 235, 59),  // Yellow (Đồ ăn vặt)
				System.Windows.Media.Color.FromRgb(0, 188, 212),  // Cyan (Sữa)
				System.Windows.Media.Color.FromRgb(244, 67, 54),   // Red (Tươi sống)
				System.Windows.Media.Color.FromRgb(139, 195, 74)   // Lime (Trái cây)
			};
			int mauIndex = 0;

			// 3. Duyệt qua từng dòng dữ liệu trong DataTable
			foreach (DataRow row in dt.Rows)
			{
				// Tạo biến lưu trữ tránh vượt quá mảng màu
				System.Windows.Media.Color mauHienTai = bangMau[mauIndex % bangMau.Count];

				// Tạo một miếng bánh (PieSeries) cho mỗi loại sản phẩm
				PieSeries series = new PieSeries
				{
					// Tên loại sản phẩm
					Title = row["TenLoaiSP"].ToString(),

					// Số lượng bán được
					Values = new ChartValues<double> { Convert.ToDouble(row["TongSoLuongBan"]) },

					DataLabels = true, // Hiện nhãn dữ liệu
					FontSize = 14,     // Chữ to dễ nhìn

					// Định dạng nhãn hiển thị phần trăm (ví dụ: 45.5%)
					LabelPoint = chartPoint => string.Format("{0:P}", chartPoint.Participation),

					// Thêm màu vào dữ liệu của 1 phần biểu đồ tròn
					Fill = new SolidColorBrush(mauHienTai)
				};

				// Thêm miếng bánh vào tập hợp
				pieSeriesCollection.Add(series);
				mauIndex++;
			}

			// 4. Gán tập hợp vừa tạo vào biểu đồ
			chartPhanLoai.Series = pieSeriesCollection;

			// 5. Cấu hình thêm cho đẹp (nếu bạn muốn dạng Donut có lỗ ở giữa)
			chartPhanLoai.InnerRadius = 50;
			chartPhanLoai.LegendLocation = LegendLocation.Right;
		}

		private void LoadThongTinHoaDonTuNgayDenNgay(DateTime tuNgay, DateTime denNgay)
		{
			DataTable dt = hd.LayDSHoaDonTuNgayDenNgay(tuNgay, denNgay);
			if (dt != null)
			{
				dgvThongTin.Rows.Clear();
				foreach (DataRow row in dt.Rows)
				{
					dgvThongTin.Rows.Add(
						row[0].ToString(),
						row[1].ToString(),
						Convert.ToDateTime(row[2].ToString()).ToString("dd/MM/yyyy"),
						row[3].ToString()
					);
				}
			}
		}

		//Load thong tin hoa don
		private void LoadThongTinHoaDon()
		{
			DataTable dt = hd.LayThongTinHoaDon();
			if (dt != null)
			{
				dgvThongTin.Rows.Clear();
				foreach (DataRow row in dt.Rows)
				{
					dgvThongTin.Rows.Add(
						row[0].ToString(),
						row[1].ToString(),
						Convert.ToDateTime(row[2].ToString()).ToString("dd/MM/yyyy"),
						row[3].ToString()
					);
				}
			}	
		}

		//load mock data
		private void LoadMockData()
		{

			// 1.Tạo ngẫu nhiên dữ liệu doanh thu

			Random rand = new Random();
			ChartValues<double> mockValues = new ChartValues<double>();
			List<string> mockLabels = new List<string>();
			double spDoUong = rand.Next(20, 50);
			double spDoAnVat = rand.Next(15, 30);
			double spGiaDung = rand.Next(10, 25);
			double spKhac = rand.Next(5, 15);

			for (int i = 6; i >= 0; i--)
			{
				mockValues.Add(rand.Next(10, 100));
				mockLabels.Add(DateTime.Now.AddDays(-i).ToString("dd/MM"));
			}

			// 2. Đưa dữ liệu mẫu vào biểu đồ Doanh thu (Đường)
			chartDoanhThu.Series = new SeriesCollection
			{
				new LineSeries
				{
					Title = "Doanh thu",
					Values = mockValues,
					PointGeometrySize = 12,
					StrokeThickness = 4,
					// Thêm màu sắc cho biểu đồ đường (Xanh dương)
					Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(33, 150, 243)), // Màu của đường kẻ
					Fill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(60, 33, 150, 243)) // Màu nền dưới đường kẻ (trong suốt 60/255)
				}
			};

			// 3. Đưa dữ liệu vào biểu đồ Hóa đơn (Cột)
			chartHoaDon.Series = new SeriesCollection
			{
				new ColumnSeries
				{
					Title = "Số hóa đơn",
					Values = new ChartValues<double> { rand.Next(5, 20), rand.Next(5, 20), rand.Next(5, 20), rand.Next(5, 20), rand.Next(5, 20), rand.Next(5, 20), rand.Next(5, 20) },
					// Thêm màu sắc cho biểu đồ cột (Cam)
					Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 152, 0))
				}
			};

			// 4. Đưa dữ liệu vào biểu đồ phân loại sản phẩm nhập hàng
			chartPhanLoai.Series = new SeriesCollection
			{
				new PieSeries {
					Title = "Nước giải khát",
					Values = new ChartValues<double> { rand.Next(10, 50) },
					DataLabels = true, FontSize = 13,
					LabelPoint = p => string.Format("{0:P}", p.Participation),
					Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(33, 150, 243)) // Blue
				},
				new PieSeries {
					Title = "Bánh kẹo",
					Values = new ChartValues<double> { rand.Next(10, 50) },
					DataLabels = true, FontSize = 13,
					LabelPoint = p => string.Format("{0:P}", p.Participation),
					Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(233, 30, 99)) // Pink
				},
				new PieSeries {
					Title = "Gia vị nấu ăn",
					Values = new ChartValues<double> { rand.Next(10, 50) },
					DataLabels = true, FontSize = 13,
					LabelPoint = p => string.Format("{0:P}", p.Participation),
					Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(76, 175, 80)) // Green
				},
				new PieSeries {
					Title = "Thực phẩm đóng hộp",
					Values = new ChartValues<double> { rand.Next(10, 50) },
					DataLabels = true, FontSize = 13,
					LabelPoint = p => string.Format("{0:P}", p.Participation),
					Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 152, 0)) // Orange
				},
				new PieSeries {
					Title = "Hóa mỹ phẩm",
					Values = new ChartValues<double> { rand.Next(10, 50) },
					DataLabels = true, FontSize = 13,
					LabelPoint = p => string.Format("{0:P}", p.Participation),
					Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(156, 39, 176)) // Purple
				},
				new PieSeries {
					Title = "Đồ ăn vặt",
					Values = new ChartValues<double> { rand.Next(10, 50) },
					DataLabels = true, FontSize = 13,
					LabelPoint = p => string.Format("{0:P}", p.Participation),
					Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 235, 59)) // Yellow
				},
				new PieSeries {
					Title = "Sữa & Chế phẩm",
					Values = new ChartValues<double> { rand.Next(10, 50) },
					DataLabels = true, FontSize = 13,
					LabelPoint = p => string.Format("{0:P}", p.Participation),
					Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 188, 212)) // Cyan
				},
				new PieSeries {
					Title = "Thực phẩm tươi sống",
					Values = new ChartValues<double> { rand.Next(10, 50) },
					DataLabels = true, FontSize = 13,
					LabelPoint = p => string.Format("{0:P}", p.Participation),
					Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(244, 67, 54)) // Red
				},
				new PieSeries {
					Title = "Trái cây",
					Values = new ChartValues<double> { rand.Next(10, 50) },
					DataLabels = true, FontSize = 13,
					LabelPoint = p => string.Format("{0:P}", p.Participation),
					Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(139, 195, 74)) // Light Green
				}
			};

			// 5. CẤU HÌNH TRỤC X (Ngày tháng)

			chartDoanhThu.AxisX.Clear();
			chartDoanhThu.AxisX.Add(new Axis
			{
				Title = "Ngày/Tháng",
				Labels = mockLabels,
				FontSize = 14, // Tăng kích thước chữ
				Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(70, 70, 70)), // Làm màu chữ đậm hơn
				Separator = new Separator { Step = 1, IsEnabled = false }
			});

			chartHoaDon.AxisX.Clear();
			chartHoaDon.AxisX.Add(new Axis
			{
				Title = "Ngày/Tháng",
				Labels = mockLabels,
				FontSize = 14, // Tăng kích thước chữ
				Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(70, 70, 70)),
				Separator = new Separator { Step = 1, IsEnabled = false }
			});

			// 6. CẤU HÌNH TRỤC Y (Doanh thu & Số lượng)

			// Trục Y - Doanh thu
			chartDoanhThu.AxisY.Clear();
			chartDoanhThu.AxisY.Add(new Axis
			{
				Title = "Doanh thu (triệu VND)",
				LabelFormatter = value => value + "tr",
				MinValue = 0,
				FontSize = 14, // Tăng kích thước chữ
				Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(70, 70, 70)) // Làm màu chữ đậm hơn
			});

			// Trục Y - Hóa đơn
			chartHoaDon.AxisY.Clear();
			chartHoaDon.AxisY.Add(new Axis
			{
				Title = "Số lượng (đơn)",
				LabelFormatter = value => value.ToString("N0"),
				MinValue = 0,
				FontSize = 14, // Tăng kích thước chữ
				Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(70, 70, 70)),
				Separator = new Separator { Step = 5 }
			});

			// 7. CẤU HÌNH CHO BIỂU ĐỒ TRÒN
			chartPhanLoai.LegendLocation = LegendLocation.Right; // Đưa chú thích xuống dưới
			chartPhanLoai.InnerRadius = 60; // Tạo lỗ trống ở giữa - Chỉnh số càng lớn lỗ càng to
		}

		private void btnLoc_Click(object sender, EventArgs e)
		{
			DateTime tuNgay = dtpNgayTu.Value.Date;
			DateTime denNgay = dtpNgayDen.Value.Date;
			if (tuNgay > denNgay)
			{
				MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			LoadChartDoanhThuVaHoaDon(tuNgay, denNgay);
			LoadChartLoaiBanDuoc(tuNgay, denNgay);
			LoadThongTinHoaDonTuNgayDenNgay(tuNgay, denNgay);
		}

		//reload button
		private void btnTaiLai_Click(object sender, EventArgs e)
		{
			LoadThongKeTongQuat();
			LoadThongTinHoaDon();
			LoadMockData();
		}
	}
}
