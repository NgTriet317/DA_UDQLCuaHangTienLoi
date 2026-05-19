using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ET_TK
    {
        private string taiKhoan;
        private string matKhau;
        private string vaiTro;
        private string hoatDong;        

        public ET_TK(string taiKhoan , string matKhau, string vaiTro, string hoatDong)
        {
            this.taiKhoan = taiKhoan;
            this.matKhau = matKhau;
            this.vaiTro = vaiTro;
            this.hoatDong = hoatDong;
        }

        public string TaiKhoan { get => taiKhoan; set => taiKhoan = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string VaiTro { get => vaiTro; set => vaiTro = value; }
        public string HoatDong { get => hoatDong; set => hoatDong = value; }
    }
}
