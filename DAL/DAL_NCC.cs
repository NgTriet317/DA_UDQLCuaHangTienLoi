using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using ET;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_NCC : DBConnect
    {        
        /// <summary>
        /// lấy ds ncc
        /// </summary>
        /// <returns></returns>
        public DataTable layDSNCC()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_layNCC",conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);


            }catch (Exception ex)
            {
                throw ex;
            }
            finally { conn.Close(); }
            return dt;
        }

        /// <summary>
        /// lấy tên ncc
        /// </summary>
        /// <param name="ma"></param>
        /// <returns></returns>
        public string layTenNCC(string ma)
        {
            string name = "";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT TenNCC FROM NHACUNGCAP where MaNCC = '{ma.Trim()}'", conn);
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
