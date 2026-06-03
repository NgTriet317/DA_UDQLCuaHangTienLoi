using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ET_TRAHANGNCC
    {
        public string maTraNCC {  get; set; }
        public string maKhoHang { get; set; }
        public string maNH { get; set; }
        public string maNCC { get; set; }
        public string maNV { get; set; }
        public DateTime tgTra { get; set; }
        public decimal tongTien { get; set; }
        public string lyDoTraHang { get; set; }        
        public string trangThai { get; set; }

        public ET_TRAHANGNCC(string maTraNCC, string maKhoHang, string maNH, string maNCC, string maNV, DateTime tgTra, decimal tongTien, string lyDoTraHang, string trangThai)
        {
            this.maTraNCC = maTraNCC;
            this.maKhoHang = maKhoHang;
            this.maNH = maNH;
            this.maNCC = maNCC;
            this.maNV = maNV;
            this.tgTra = tgTra;
            this.tongTien = tongTien;
            this.lyDoTraHang = lyDoTraHang;
            this.trangThai = trangThai;
        }

        public ET_TRAHANGNCC()
        {
        }

        public ET_TRAHANGNCC(string maTraNCC)
        {
            this.maTraNCC = maTraNCC;
        }
    }
}
