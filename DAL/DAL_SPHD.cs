using ET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_SPHD : DBConnect
    {
        public bool ThemChiTietHoaDon(ET_SPHD et)
        {
            bool kt = false;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ThemChiTietHoaDon", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] param = new SqlParameter[] { 
                    new SqlParameter("@MaHD", et.MaHD),
                    new SqlParameter("@MaSP", et.MaSP),
                    new SqlParameter("@SoLuong", et.SoLuong),
                    new SqlParameter("@DonGia", et.DonGia)
                };
                cmd.Parameters.AddRange(param);
                if(cmd.ExecuteNonQuery() > 0)
                {
                    kt = true;
                }    
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return kt;
        }
    }
}
