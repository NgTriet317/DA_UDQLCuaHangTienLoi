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
                    new SqlParameter("@SoDiemDaDung", khachHang.DiemDaDung),
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
                    new SqlParameter("@SDT", khachHang.Sdt)                    
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

        //lay khach hang theo sdt
        public DataTable GetKhachHangBySDT(string sdt)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_layKhachHangTheoSDT", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter("@sdt", sdt);
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

        //tim rank theo ma rank 
        public string layRank(string ma)
        {
            string rank = "";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_timRankTheoMa", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter("@MaRank", ma);
                cmd.Parameters.Add(parameter);
                rank = (string)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return rank;
        }

        //cap nhat diem khach hang
        public bool capNhatDiem(ET_KHACHHANG et) 
        {            
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_CapNhatDiem", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter[] paras = {
                    new SqlParameter("@MaKH", et.MaKH),
                    new SqlParameter("@NewTich", et.DiemTichLuy),
                    new SqlParameter("@NewDaDung", et.DiemDaDung),
                    new SqlParameter("@NewHienTai", et.DiemHienTai)
                };
                cmd.Parameters.AddRange(paras);

                return cmd.ExecuteNonQuery() > 0;
            }catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
