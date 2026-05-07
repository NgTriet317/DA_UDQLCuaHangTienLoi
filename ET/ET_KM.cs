using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ET_KM
    {
        private string maKM;
        private string tenKM;
        private float thanTram;

        public ET_KM(string maKM, string tenKM, float thanTram)
        {
            this.MaKM = maKM;
            this.TenKM = tenKM;
            this.ThanTram = thanTram;
        }

        public string MaKM { get => maKM; set => maKM = value; }
        public string TenKM { get => tenKM; set => tenKM = value; }
        public float ThanTram { get => thanTram; set => thanTram = value; }
    }
}
