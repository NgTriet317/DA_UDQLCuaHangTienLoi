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
    public class DAL_SP_NH : DBConnect
    {
        public DataTable LayTT(string ma)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_layTTsphd", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@MaNH", ma);
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
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
        public string timTenSPTheoMa(string ma)
        {
            string name = "";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT TenSP FROM SANPHAM WHERE MaSP = '{ma}'", conn);
                cmd.CommandType = CommandType.Text;
                                                
                name = (string)cmd.ExecuteScalar();
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return name;
        }

        public bool ThemTT(ET_SP_NH et)
        {
            bool kq = false;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ThemSPNH", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter[] param =
                {
                    new SqlParameter("@MaNH",et.MaNH),
                    new SqlParameter("@MaSP",et.MaSP),
                    new SqlParameter("@SL",et.SlNhap),
                    new SqlParameter("@GiaNhap",et.GiaNhap)
                };
                cmd.Parameters.AddRange(param);

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

        public bool XoaTT(string ma)
        {
            bool kq = false;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_XoaSPNH", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@MaSP", ma);
                cmd.Parameters.Add(param);

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

        /// <summary>
        /// Tìm kiếm chi tiết hàng hóa bằng mã
        /// </summary>
        /// <param name="ma"></param>
        /// <returns>DataTable</returns>
        /// <exception cref="Exception"></exception>
        public DataTable timTTChiTietTheoMa(string ma)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_timChiTietNHTheoMa", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@MaNH", ma);
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }catch (Exception ex)
            {
                throw new Exception("Lỗi tìm kiếm: " + ex);
            }
            finally { conn.Close(); }
            return dt;            
        }
    }
}
