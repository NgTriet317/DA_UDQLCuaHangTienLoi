using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
	public class ET_KhenThuong
	{
		private string maKT;
		private string maNV;
		private DateTime ngayQD;
		private string noiDungThuong;
		private int tienThuong;

        public ET_KhenThuong(string maKT, string maNV, DateTime ngayQD, string noiDungThuong, int tienThuong)
        {
            this.MaKT = maKT;
            this.MaNV = maNV;
            this.NgayQD = ngayQD;
            this.NoiDungThuong = noiDungThuong;
            this.TienThuong = tienThuong;
        }

        public string MaKT { get => maKT; set => maKT = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public DateTime NgayQD { get => ngayQD; set => ngayQD = value; }
        public string NoiDungThuong { get => noiDungThuong; set => noiDungThuong = value; }
        public int TienThuong { get => tienThuong; set => tienThuong = value; }
    }
}
