using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_NHAPHANG
    {
        DAL_NHAPHANG nh = new DAL_NHAPHANG();
        /// <summary>
        /// Lấy thông tin nhập hàng
        /// </summary>
        /// <returns>Datatable</returns>
        public DataTable layTT()
        {
            return nh.layTT();
        }

        /// <summary>
        /// Thêm thông tin nhập hàng
        /// </summary>
        /// <param name="ma"></param>
        /// <param name="maNV"></param>
        /// <param name="maKho"></param>
        /// <returns>Bool</returns>
        public bool themNH(string ma, string maNV, string maKho)
        {
            return nh.themDonNhapHang(ma, maNV, maKho);
        }

        /// <summary>
        /// Xóa nhập hàng
        /// </summary>
        /// <param name="ma"></param>
        /// <returns>Bool</returns>
        public bool xoaNH(string ma)
        {
            return nh.XoaDonNhapHang(ma);
        }

        /// <summary>
        /// Đưa sản phẩm vào kho
        /// </summary>
        /// <param name="ma"></param>
        /// <returns>Bool</returns>
        public bool duaSPVaoKho(string ma)
        {
            return nh.duaSPVaoKho(ma);
        }

        /// <summary>
        /// Cập nhật tổng tiền
        /// </summary>
        /// <param name="ma"></param>
        /// <param name="tongTien"></param>
        /// <returns></returns>
        public bool capNhatTongTien(string ma, int tongTien)
        {
            return nh.capNhatTongTien(ma, tongTien);
        }

        /// <summary>
        /// Lấy DS nhập hàng
        /// </summary>
        /// <returns> DataTabke </returns>
        public DataTable LayDSNhapHang()
        {
            return nh.LayDSNhapHang();
        }

        /// <summary>
        /// Thống kê nhập hàng
        /// </summary>
        /// <param name="thoiGianNhap"></param>
        /// <returns> Datatable </returns>
        public DataTable ThongKeNhapHang(DateTime thoiGianNhap)
        {
            return nh.ThongKeNhapHang(thoiGianNhap);
        }
    }
}
