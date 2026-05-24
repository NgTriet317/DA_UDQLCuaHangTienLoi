using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET;

namespace DAL
{
    public class DAL_HoaDon : DBConnect
    {
        //Thêm hóa đơn không dùng điểm
        public bool ThemHoaDon(ET_HoaDon hd)
        {
            bool kt = false;
            try
            {
                conn.Open(); //mở connection

                //Đưa lệnh cho sql
                SqlCommand cmd = new SqlCommand("sp_ThemHoaDonKoTichDiem", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Truyền tham số
                SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@NgayLap", hd.NgayLap),
                    new SqlParameter("@ThanhTien", hd.ThanhTien),
                    new SqlParameter("@ThanhToan", hd.ThanhToan),
                    new SqlParameter("@TienKHTra", hd.TienKhachTra),
                    new SqlParameter("@TienThua", hd.TienThua),
                    new SqlParameter("@MaNV", hd.MaNV)
                };
                cmd.Parameters.AddRange(param);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    kt = true;
                }

            }
            //catch lỗi
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();//đóng kết nối
            }
            return kt;
        }

        //Thêm hóa đơn dùng điểm
        public bool ThemHoaDonDungDiem(ET_HoaDon hd)
        {
            bool kt = false;
            try
            {
                conn.Open(); //mở connection

                //Đưa lệnh cho sql
                SqlCommand cmd = new SqlCommand("sp_ThemHoaDonDungDiem", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Truyền tham số
                SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@NgayLap", hd.NgayLap),
                    new SqlParameter("@ThanhTien", hd.ThanhTien),
                    new SqlParameter("@ThanhToan", hd.ThanhToan),
                    new SqlParameter("@TienKHTra", hd.TienKhachTra),
                    new SqlParameter("@TienThua", hd.TienThua),
                    new SqlParameter("@MaKH", hd.MaKH),
                    new SqlParameter("@MaNV", hd.MaNV)
                };
                cmd.Parameters.AddRange(param);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    kt = true;
                }

            }
            //catch lỗi
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();//đóng kết nối
            }
            return kt;
        }

        //Lấy TT hóa đơn
        public DataTable LayTTHoaDon(string ma)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();//mở kết nối

                //Đưa lệnh cho sql
                SqlCommand cmd = new SqlCommand("sp_XuatHoaDonKoTiChDiem", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Truyền tham số
                SqlParameter param = new SqlParameter("@MaHD", ma);
                cmd.Parameters.Add(param);

                //fill vào datatable
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return dt;
        }

        //Lấy TT hóa đơn dùng điểm
        public DataTable LayTTHoaDonDungDiem(string ma, int diemDung)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();//mở kết nối

                //Đưa lệnh cho sql
                SqlCommand cmd = new SqlCommand("sp_XuatHoaDonDungDiem", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Truyền tham số
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@MaHD", ma),
                    new SqlParameter("@DiemDung", diemDung)
                };
                cmd.Parameters.AddRange(param);

                //fill vào datatable
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return dt;
        }

        /// <summary>
        /// Lấy mã hóa đơn
        /// </summary>
        /// <returns> String </returns>
        public string LayMaHoaDonMoiNhat()
        {
            string ma = "";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_HoaDonMoiNhat", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                ma = (string)cmd.ExecuteScalar();
                if (ma == null)
                {
                    return ma = "";
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return ma;
        }

        /// <summary>
        /// Lấy DS hóa đơn theo ngày
        /// </summary>
        /// <param name="ngayLap"></param>
        /// <returns> Datatable </returns>
        public DataTable LayDSHoaDonTheoNgay(DateTime ngayLap)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_DSDoanhThuTheoNgay", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter para = new SqlParameter("@NgayLap", ngayLap);
                cmd.Parameters.Add(para);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        /// <summary>
        /// lấy toàn bộ ds hóa đơn
        /// </summary>
        /// <returns></returns>
        public DataTable LayDSHoaDon()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_DSHoaDon", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        /// <summary>
        /// Lấy ds hóa đơn theo tháng
        /// </summary>
        /// <returns></returns>
        public DataTable LayDSHoaDonThang()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_DSHoaDonThang", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        /// <summary>
        /// lấy ds hóa đơn theo tháng
        /// </summary>
        /// <param name="thang"></param>
        /// <param name="nam"></param>
        /// <returns></returns>
        public DataTable LayDSHoaDonTheoThang(int thang, int nam)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_DSDoanhThuTheoThang", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@Thang", thang),
                    new SqlParameter("@Nam", nam)
                };
                cmd.Parameters.AddRange(para);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public DataTable LayDuLieuChoBieuDoDoanhThuVaHoaDon(DateTime tuNgay, DateTime denNgay)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ThongKeDoanhThuVaHoaDon", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@TuNgay", tuNgay),
                    new SqlParameter("@DenNgay", denNgay)
                };
                cmd.Parameters.AddRange(para);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public DataTable LayDuLieuBieuDoLoaiBanDuoc(DateTime tuNgay, DateTime denNgay)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ThongKeTheoLoaiSP", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@TuNgay", tuNgay),
                    new SqlParameter("@DenNgay", denNgay)
                };
                cmd.Parameters.AddRange(para);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public DataTable LayThongTinHoaDon()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ThongTinHoaDon", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public DataTable LayDSHoaDonTuNgayDenNgay(DateTime tuNgay, DateTime denNgay)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_DanhSachHoaDonTheoNgay", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@TuNgay", tuNgay),
                    new SqlParameter("@DenNgay", denNgay)
                };
                cmd.Parameters.AddRange(para);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public DataTable ThongKeTongQuat()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ThongKeTongQuat", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
    }
}
