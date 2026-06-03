using ET;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_KhenThuong : DBConnect
    {
        public DataTable LayDSKhenTHuong()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_LayDSKhenThuong", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public bool ThemKhenThuong(ET_KhenThuong et)
        {
            bool kq = false;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ThemKhenThuong", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaKT", et.MaKT);
                cmd.Parameters.AddWithValue("@MaNV", et.MaNV);
                cmd.Parameters.AddWithValue("@NgayQuyetDinh", et.NgayQD);
                cmd.Parameters.AddWithValue("@NoiDungThuong", et.NoiDungThuong);
                cmd.Parameters.AddWithValue("@SoTienThuong", et.TienThuong);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    kq = true;
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
            return kq;
        }

        public bool SuaKhenThuong(ET_KhenThuong et)
        {
            bool kq = false;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_SuaKhenThuong", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaKT", et.MaKT);
                cmd.Parameters.AddWithValue("@MaNV", et.MaNV);
                cmd.Parameters.AddWithValue("@NgayQuyetDinh", et.NgayQD);
                cmd.Parameters.AddWithValue("@NoiDungThuong", et.NoiDungThuong);
                cmd.Parameters.AddWithValue("@SoTienThuong", et.TienThuong);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    kq = true;
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
            return kq;
        }
    }
}
