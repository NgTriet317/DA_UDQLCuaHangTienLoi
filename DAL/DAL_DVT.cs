using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_DVT : DBConnect
    {
        public DataTable layDVT()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM DONVITINH", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
            return dt;
        }

        //them dvt
        public bool themNCC(ET.ET_DVT et)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_themDVT", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaDVT", et.MaDVT);
                cmd.Parameters.AddWithValue("@TenDVT", et.TenDVT);
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
