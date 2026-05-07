using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using ET;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BUS
{
    public class BUS_TK
    {
        DAL_TK tk = new DAL_TK();
        /// <summary>
        /// Kiểm tra tài khoản
        /// </summary>
        /// <param name="email"></param>
        /// <returns> Bool </returns>
        public bool checkTK(string email)
        {
            return tk.checkTK(email);
        }

        /// <summary>
        /// Tìm nhân viên online
        /// </summary>
        /// <param name="email"></param>
        /// <returns> Datatable </returns>
        public DataTable timNVOnl(string email)
        {
            return tk.TimNVOnl(email);
        }

        /// <summary>
        /// Kiểm tra vai trò
        /// </summary>
        /// <param name="email"></param>
        /// <returns> String </returns>
        public string checkRole(string email)
        {
            return tk.checkRole(email);
        }

        /// <summary>
        /// Kiểm tra mật khẩu
        /// </summary>
        /// <param name="pass"></param>
        /// <returns> bool </returns>
        public bool checkMK(string pass)
        {
            return tk.checkMK(pass);
        }
    }
}
