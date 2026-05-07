using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ET_SP_NH
    {
        private string maNH;
        private string maSP;
        private int slNhap;
        private int giaNhap;
        

        public ET_SP_NH(string maNH, string maSP, int slNhap, int giaNhap)
        {
            this.maNH = maNH;
            this.maSP = maSP;
            this.slNhap = slNhap;
            this.giaNhap = giaNhap;            
        }

        public string MaNH { get => maNH; set => maNH = value; }
        public string MaSP { get => maSP; set => maSP = value; }
        public int SlNhap { get => slNhap; set => slNhap = value; }
        public int GiaNhap { get => giaNhap; set => giaNhap = value; }        
    }
}
