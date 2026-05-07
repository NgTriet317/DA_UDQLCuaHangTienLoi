using DAL;
using ET;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
	public class BUS_LichLam
	{
		DAL_LichLam dal = new DAL_LichLam();
		public DataTable LayTTCaLam()
		{
			return dal.LayTTCaLam();
		}
		public bool ThemLichLam(ET_LichLam et)
		{
			return dal.ThemLichLam(et);
		}
		public bool SuaLichLam(string maNV_Cu, string maCa_Cu, ET_LichLam et)
		{
			return dal.SuaLichLam(maNV_Cu, maCa_Cu, et);
		}
		public DataTable TimKiemTheoCaLamVaNgayLam(string maCa, DateTime ngayLam)
		{
			return dal.TimKiemTheoCaLamVaNgayLam(maCa, ngayLam);
		}
		public DataTable TimKiemTheoTenNV(string tenNV, string maCa, DateTime ngayLam)
		{
			return dal.TimKiemTheoTenNV(tenNV, maCa, ngayLam);	
		}
	}
}
