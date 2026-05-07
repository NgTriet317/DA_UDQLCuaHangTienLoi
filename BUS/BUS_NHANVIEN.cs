using DAL;
using ET;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_NHANVIEN
    {
        DAL__NHANVIEN nv = new DAL__NHANVIEN();
        /// <summary>
        /// lay thong tin nvien
        /// </summary>
        /// <returns>Datatable</returns>
        public DataTable layNV()
        {
            return nv.layTTNhanVien();
        }
        /// <summary>
        /// Tim kiem chuc vu theo ma
        /// </summary>
        /// <param name="ma"></param>
        /// <returns>string</returns>
        public string layCHucVu(string ma)
        {
            return nv.layChucVu(ma);
        }

        //Lay tt nhan vien theo ma
        public DataTable layNVTheoMa(string ma)
        {
            return nv.layTTNhanVienTheoMa(ma);
        }
        //xoa nhan vien 
        public bool xoaNhanVien(string ma)
        {
            return nv.xoaNhanVien(ma);
        }
        //them Nhan Vien
        public bool themNhanVien(ET_NHANVIEN et)
        {
            return nv.themNhanVien(et);
        }
        //tao tai khoan
        public bool taoTaiKhoan(string email, string vaitro)
        {
            return nv.taoTaiKhoan(email, vaitro);
        }
        //sua nhan vien
        public bool suaNhanVien(ET_NHANVIEN et)
        {
            return nv.suaNhanVien(et);
        }
        //lay all chuc vu
        public DataTable layAllChucVu()
        {
            return nv.layAllChucVu();
        }

        //tim kiem nhan vien theo ten
        public DataTable timKiemNhanVienKoTuKhoa(string hoatDong, string chucVu)
        {
            return nv.timKiemNhanVienKoTuKhoa(hoatDong, chucVu);
        }

        public DataTable timKiemNhanVienCoTuKhoa(string hoatDong, string chucVu, string tuKhoa)
        {
            return nv.timKiemNhanVienCoTuKhoa(hoatDong, chucVu, tuKhoa);

        }
        //khoi phuc nhan vien
        public bool khoiPhucNhanVien(string ma)
        {
            return nv.khoiPhucNhanVien(ma);
        }
        //lay nhan vien ca lam
        public DataTable layTTNhanVienCalam()
        {
            return nv.layTTNhanVienCalam();
        }

    } 
}
