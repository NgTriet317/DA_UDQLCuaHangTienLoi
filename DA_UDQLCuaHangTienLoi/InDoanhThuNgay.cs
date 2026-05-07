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
    public partial class InDoanhThuNgay : Form
    {
        public InDoanhThuNgay()
        {
            InitializeComponent();
        }
        BUS_HoaDon bus = new BUS_HoaDon();
        private void InDoanhThuNgay_Load(object sender, EventArgs e)
        {
            cboChonNgay.DataSource = bus.LayDSHoaDon();
            cboChonNgay.ValueMember = "NgayLap";
            cboChonNgay.DisplayMember = "NgayLap";
            cboChonNgay.FormatString = "dd/MM/yyyy";
            cboChonNgay.FormattingEnabled = true;
        }

        private void cboChonNgay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboChonNgay.SelectedValue == null || !(cboChonNgay.SelectedValue is DateTime))
            {
                return;
            }
            try
            {

                rptThongKeDoanhThu dsDoanhThu = new rptThongKeDoanhThu();
                DateTime ngayChon = (DateTime)cboChonNgay.SelectedValue;
                DataTable dt = bus.LayDSHoaDonTheoNgay(ngayChon);
                dsDoanhThu.SetDataSource(dt);
                crystalReportViewer1.ReportSource = dsDoanhThu;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
