using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_TK : DBConnect
    {
        
        public bool checkTK(string email)
        {
            bool kq = false;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_checkTK", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@TaiKhoan", email);
                cmd.Parameters.Add(param);

                // Dùng object thay vì ép kiểu string trực tiếp để tránh lỗi NullReferenceException
                object temp = cmd.ExecuteScalar();
                if (temp != null && temp != DBNull.Value)
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
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return kq;
        }

        public string checkRole(string email)
        {
            string temp = "";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_checkROLE", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@TaiKhoan", email);
                cmd.Parameters.Add(param);

                // Dùng object thay vì ép kiểu string trực tiếp để tránh lỗi NullReferenceException
                temp = cmd.ExecuteScalar().ToString();                
            }
            catch
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return temp;
        }

        public bool checkMK(string pass)
        {
            bool kq = false;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_checkMK", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@pass", pass);
                cmd.Parameters.Add(param);

                object temp = cmd.ExecuteScalar();
                if (temp != null && temp != DBNull.Value)
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
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return kq;
        }

        public DataTable TimNVOnl(string mail)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_TimNVHoatDong", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@TaiKhoan", mail);
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);


            }catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close( );
            }
            return dt;
        }
    }
}