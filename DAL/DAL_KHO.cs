using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_KHO : DBConnect
    {
        /// <summary>
        /// Lấy sp tồn kho
        /// </summary>
        /// <returns></returns>
        public DataTable laySPTonKho()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_LaySPTonKho", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return dt;
        }

        /// <summary>
        /// lấy tt tồn kho
        /// </summary>
        /// <returns></returns>
        public DataTable layTTTonKho()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM TONKHO", conn);
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return dt;
        }

        /// <summary>
        /// Lấy tt kho
        /// </summary>
        /// <returns></returns>
        public DataTable layTTKho()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM KHOHANG", conn);
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return dt;
        }


        /// <summary>
        /// Update số lượng kho
        /// </summary>
        /// <param name="ma"></param>
        /// <param name="soLuongKho"></param>
        /// <returns></returns>
        public bool updateSLKho(string ma, int soLuongKho)
        {
            bool kq = false;
            try
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand($"UPDATE TONKHO SET SoLuongTonKho = {soLuongKho} WHERE MaSP = '{ma}'", conn);
                sqlCommand.CommandType = CommandType.Text;

                if (sqlCommand.ExecuteNonQuery() > 0)
                {
                    kq = true;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { conn.Close(); }
            return kq;
        }

        //lay dia chi kho
        public string layDiaChiKho(string maKho)
        {
            string diaChi = "";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_layDiaChi", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramMaKho = new SqlParameter("@MaKhoHang", maKho);
                cmd.Parameters.Add(paramMaKho);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    diaChi = reader["DiaChi"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { conn.Close(); }
            return diaChi;
        }

        //tim san pham trong kho theo ma
        public DataTable timSPKho(string maSP, string maKho)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_timSPTrongKho", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramMaSP = new SqlParameter("@MaSP", maSP);
                cmd.Parameters.Add(paramMaSP);
                SqlParameter paramMaKho = new SqlParameter("@MaKhoHang", maKho);
                cmd.Parameters.Add(paramMaKho);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { conn.Close(); }
            return dt;

        }
    }
}