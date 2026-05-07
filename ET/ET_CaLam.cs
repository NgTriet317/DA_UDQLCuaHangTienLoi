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
		private int tienPhuCap;

		public ET_CaLam(string maCa, DateTime gioBatDau, DateTime gioKetThuc, int tienPhuCap)
		{
			this.MaCa = maCa;
			this.GioBatDau = gioBatDau;
			this.GioKetThuc = gioKetThuc;
			this.TienPhuCap = tienPhuCap;
		}

		public string MaCa { get => maCa; set => maCa = value; }
		public DateTime GioBatDau { get => gioBatDau; set => gioBatDau = value; }
		public DateTime GioKetThuc { get => gioKetThuc; set => gioKetThuc = value; }
		public int TienPhuCap { get => tienPhuCap; set => tienPhuCap = value; }
	}
}
