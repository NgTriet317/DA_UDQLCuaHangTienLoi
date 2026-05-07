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
    public class BUS_SPNH
    {
        DAL_SP_NH spnh = new DAL_SP_NH();
        /// <summary>
        /// Lấy TT
        /// </summary>
        /// <param name="ma"></param>
        /// <returns> Datatable </returns>
        public DataTable layTT(string ma)
        {
            return spnh.LayTT(ma);
        }

        /// <summary>
        /// Thêm Chi tiết
        /// </summary>
        /// <param name="et"></param>
        /// <returns> bool </returns>
        public bool them(ET_SP_NH et)
        {
            return spnh.ThemTT(et);
        }

        /// <summary>
        /// Xóa chi tiết
        /// </summary>
        /// <param name="ma"></param>
        /// <returns> bool </returns>
        public bool xoa(string ma)
        {
            return spnh.XoaTT(ma);
        }

        /// <summary>
        /// Tìm chi tiết theo mã
        /// </summary>
        /// <param name="ma"></param>
        /// <returns> Datatable </returns>
        public DataTable timChiTietTheoMa(string ma)
        {
            return spnh.timTTChiTietTheoMa(ma);
        }

        /// <summary>
        /// Tìm tên SP theo mã
        /// </summary>
        /// <param name="ma"></param>
        /// <returns> String </returns>
        public string timTenSPTheoMa(string ma)
        {
            return spnh.timTenSPTheoMa(ma);
        }
    }
}
