using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
	public class ET_CaLam
	{
		private string maCa;
		private DateTime gioBatDau;
		private DateTime gioKetThuc;
		private int giaCa;

		public ET_CaLam(string maCa, DateTime gioBatDau, DateTime gioKetThuc, int giaCa)
		{
			this.MaCa = maCa;
			this.GioBatDau = gioBatDau;
			this.GioKetThuc = gioKetThuc;
			this.GiaCa = giaCa;
		}

		public string MaCa { get => maCa; set => maCa = value; }
		public DateTime GioBatDau { get => gioBatDau; set => gioBatDau = value; }
		public DateTime GioKetThuc { get => gioKetThuc; set => gioKetThuc = value; }
		public int GiaCa { get => giaCa; set => giaCa = value; }
	}
}
