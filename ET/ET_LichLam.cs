using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
	public class ET_LichLam
	{
		private string maNV;
		private string maCa;
		private DateTime ngayLamViec;

		public ET_LichLam(string maNV, string maCa, DateTime ngayLamViec)
		{
			this.MaNV = maNV;
			this.MaCa = maCa;
			this.NgayLamViec = ngayLamViec;
		}

		public string MaNV { get => maNV; set => maNV = value; }
		public string MaCa { get => maCa; set => maCa = value; }
		public DateTime NgayLamViec { get => ngayLamViec; set => ngayLamViec = value; }
	}
}
