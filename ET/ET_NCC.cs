using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ET_NCC
    {
        private string maNCC;
        private string tenNCC;
        private string diaChiNCC;
        private string tongDai;

        public ET_NCC(string maNCC, string tenNCC, string diaChiNCC, string tongDai)
        {
            this.maNCC = maNCC;
            this.tenNCC = tenNCC;
            this.diaChiNCC = diaChiNCC;
            this.tongDai = tongDai;
        }

        public string MaNCC { get => maNCC; set => maNCC = value; }
        public string TenNCC { get => tenNCC; set => tenNCC = value; }
        public string DiaChiNCC { get => diaChiNCC; set => diaChiNCC = value; }
        public string TongDai { get => tongDai; set => tongDai = value; }
    }
}
