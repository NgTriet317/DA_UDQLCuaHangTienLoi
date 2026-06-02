using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_CUAHANG
    {
        DAL_CUAHANG ch = new DAL_CUAHANG();
        public DataTable layTTCuaHang(string ma)
        {
            return ch.LayThongTinCuaHang(ma);
        }
    }
}
