using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_KHO
    {
        DAL_KHO kho = new DAL_KHO();
        /// <summary>
        /// Lấy sản phẩm tồn kho
        /// </summary>
        /// <returns></returns>
        public DataTable laySPTonKho()
        {
            return kho.laySPTonKho();
        }
        /// <summary>
        /// Lấy thông tin tồn kho
        /// </summary>
        /// <returns></returns>
        public DataTable layTonKho()
        {
            return kho.layTTTonKho();
        }
        /// <summary>
        /// Lấy thông tin kho
        /// </summary>
        /// <returns></returns>
        public DataTable layKho()
        {
            return kho.layTTKho();
        }
        /// <summary>
        /// cập nhật kho
        /// </summary>
        /// <param name="ma"></param>
        /// <param name="soLuong"></param>
        /// <returns></returns>
        public bool updateKho(string ma, int soLuong)
        {
            return kho.updateSLKho(ma, soLuong);
        }

        //lay dia chi kho
        public string layDiaChiKho(string maKho)
        {
            return kho.layDiaChiKho(maKho);
        }

        //tim san pham trong kho theo ma
        public DataTable timSPKho(string maSP, string maKho)
        {
            return kho.timSPKho(maSP, maKho);
        }

        //lay ma kho tu ten kho
        public string layMaKho(string tenKho)
        {
            return kho.layMaKho(tenKho);
        }
    }

}
