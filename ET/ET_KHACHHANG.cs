using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ET_KHACHHANG
    {
        private string maKH;
        private string tenKH;
        private string sdt;
        private int diemTichLuy;
        private int diemHienTai;

        public ET_KHACHHANG(string tenKH, string sdt, int diemTichLuy, int diemHienTai)
        {
            this.tenKH = tenKH;
            this.sdt = sdt;
            this.diemTichLuy = diemTichLuy;
            this.diemHienTai = diemHienTai;
        }

        public ET_KHACHHANG(string maKH, string tenKH, string sdt, int diemTichLuy, int diemHienTai)
        {
            this.maKH = maKH;
            this.tenKH = tenKH;
            this.sdt = sdt;
            this.diemTichLuy = diemTichLuy;
            this.diemHienTai = diemHienTai;
        }

        public string TenKH { get => tenKH; set => tenKH = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public int DiemTichLuy { get => diemTichLuy; set => diemTichLuy = value; }
        public int DiemHienTai { get => diemHienTai; set => diemHienTai = value; }
        public string MaKH { get => maKH; set => maKH = value; }
    }
}



