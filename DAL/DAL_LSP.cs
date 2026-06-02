using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_LSP : DBConnect
    {
        // Lấy danh sách loại sản phẩm
        public DataTable layDSLSP()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_layLSP", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                // Ném lỗi lên cho tầng BUS hoặc GUI xử lý
                throw ex;
            }
            finally
            {
                // Luôn kiểm tra và đóng kết nối dù có lỗi hay không
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return dt;
        }

        // Tìm kiếm loại sản phẩm theo mã
        public DataTable findLSP(string ma)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_findLSP", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@MaLoaiSP", ma);
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return dt;
        }

        /// <summary>
        /// Lấy tên loại sản phẩm
        /// </summary>
        /// <param name="ma"></param>
        /// <returns></returns>
        public string layTenLSP(string ma)
        {
            string name = "";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT TenLoaiSP FROM LOAISP where MaLoaiSP = '{ma}'", conn);
                cmd.CommandType = CommandType.Text;

                name = (string)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { conn.Close(); }
            return name;
        }

        //them loai sp
        public bool themLSP(string ma, string ten)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_themLSP", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaLSP", ma);
                cmd.Parameters.AddWithValue("@TenLSP", ten);
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0; // Trả về true nếu có ít nhất 1 dòng bị ảnh hưởng
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
    }
}