using ET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
	public class DAL_LichLam : DBConnect
	{
		public DataTable LayTTCaLam()
		{
			DataTable dt = new DataTable();
			try
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand("sp_LayTTCaLam", conn);
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

		public bool ThemLichLam(ET_LichLam et)
		{
			bool kq = false;
			try
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand("sp_ThemLichLam", conn);
				cmd.CommandType = CommandType.StoredProcedure;
				SqlParameter[] parms = new SqlParameter[] {
					new SqlParameter("@MaNV", et.MaNV),
					new SqlParameter("@MaCa", et.MaCa),
					new SqlParameter("@NgayLamViec", et.NgayLamViec)
				};
				cmd.Parameters.AddRange(parms);
				if (cmd.ExecuteNonQuery() > 0)
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
				conn.Close();
			}
			return kq;
		}

		public bool SuaLichLam(string maNV_Cu, string maCa_Cu, ET_LichLam et)
		{
			bool kq = false;
			try
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand("sp_SuaLichLam", conn);
				cmd.CommandType = CommandType.StoredProcedure;
				SqlParameter[] parms = new SqlParameter[] {
					new SqlParameter("@MaNV_Cu", maNV_Cu),
					new SqlParameter("@MaCa_Cu", maCa_Cu),
					new SqlParameter("@MaNV_Moi", et.MaNV),
					new SqlParameter("@MaCa_Moi", et.MaCa),
					new SqlParameter("@NgayLamViec", et.NgayLamViec)
				};
				cmd.Parameters.AddRange(parms);
				if (cmd.ExecuteNonQuery() > 0)
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
				conn.Close();
			}
			return kq;
		}

		public DataTable TimKiemTheoCaLamVaNgayLam(string maCa, DateTime ngayLam)
		{
			DataTable dt = new DataTable();
			try
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand("sp_TimKiemTheoCaLamVaNgayLam", conn);
				cmd.CommandType = CommandType.StoredProcedure;
				SqlParameter[] parms = new SqlParameter[] {
					new SqlParameter("@MaCa", maCa),
					new SqlParameter("@NgayLamViec", ngayLam)
				};
				cmd.Parameters.AddRange(parms);
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

		public DataTable TimKiemTheoTenNV(string tenNV ,string maCa, DateTime ngayLam)
		{
			DataTable dt = new DataTable();
			try
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand("sp_TimKiemTheoTenNV", conn);
				cmd.CommandType = CommandType.StoredProcedure;
				SqlParameter[] parms = new SqlParameter[] {
					new SqlParameter("@HoTenNV", "%" + tenNV + "%"),
					new SqlParameter("@MaCa", maCa),
					new SqlParameter("@NgayLamViec", ngayLam)
				};
				cmd.Parameters.AddRange(parms);
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
