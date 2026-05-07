using System;
using System.Collections.Generic;
using System.Linq;
using ET;
using DAL;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BUS
{
    public class BUS_LSP
    {
        DAL_LSP lsp = new DAL_LSP();

        /// <summary>
        /// Lấy DS loại SP
        /// </summary>
        /// <returns>Datatable</returns>
        public DataTable layDSLSP()
        {
            return lsp.layDSLSP();
        }

        /// <summary>
        /// Tìm kiếm loại SP
        /// </summary>
        /// <param name="ma"></param>
        /// <returns> Datatable </returns>
        public DataTable findLSP(string ma)
        {
            return lsp.findLSP(ma);
        }

        /// <summary>
        /// Lấy tên loại SP
        /// </summary>
        /// <param name="ma"></param>
        /// <returns> String </returns>
        public string layTenLoai(string ma)
        {
            return lsp.layTenLSP(ma);
        }
    }
}
