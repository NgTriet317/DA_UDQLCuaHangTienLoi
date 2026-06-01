using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_CUAHANG : DBConnect
    {
        //lay thong tin cua hang
        public DataTable LayThongTinCuaHang(string maCH)
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM CUAHANG WHERE MaCH = @MaCH";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@MaCH", maCH);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
    }
}
