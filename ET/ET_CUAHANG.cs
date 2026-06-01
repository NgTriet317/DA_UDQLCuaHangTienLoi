using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    internal class ET_CUAHANG
    {
        public string MaCH { get; set; }
        public string MaKV { get; set; }
        public string MaKhoHang { get; set; }
        public string TenCH { get; set; }
        public string DiaCHi { get; set; }
        public string TinhTrang { get; set; }

        public ET_CUAHANG() { }
        public ET_CUAHANG(string maCH, string maKV, string maKhoHang, string tenCH, string diaCHi, string tinhTrang)
        {
            MaCH = maCH;
            MaKV = maKV;
            MaKhoHang = maKhoHang;
            TenCH = tenCH;
            DiaCHi = diaCHi;
            TinhTrang = tinhTrang;
        }

    }
}
