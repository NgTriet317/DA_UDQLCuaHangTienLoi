using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ET;
using DAL;
using System.Threading.Tasks;
using System.Data;

namespace BUS
{
    public class BUS_NCC
    {
        DAL_NCC ncc = new DAL_NCC();
        /// <summary>
        /// Lấy thông tin nhà cung cấp
        /// </summary>
        /// <returns>Datatable</returns>
        public DataTable layNCC()
        {
            return ncc.layDSNCC();
        }

        /// <summary>
        /// lấy tên nhà cung cấp
        /// </summary>
        /// <param name="ma"></param>
        /// <returns>String</returns>
        public string layTenNCC(string ma)
        {
            return ncc.layTenNCC(ma);
        }
    }
}
