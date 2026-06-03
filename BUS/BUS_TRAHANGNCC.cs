using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_TRAHANG
    {
        DAL_TRAHANGNCC traHang = new DAL_TRAHANGNCC();

        //tao phieu tra hang
        public bool taoPhieuTraHang(string ma)
        {
            return traHang.taoPhieuTraHang(ma);
        }

        //lay all tt tra hang 
        public DataTable layAllTT()
        {
            return traHang.layTTTraHang();
        }
    }
}
