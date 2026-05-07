using DAL;
using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_SPHD
    {
        DAL_SPHD sphd = new DAL_SPHD();
        /// <summary>
        /// Thêm chi tiết hóa đơn
        /// </summary>
        /// <param name="et"></param>
        /// <returns> Bool </returns>
        public bool ThemChiTietHoaDon(ET_SPHD et)
        {
            return sphd.ThemChiTietHoaDon(et);
        }
    }
}
