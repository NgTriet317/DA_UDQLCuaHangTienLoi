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
    public class BUS_KyLuat
    {
        DAL_KyLuat kluat = new DAL_KyLuat();
        public DataTable LayDSKyLuat()
        {
            return kluat.LayDSKyLuat();
        }
        public bool ThemKyLuat(ET_KyLuat et)
        {
            return kluat.ThemKyLuat(et);
        }
        public bool SuaKyLuat(ET_KyLuat et)
        {
            return kluat.SuaKyLuat(et);
        }
    }
}
