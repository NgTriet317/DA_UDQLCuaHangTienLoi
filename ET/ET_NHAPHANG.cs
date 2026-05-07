using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ET_NHAPHANG
    {
        private string maNH;
        private string maNV;
        private string maKhoHang;
        private DateTime tgNhap;
        private int tongTien;
        private string trangThai;
                
        public ET_NHAPHANG(string maNH, string maNV, string maKhoHang, DateTime tgNhap, int tongTien, string trangThai)
        {
            this.maNH = maNH;
            this.maNV = maNV;
            this.maKhoHang = maKhoHang;
            this.tgNhap = tgNhap;
            this.tongTien = tongTien;
            this.trangThai = trangThai;
        }

        public string MaNH { get => maNH; set => maNH = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public string MaKhoHang { get => maKhoHang; set => maKhoHang = value; }
        public DateTime TgNhap { get => tgNhap; set => tgNhap = value; }
        public int TongTien { get => tongTien; set => tongTien = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
    }
}
