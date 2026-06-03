using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ET_KyLuat
    {
        private string maKL;
        private string maNV;
        private DateTime ngayViPham;
        private string hinhThuc;
        private string noiDungPhat;
        private int soTienPhat;

        public ET_KyLuat(string maKL, string maNV, DateTime ngayViPham, string hinhThuc, string noiDungPhat, int soTienPhat)
        {
            this.MaKL = maKL;
            this.MaNV = maNV;
            this.NgayViPham = ngayViPham;
            this.HinhThuc = hinhThuc;
            this.NoiDungPhat = noiDungPhat;
            this.SoTienPhat = soTienPhat;
        }

        public string MaKL { get => maKL; set => maKL = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public DateTime NgayViPham { get => ngayViPham; set => ngayViPham = value; }
        public string HinhThuc { get => hinhThuc; set => hinhThuc = value; }
        public string NoiDungPhat { get => noiDungPhat; set => noiDungPhat = value; }
        public int SoTienPhat { get => soTienPhat; set => soTienPhat = value; }
    }
}
