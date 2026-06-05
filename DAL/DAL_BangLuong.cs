using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_BangLuong : DBConnect
    {
        public DataTable LayDSBangLuong()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmmd = new SqlCommand("sp_LayDSBangLuong", conn);
                cmmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmmd);
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

        public DataTable TongHopLuongThang(string maNV, int thang, int nam, DateTime ngayChot)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmmd = new SqlCommand("sp_TongHopLuongThang", conn);
                cmmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@MaNV", maNV),
                    new SqlParameter("@Thang", thang),
                    new SqlParameter("@Nam", nam),
                    new SqlParameter("@NgayChot", ngayChot)
                };
                cmmd.Parameters.AddRange(para);
                SqlDataAdapter da = new SqlDataAdapter(cmmd);
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

        public DataTable LocBangLuongTheoThangNam(int thang, int nam)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmmd = new SqlCommand("sp_LocBangLuongTheoThangNam", conn);
                cmmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@Thang", thang),
                    new SqlParameter("@Nam", nam)
                };
                cmmd.Parameters.AddRange(para);
                SqlDataAdapter da = new SqlDataAdapter(cmmd);
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

        public DataTable LocBangLuongTheoTenNV(string tenNV)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmmd = new SqlCommand("sp_LocBangLuongTheoTenNV", conn);
                cmmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@HoTenNV", tenNV)
                };
                cmmd.Parameters.AddRange(para);
                SqlDataAdapter da = new SqlDataAdapter(cmmd);
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
    }
}
