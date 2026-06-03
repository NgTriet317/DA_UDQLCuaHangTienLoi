using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_BangLuong
    {
        DAL_BangLuong bl = new DAL_BangLuong();

        public DataTable LayDSBangLuong()
        {
            return bl.LayDSBangLuong();
        }

        public DataTable TongHopLuongThang(string maNV, int thang, int nam, DateTime ngayChot)
        {
            return bl.TongHopLuongThang(maNV, thang, nam, ngayChot);
        }
    }
}
