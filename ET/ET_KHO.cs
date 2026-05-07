using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    internal class ET_KHO
    {
        private string maKhoHang;
        private string maSanPham;
        private int soLuongTonKho;
        private decimal giaGoc;

        public ET_KHO(string maKhoHang, string maSanPham, int soLuongTonKho, decimal giaGoc)
        {
            this.maKhoHang = maKhoHang;
            this.maSanPham = maSanPham;
            this.soLuongTonKho = soLuongTonKho;
            this.giaGoc = giaGoc;
        }

        public string MaKhoHang { get => maKhoHang; set => maKhoHang = value; }
        public string MaSanPham { get => maSanPham; set => maSanPham = value; }
        public int SoLuongTonKho { get => soLuongTonKho; set => soLuongTonKho = value; }
        public decimal GiaGoc { get => giaGoc; set => giaGoc = value; }
    }
}
