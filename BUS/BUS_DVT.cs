using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_DVT
    {
        DAL_DVT dvt = new DAL_DVT();
        public DataTable layAllDVT()
        {
            return dvt.layDVT();
        }

        //them dvt
        public bool them(ET.ET_DVT et)
        {
            return dvt.themNCC(et);
        }
    }
}
