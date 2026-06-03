using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ET_BangLuong
    {
        private string maBangLuong;
        private string maNV;
        private string maLuongThang;
        private int tongThuong;
        private int tongPhat;
        private int tongTienLuong;
        private int thucLanh;
        private DateTime ngayChotLuong;

        public ET_BangLuong(string maBangLuong, string maNV, string maLuongThang, int tongThuong, int tongPhat, int tongTienLuong, int thucLanh, DateTime ngayChotLuong)
        {
            this.MaBangLuong = maBangLuong;
            this.MaNV = maNV;
            this.MaLuongThang = maLuongThang;
            this.TongThuong = tongThuong;
            this.TongPhat = tongPhat;
            this.TongTienLuong = tongTienLuong;
            this.ThucLanh = thucLanh;
            this.NgayChotLuong = ngayChotLuong;
        }

        public string MaBangLuong { get => maBangLuong; set => maBangLuong = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public string MaLuongThang { get => maLuongThang; set => maLuongThang = value; }
        public int TongThuong { get => tongThuong; set => tongThuong = value; }
        public int TongPhat { get => tongPhat; set => tongPhat = value; }
        public int TongTienLuong { get => tongTienLuong; set => tongTienLuong = value; }
        public int ThucLanh { get => thucLanh; set => thucLanh = value; }
        public DateTime NgayChotLuong { get => ngayChotLuong; set => ngayChotLuong = value; }
    }
}
