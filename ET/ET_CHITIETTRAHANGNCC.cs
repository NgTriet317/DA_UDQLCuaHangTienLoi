using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ET_CHITIETTRAHANGNCC
    {
        public ET_CHITIETTRAHANGNCC()
        {
        }

        public string MaCTTHNCC { get; set; }
        public string MaTraNCC { get; set; }
        public string MaSP { get; set; }
        public int SoLuong { get; set; }
        public decimal GiaHoan { get; set; }
        public string LyDo { get; set; }


        public ET_CHITIETTRAHANGNCC(string maTraNCC, string maSP, int soLuong, decimal giaHoan, string lyDo)
        {
            MaTraNCC = maTraNCC;
            MaSP = maSP;
            SoLuong = soLuong;
            GiaHoan = giaHoan;
            LyDo = lyDo;
        }
    }
}
