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
    public class DAL_KHACHHANG : DBConnect
    {
        public DataTable GetAllKhachHang()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_LayDSKhachHang", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public bool AddKhachHang(ET_KHACHHANG khachHang)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ThemKhachHang", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter[] parameters = {
                    new SqlParameter("@TenKH", khachHang.TenKH),
                    new SqlParameter("@SDT", khachHang.Sdt),
                    new SqlParameter("@SoDiemDaTich", khachHang.DiemTichLuy),
                    new SqlParameter("@SoDiemHienTai", khachHang.DiemHienTai)
                };
                cmd.Parameters.AddRange(parameters);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool UpdateKhachHang(ET_KHACHHANG khachHang)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_CapNhatKhachHang", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter[] parameters = {
                    new SqlParameter("@MaKH", khachHang.MaKH),
                    new SqlParameter("@TenKH", khachHang.TenKH),
                    new SqlParameter("@SDT", khachHang.Sdt),
                    new SqlParameter("@SoDiemDaTich", khachHang.DiemTichLuy),
                    new SqlParameter("@SoDiemHienTai", khachHang.DiemHienTai)
                };
                cmd.Parameters.AddRange(parameters);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }


        public DataTable SearchKhachHang(string keyword)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_TimKiemKHTheoTen", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter("@TenKH", "%" + keyword + "%");
                cmd.Parameters.Add(parameter);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
    }
}
