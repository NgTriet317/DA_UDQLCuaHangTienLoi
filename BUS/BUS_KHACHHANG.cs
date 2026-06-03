using DAL;
using ET;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_KHACHHANG
    {
        DAL_KHACHHANG kh = new DAL_KHACHHANG();

        //lấy toàn bộ khách hàng
        public DataTable GetAllKhachHang()
        {
            return kh.GetAllKhachHang();
        }

        //thêm mới khách hàng
        public bool AddKhachHang(ET_KHACHHANG khachHang)
        {
            return kh.AddKhachHang(khachHang);
        }

        //cập nhật thông tin khách hàng
        public bool UpdateKhachHang(ET_KHACHHANG khachHang)
        {
            return kh.UpdateKhachHang(khachHang);
        }

        //Tìm kiếm khách hàng
        public DataTable SearchKhachHang(string keyword)
        {
            return kh.SearchKhachHang(keyword);
        }
        //lay kh theo sdt
        public DataTable GetKhachHangBySDT(string sdt)
        {
            return kh.GetKhachHangBySDT(sdt);
        }
        //lay rank theo ma rank
        public string GetRankByMaRank(string maRank)
        {
            return kh.layRank(maRank);
        }

        //cap nhat diem
        public bool capNhatDiem(ET_KHACHHANG et)
        {
            return kh.capNhatDiem(et);
        }

        //Cập nhật rank
        public bool CapNhatRank(string maKH, int soDiemMoi)
        {
            return kh.CapNhatRank(maKH, soDiemMoi);
        }
    } 
}
