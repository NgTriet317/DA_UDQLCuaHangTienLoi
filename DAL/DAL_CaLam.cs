using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class DAL_CaLam : DBConnect
	{

		public DataTable LayDSCalam()
		{
			DataTable dt = new DataTable();
			try
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand("sp_LayDSCaLam", conn);
				cmd.CommandType = CommandType.StoredProcedure;
				SqlDataAdapter adapter = new SqlDataAdapter(cmd);
				adapter.Fill(dt);
			}
			catch
			{
				throw;
			}
			finally
			{
				conn.Close();
			}
			return dt;
		}
	}
}
