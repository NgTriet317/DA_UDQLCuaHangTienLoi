using System;
using ET;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DAL
{
    public class DAL_SP : DBConnect
    {

        //lay dssp
        public DataTable layDSSP()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_LaySP", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // Kiểm tra trạng thái trước khi đóng để tránh lỗi
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return dt;
        }

        //them sp
        public bool themSP(ET_SP sp)
        {
            bool kq = false;

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_themSP", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter[] param = {
                    new SqlParameter("@MaSP", sp.MaSP),
                    new SqlParameter("@TenSP", sp.TenSP),
                    new SqlParameter("@Hinh", sp.Hinh),
                    new SqlParameter("@SoLuong",sp.SoLuong),
                    new SqlParameter("@MaDVT",sp.DonViTinh),
                    new SqlParameter("@DonGia",sp.DonGia),
                    new SqlParameter("@GiaGoc",sp.GiaGoc),
                    new SqlParameter("@MaLoaiSP",sp.MaLoaiSP),
                    new SqlParameter("@MaKM",sp.MaKM),
                    new SqlParameter("@MaNCC", sp.MaNCC)
                };

                cmd.Parameters.AddRange(param);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    kq = true;
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return kq;
        }

        //sua sp
        public bool suaSP(ET_SP sp)
        {
            bool kq = false;

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_suaSP", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter[] param = {
                    new SqlParameter("@MaSP", sp.MaSP),
                    new SqlParameter("@TenSP", sp.TenSP),
                    new SqlParameter("@Hinh", sp.Hinh),
                    new SqlParameter("@SoLuong",sp.SoLuong),
                    new SqlParameter("@MaDVT",sp.DonViTinh),
                    new SqlParameter("@DonGia",sp.DonGia),
                    new SqlParameter("@GiaGoc",sp.GiaGoc),
                    new SqlParameter("@MaLoaiSP",sp.MaLoaiSP),
                    new SqlParameter("@MaKM",sp.MaKM),
                    new SqlParameter("@MaNCC", sp.MaNCC)
                };

                cmd.Parameters.AddRange(param);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    kq = true;
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return kq;
        }

        //Xoa sp theo ma sp
        public bool xoaSP(string ma)
        {
            bool kq = false;

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_xoaSP", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@MaSP", ma);

                cmd.Parameters.Add(param);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    kq = true;
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return kq;
        }
        //search sp theo ten sp
        public DataTable findSP(string name)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_findSP", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@TenSP", "%" + name + "%");
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return dt;
        }
        //search sp theo ten va loai
        public DataTable findSPTheoTenVaLoai(string ten, string maLoai)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_TimKiem2Tang", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param1 = new SqlParameter("@TenSP", "%" + ten + "%");
                SqlParameter param2 = new SqlParameter("@MaLSP", maLoai);
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return dt;
        }

        //search sp theo ma sp
        public DataTable findSPMa(string ma)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_LaySPTheoMa", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@Ma", ma);
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return dt;
        }

        //capnhat sl sp theo masp
        public bool updateSLSP(string ma, int soLuongSp)
        {
            bool kq = false;
            try
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand($"UPDATE SANPHAM SET SoLuong = {soLuongSp} WHERE MaSP = '{ma}'", conn);
                sqlCommand.CommandType = CommandType.Text;

                if (sqlCommand.ExecuteNonQuery() > 0)
                {
                    kq = true;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return kq;
        }

        //search sp theo ma loai sp
        public DataTable findSPMaLoai(string ma)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_findLSP", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@MaLoaiSP", ma);
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return dt;
        }


        //Tim han su dung sp theo ma sp
        public DateTime timHanSD(string ma)
        {
            DateTime hanSD = DateTime.MinValue;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"sp_CheckHSD", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@MaSP", ma);
                cmd.Parameters.Add(param);

                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    hanSD = Convert.ToDateTime(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return hanSD;
        }

        //Tim ngay sx sp theo ma sp
        public DateTime timNgaySX(string ma)
        {
            DateTime ngaySX = DateTime.MinValue;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_CheckNSX", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@MaSP", ma);
                cmd.Parameters.Add(param);

                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    ngaySX = Convert.ToDateTime(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return ngaySX;
        }

        //tim don vi tinh sp theo ma dvt
        public string timDVT(string ma)
        {
            string dvt = "";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_LayDVT", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@MaDVT", ma);
                cmd.Parameters.Add(param);
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    dvt = result.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return dvt;
        }
        //lay toan bo dvt
        public DataTable layAllDVT()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_layAllDVT", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return dt;
        }

        //cap nhat so luong sp sau khi ban hang
        public bool capNhatSLSP(string ma, int soLuongBan)
        {
            bool kq = false;
            try
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand($"UPDATE SANPHAM SET SoLuong = SoLuong - {soLuongBan} WHERE MaSP = '{ma}'", conn);
                sqlCommand.CommandType = CommandType.Text;
                if (sqlCommand.ExecuteNonQuery() > 0)
                {
                    kq = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return kq;
        }

        //lay so luong sp theo ma sp
        public int laySoLuongSP(string ma)
        {
            int soLuong = 0;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_LaySLSanPham", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@MaSP", ma);
                cmd.Parameters.Add(param);
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    soLuong = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return soLuong;
        }

        //lay dssp khong hoat dong
        public DataTable layDSSPKhongHoatDong()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_LaySPKHD", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // Kiểm tra trạng thái trước khi đóng để tránh lỗi
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return dt;
        }

        //tim sp theo ten sp khong hoat dong
        public DataTable findSPKHD(string name)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_findSPKHD", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@TenSP", "%" + name + "%");
                cmd.Parameters.Add(param);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return dt;
        }
    }
}