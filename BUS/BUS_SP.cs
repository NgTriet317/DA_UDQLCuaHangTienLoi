using System;
using DAL;
using ET;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BUS
{
    public class BUS_SP
    {
        DAL_SP sp = new DAL_SP();
        /// <summary>
        /// Thêm sản phẩm
        /// </summary>
        /// <param name="et"></param>
        /// <returns>Bool</returns>
        public bool themSP(ET_SP et)
        {
            return sp.themSP(et);
        }

        /// <summary>
        /// Sửa sản phẩm
        /// </summary>
        /// <param name="et"></param>
        /// <returns>Bool</returns>
        public bool suaSP(ET_SP et)
        {
            return sp.suaSP(et);
        }

        /// <summary>
        /// xóa sản phẩm
        /// </summary>
        /// <param name=ma></param>
        /// <returns>Bool</returns>
        public bool xoaSP(string ma)
        {
            return sp.xoaSP(ma);
        }

        /// <summary>
        /// Lấy DS sản phẩm
        /// </summary>        
        /// <returns>Datatable</returns>
        public DataTable layDSSP()
        {
            return sp.layDSSP();
        }

        /// <summary>
        /// Tìm kiếm sản phẩm
        /// </summary>
        /// <param name="name"></param>
        /// <returns> Datatable </returns>
        public DataTable findSP(string name)
        {
            return sp.findSP(name.Trim());
        }

        /// <summary>
        /// Tìm SP theo mã
        /// </summary>
        /// <param name="ma"></param>
        /// <returns> Datatable </returns>
        public DataTable findSPMa(string ma)
        {
            return sp.findSPMa(ma.Trim());
        }

        /// <summary>
        /// Cập nhật SLSP
        /// </summary>
        /// <param name="ma"></param>
        /// <param name="soLuongSP"></param>
        /// <returns> bool </returns>
        public bool updateSLSP(string ma,int soLuongSP)
        {
            return sp.updateSLSP(ma,soLuongSP);
        }

        /// <summary>
        /// Tìm sp theo mã loại
        /// </summary>
        /// <param name="ma"></param>
        /// <returns> Datatable </returns>
        public DataTable timSPTheoMaLoai(string ma)
        {
            return sp.findSPMaLoai(ma);
        }
        //lay han sd
        public DateTime layHanSD(string ma)
        {
            return sp.timHanSD(ma);
        }
    }
}
