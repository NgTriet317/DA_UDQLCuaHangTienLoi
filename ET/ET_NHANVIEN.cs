using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ET_NHANVIEN
    {
        private string maNV;
        private string tenNV;
        private string hinh;
        private DateTime ngaySinh;
        private string gioiTinh = "Nam";
        private string diaChi;
        private int sdt;
        private string chucVu;
        private string email;

        public ET_NHANVIEN(string maNV, string tenNV, string hinh, DateTime ngaySinh, string gioiTinh, string diaChi, int sdt, string chucVu, string email)
        {
            this.maNV = maNV;
            this.tenNV = tenNV;
            this.hinh = hinh;
            this.ngaySinh = ngaySinh;
            this.gioiTinh = gioiTinh;
            this.diaChi = diaChi;
            this.sdt = sdt;
            this.chucVu = chucVu;
            this.email = email;
        }

        public string MaNV { get => maNV; set => maNV = value; }
        public string TenNV { get => tenNV; set => tenNV = value; }
        public string Hinh { get => hinh; set => hinh = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public int Sdt { get => sdt; set => sdt = value; }
        public string ChucVu { get => chucVu; set => chucVu = value; }
        public string Email { get => email; set => email = value; }
    }
}
