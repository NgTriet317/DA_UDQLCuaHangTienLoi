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
    public partial class InDoanhThuThang : Form
    {
        public InDoanhThuThang()
        {
            InitializeComponent();
        }
        BUS_HoaDon bus = new BUS_HoaDon();
        private void InDoanhThuThang_Load(object sender, EventArgs e)
        {
            cboChonThang.DataSource = bus.LayDSHoaDonThang();
            cboChonThang.ValueMember = "ThangNamHienThi";
            cboChonThang.DisplayMember = "ThangNamHienThi";
            cboChonThang.FormatString = "dd/MM/yyyy";
            cboChonThang.FormattingEnabled = true;
        }

        private void cboChonThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 1. Chặn ngay nếu ComboBox chưa có giá trị
            if (cboChonThang.SelectedValue == null || string.IsNullOrWhiteSpace(cboChonThang.Text))
            {
                return;
            }
            // 2. Chặn lỗi kinh điển của WinForms lúc gán DataSource
            if (cboChonThang.Text.Contains("DataRowView"))
            {
                return;
            }
            try
            {

                rptThongKeDoanhThuThang dsDoanhThuThang = new rptThongKeDoanhThuThang();
                string[] temp = cboChonThang.Text.Split('/');
                int thang = Convert.ToInt32(temp[0]);
                int nam = Convert.ToInt32(temp[1]);
                DataTable dt = bus.LayDSHoaDonTheoThang(thang, nam);
                dsDoanhThuThang.SetDataSource(dt);
                crystalReportViewer2.ReportSource = dsDoanhThuThang;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
