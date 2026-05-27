using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ET_DVT
    {
        private string maDVT;
        private string tenDVT;

        public ET_DVT(string maDVT, string tenDVT)
        {
            this.maDVT = maDVT;
            this.tenDVT = tenDVT;
        }

        public string MaDVT { get => maDVT; set => maDVT = value; }
        public string TenDVT { get => tenDVT; set => tenDVT = value; }

    }
}
