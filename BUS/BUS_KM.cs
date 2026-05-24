using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Threading.Tasks;
using System.Data;

namespace BUS
{
    public class BUS_KM
    {
        DAL_KM km = new DAL_KM();
        /// <summary>
        /// Lấy danh sách khuyến mãi
        /// </summary>
        /// <returns></returns>
        public DataTable LayDSKM()
        {
            return km.LayDSKM();
        }

        /// <summary>
        /// Lấy tên khuyến mãi
        /// </summary>
        /// <param name="ma"></param>
        /// <returns></returns>
        public string layTen(string ma)
        {
            return km.layTenKM(ma);
        }

        //lay sp theo km
        public DataTable LaySPTheoKM(string ma)
        {
            return km.LaySPTheoKM(ma);
        }
    }
}
