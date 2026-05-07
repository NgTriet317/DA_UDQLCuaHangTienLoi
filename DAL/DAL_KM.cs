using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ET;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DAL_KM : DBConnect
    {
        /// <summary>
        /// Lấy ds KM
        /// </summary>
        /// <returns></returns>
        public DataTable LayDSKM()
        {
            DataTable db = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_LayKM", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(db);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { conn.Close(); }
            return db;
        }

        /// <summary>
        /// lấy tên km
        /// </summary>
        /// <param name="ma"></param>
        /// <returns></returns>
        public string layTenKM(string ma)
        {
            string name = "";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT TenKM FROM KHUYENMAI where MaKM = '{ma}'", conn);
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
    }
}
