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
    public partial class InThongKeNhapHang : Form
    {
        public InThongKeNhapHang()
        {
            InitializeComponent();
        }
        BUS_NHAPHANG bus = new BUS_NHAPHANG();
        private void InThongKeNhapHang_Load(object sender, EventArgs e)
        {
            cboChoNgayNhap.ValueMember = "ThoiGianNhap";
            cboChoNgayNhap.DisplayMember = "ThoiGianNhap";
            cboChoNgayNhap.DataSource = bus.LayDSNhapHang();
        }

        private void cboChoNgayNhap_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 1. Chặn ngay nếu ComboBox chưa có giá trị
            if (cboChoNgayNhap.SelectedValue == null || string.IsNullOrWhiteSpace(cboChoNgayNhap.Text))
            {
                return;
            }
            // 2. Chặn lỗi kinh điển của WinForms lúc gán DataSource
            if (cboChoNgayNhap.Text.Contains("DataRowView"))
            {
                return;
            }
            try
            {

                rptThongKeNhapHang dsNhapHang = new rptThongKeNhapHang();
                DateTime ngayNhap = Convert.ToDateTime(cboChoNgayNhap.SelectedValue);
                DataTable dt = bus.ThongKeNhapHang(ngayNhap);
                dsNhapHang.SetDataSource(dt);
                crystalReportViewer3.ReportSource = dsNhapHang;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
