using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    internal class ET_LSP
    {
        private string maLSP;
        private string tenLSP;

        public ET_LSP(string maLSP, string tenLSP)
        {
            this.maLSP = maLSP;
            this.tenLSP = tenLSP;
        }

        public string MaLSP { get => maLSP; set => maLSP = value; }
        public string TenLSP { get => tenLSP; set => tenLSP = value; }
    }
}
