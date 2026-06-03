using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_TRAHANG : DBConnect
    {
        
        //lay toan bo thong tin tra hang
        public DataTable layTTTraHang()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM TRAHANGNCC", conn);
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

            }
            catch
            {
                throw;
            }
            finally { conn.Close();  }
            return dt;
        }

        //tao phieu tra hang
        public bool taoPhieuTraHang(string ma)
        {
            bool kq = false;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"INSERT INTO TRAHANGNCC(MaTraNCC) values ('{ma}')",conn);
                cmd.CommandType = CommandType.Text;

                if(cmd.ExecuteNonQuery() > 0)
                {
                    kq = true;
                }
            }
            catch
            {
                throw;
            }
            finally { conn.Close(); }
            return kq;
        }

        //Luu chi tiet tra hang
        
    }
}
