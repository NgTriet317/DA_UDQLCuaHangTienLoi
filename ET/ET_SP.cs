using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ET_SP
    {    
        private string maSP;
        private string tenSP;
        private string hinh;
        private DateTime ngaySX;
        private DateTime hanSD;
        private int soLuong;
        private string donViTinh;
        private int donGia;
        private string maLoaiSP;
        private string maKM;
        private string maNCC;

        public ET_SP(string maSP, string tenSP, string hinh, DateTime ngaySX, DateTime hanSD, int soLuong, string donViTinh, int donGia, string maLoaiSP, string maKM, string maNCC)
        {
            this.maSP = maSP;
            this.tenSP = tenSP;
            this.hinh = hinh;
            this.ngaySX = ngaySX;
            this.hanSD = hanSD;
            this.soLuong = soLuong;
            this.donViTinh = donViTinh;
            this.donGia = donGia;
            this.maLoaiSP = maLoaiSP;
            this.maKM = maKM;
            this.maNCC = maNCC;
        }

        public string MaSP { get => maSP; set => maSP = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public string Hinh { get => hinh; set => hinh = value; }
        public DateTime NgaySX { get => ngaySX; set => ngaySX = value; }
        public DateTime HanSD { get => hanSD; set => hanSD = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public string DonViTinh { get => donViTinh; set => donViTinh = value; }
        public int DonGia { get => donGia; set => donGia = value; }
        public string MaLoaiSP { get => maLoaiSP; set => maLoaiSP = value; }
        public string MaKM { get => maKM; set => maKM = value; }
        public string MaNCC { get => maNCC; set => maNCC = value; }
    }

}
