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
    public class DAL_KyLuat : DBConnect
    {
        public DataTable LayDSKyLuat()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_LayDSKyLuat", conn);
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

        public bool ThemKyLuat(ET_KyLuat et)
        {
            bool kq = false;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ThemKyLuat", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaKL", et.MaKL);
                cmd.Parameters.AddWithValue("@MaNV", et.MaNV);
                cmd.Parameters.AddWithValue("@NgayViPham", et.NgayViPham);
                cmd.Parameters.AddWithValue("@HinhThuc", et.HinhThuc);
                cmd.Parameters.AddWithValue("@NoiDungPhat", et.NoiDungPhat);
                cmd.Parameters.AddWithValue("@SoTienPhat", et.SoTienPhat);
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

        public bool SuaKyLuat(ET_KyLuat et)
        {
            bool kq = false;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_SuaKyLuat", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaKL", et.MaKL);
                cmd.Parameters.AddWithValue("@MaNV", et.MaNV);
                cmd.Parameters.AddWithValue("@NgayViPham", et.NgayViPham);
                cmd.Parameters.AddWithValue("@HinhThuc", et.HinhThuc);
                cmd.Parameters.AddWithValue("@NoiDungPhat", et.NoiDungPhat);
                cmd.Parameters.AddWithValue("@SoTienPhat", et.SoTienPhat);
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
