using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ET;

namespace BUS
{
    public class BUS_HoaDon
    {
        DAL_HoaDon hd = new DAL_HoaDon();
        //Them hoa don
        public bool ThemHoaDon(ET_HoaDon et)
        {
            return hd.ThemHoaDon(et);
        }

        //Thêm hóa đơn dùng điểm
        public bool ThemHoaDonDungDiem(ET_HoaDon et)
        {
            return hd.ThemHoaDonDungDiem(et);
		}

		//Lay full thong tin hoa don
		public DataTable layFullHoaDon(string ma)
        {
            return hd.LayTTHoaDon(ma);
        }

		//Lấy thông tin chi tiết hóa đơn dùng điểm
        public DataTable layFullHoaDonDungDiem(string ma, int diemDung)
		{
			return hd.LayTTHoaDonDungDiem(ma, diemDung);
		}

		//lay hoa don moi nhat
		public string LayMaHoaDonMoiNhat()
        {
            return hd.LayMaHoaDonMoiNhat();
        }

        //lay ds hoa don theo ngay
        public DataTable LayDSHoaDonTheoNgay(DateTime ngayLap)
        {
            return hd.LayDSHoaDonTheoNgay(ngayLap);
        }

        //lay toan bo hoa don
        public DataTable LayDSHoaDon()
        {
            return hd.LayDSHoaDon();
        }

        //lay ds hoa don theo thang
        public DataTable LayDSHoaDonThang()
        {
            return hd.LayDSHoaDonThang();
        }

        //lay ds hoa don theo thang
        public DataTable LayDSHoaDonTheoThang(int thang, int nam)
        {
            return hd.LayDSHoaDonTheoThang(thang, nam);
        }
    }
}
