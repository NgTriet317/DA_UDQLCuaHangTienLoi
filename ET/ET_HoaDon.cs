using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ET_HoaDon
    {
        private DateTime ngayLap;
        private int thanhTien;
        private int thanhToan;
        private int tienKhachTra;
        private int tienThua;
        private string maNV;
        private string maKH;

        public ET_HoaDon(DateTime ngayLap, int thanhTien, int thanhToan, int tienKhachTra, int tienThua, string maKH, string maNV)
        {
            this.NgayLap = ngayLap;
            this.ThanhTien = thanhTien;
            this.ThanhToan = thanhToan;
            this.TienKhachTra = tienKhachTra;
            this.TienThua = tienThua;
            this.MaKH = maKH;
            this.MaNV = maNV;
        }

        public ET_HoaDon(DateTime ngayLap, int thanhTien, int thanhToan, int tienKhachTra, int tienThua, string maNV)
        {
            this.NgayLap = ngayLap;
            this.ThanhTien = thanhTien;
            this.ThanhToan = thanhToan;
            this.TienKhachTra = tienKhachTra;
            this.TienThua = tienThua;
            this.MaNV = maNV;
        }

        public DateTime NgayLap { get => ngayLap; set => ngayLap = value; }
        public int ThanhTien { get => thanhTien; set => thanhTien = value; }
        public int ThanhToan { get => thanhToan; set => thanhToan = value; }
        public int TienKhachTra { get => tienKhachTra; set => tienKhachTra = value; }
        public int TienThua { get => tienThua; set => tienThua = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public string MaKH { get => maKH; set => maKH = value; }
    }
}
