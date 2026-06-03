using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using ET;

namespace DAL
{
    public class DAL_TRAHANGNCC : DBConnect
    {
        //lay thong tin chi tiet phieu theo ma phieu
        public DataTable layCTPhieuTraHang(string ma)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_layCTPhieuTraHang", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaTraNCC", ma);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch
            {
                throw;
            }
            finally { conn.Close(); }
            return dt;
        }

        //lay toan bo thong tin tra hang
        public DataTable layTTTraHang()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM TRAHANGNCC", conn);
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

            }
            catch
            {
                throw;
            }
            finally { conn.Close(); }
            return dt;
        }

        //tao phieu tra hang
        public string taoPhieuTraHang() // Đổi kiểu trả về từ bool thành string
        {
            string maPhieuVuaSinh = "";
            try
            {
                conn.Open();
                string sql = "INSERT INTO TRAHANGNCC(TrangThai) OUTPUT INSERTED.MaTraNCC VALUES (N'Phiếu tạm')";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;

                // Dùng ExecuteScalar để lấy giá trị ô đầu tiên (chính là MaTraNCC được OUTPUT ra)
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    maPhieuVuaSinh = result.ToString();
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return maPhieuVuaSinh; // Trả về mã phiếu (Ví dụ: "MTNCC0001"), nếu thất bại sẽ là chuỗi rỗng ""
        }

        //Luu chi tiet tra hang
        public bool luuCTTraHang(ET_CHITIETTRAHANGNCC et)
        {
            bool kq = false;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_luuChiTiet", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaTraNCC", et.MaTraNCC);
                cmd.Parameters.AddWithValue("@MaSP", et.MaSP);
                cmd.Parameters.AddWithValue("@SoLuong", et.SoLuong);
                cmd.Parameters.AddWithValue("@GiaHoan", et.GiaHoan);
                cmd.Parameters.AddWithValue("@LyDoChiTiet", et.LyDo);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    kq = true;
                }
            }
            catch
            {
                throw;
            }
            finally { conn.Close(); }
            return kq;
        }

        //cap nhat tt phieu tra hang
        public bool capNhatTTPhieuTraHang(string ma, string maKho, string ncc, string nh, string nv, string lydo, int tongTien)
        {
            bool kq = false;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_CapNhatTTPhieuSauKhiLuu", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaTraNCC", ma);
                cmd.Parameters.AddWithValue("@MaKhoHang", maKho);
                cmd.Parameters.AddWithValue("@MaNCC", ncc);
                cmd.Parameters.AddWithValue("@MaNH", nh);
                cmd.Parameters.AddWithValue("@MaNV", nv);
                cmd.Parameters.AddWithValue("@LyDoTraHang", lydo);
                cmd.Parameters.AddWithValue("@TongTien", tongTien);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    kq = true;
                }
            }
            catch
            {
                throw;
            }
            finally { conn.Close(); }
            return kq;
        }

        //cap nhat tt phieu tra hang without MaNH
        public bool capNhatTTPhieuTraHangKoNH(string ma, string maKho, string ncc, string nv, string lydo, int tongTien)
        {
            bool kq = false;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_CapNhatTTPhieuSauKhiLuuKoNH", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaTraNCC", ma);
                cmd.Parameters.AddWithValue("@MaKhoHang", maKho);
                cmd.Parameters.AddWithValue("@MaNCC", ncc);
                cmd.Parameters.AddWithValue("@MaNV", nv);
                cmd.Parameters.AddWithValue("@LyDoTraHang", lydo);
                cmd.Parameters.AddWithValue("@TongTien", tongTien);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    kq = true;
                }
            }
            catch
            {
                throw;
            }
            finally { conn.Close(); }
            return kq;
        }

        //xoa chi tiet tra hang
        public bool xoaCTTraHang(string ma)
        {
            bool kq = false;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_xoaCTTraHang", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaTraNCC", ma);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    kq = true;
                }
            }
            catch
            {
                throw;
            }
            finally { conn.Close(); }
            return kq;
        }

        //cap nhat trang thai tra hang
        public bool capNhatTrangThai(string ma, string trangThai)
        {
            bool kq = false;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE TRAHANGNCC SET TrangThai = @TrangThai WHERE MaTraNCC = @MaTraNCC", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@MaTraNCC", ma);
                cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    kq = true;
                }
            }
            catch
            {
                throw;
            }
            finally { conn.Close(); }
            return kq;
        }
    }
}
