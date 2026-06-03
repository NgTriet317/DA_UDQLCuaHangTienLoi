using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_TRAHANGNCC
    {
        DAL_TRAHANGNCC traHang = new DAL_TRAHANGNCC();

        //lay thong tin chi tiet phieu tra hang theo ma phieu
        public DataTable layCTPhieuTraHang(string ma)
        {
            return traHang.layCTPhieuTraHang(ma);
        }

        //tao phieu tra hang
        public string taoPhieuTraHang()
        {
            return traHang.taoPhieuTraHang();
        }

        //lay all tt tra hang 
        public DataTable layAllTT()
        {
            return traHang.layTTTraHang();
        }

        //luu chi tiet tra hang
        public bool luuCTTraHang(ET.ET_CHITIETTRAHANGNCC ct)
        {
            return traHang.luuCTTraHang(ct);
        }

        //cap nhat tt phieu tra hang
        public bool capNhatTTPhieuTraHang(string ma, string maKho, string ncc, string nh, string nv, string lydo, int tongTien)
        {
            return traHang.capNhatTTPhieuTraHang(ma, maKho, ncc, nh, nv, lydo, tongTien);
        }

        //cap nhat tt phieu tra hang without MaNH
        public bool capNhatTTPhieuTraHangKoNH(string ma, string maKho, string ncc, string nv, string lydo, int tongTien)
        {
            return traHang.capNhatTTPhieuTraHangKoNH(ma, maKho, ncc, nv, lydo, tongTien);
        }

        //xoa chi tiet tra hang
        public bool xoaCTTraHang(string ma)
        {
            return traHang.xoaCTTraHang(ma);
        }
        //cap nhat trang thai phieu tra hang
        public bool capNhatTrangThaiPhieuTraHang(string ma, string trangThai)
        {
            return traHang.capNhatTrangThai(ma, trangThai);
        }
    }
}
