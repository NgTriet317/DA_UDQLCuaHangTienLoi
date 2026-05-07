using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_NHAPHANG : DBConnect
    {
        /// <summary>
        /// Lấy TT nhập hàng
        /// </summary>
        /// <returns></returns>
        public DataTable layTT()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_layTTDonNhapHang", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

            }catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return dt;
        }

        /// <summary>
        /// Thêm dơn nhập hàng
        /// </summary>
        /// <param name="ma"></param>
        /// <param name="maNV"></param>
        /// <param name="maKho"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool themDonNhapHang(string ma, string maNV, string maKho)
        {
            bool kq = false;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ThemDonNhapHang", conn);
                cmd.CommandType= CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@MaNH",ma);
                cmd.Parameters.Add(param);
                SqlParameter paramNV = new SqlParameter("@MaNV", maNV);
                cmd.Parameters.Add(paramNV);
                SqlParameter paramKho = new SqlParameter("@MaKhoHang", maKho);
                cmd.Parameters.Add(paramKho);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    kq = true;
                }
                
            }catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return kq;
        }

        /// <summary>
        /// Xóa đơn nhập hàng
        /// </summary>
        /// <param name="ma"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool XoaDonNhapHang(string ma)
        {
            bool kq = false;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_XoaDonNhapHang", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@MaNH", ma);
                cmd.Parameters.Add(param);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    kq = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return kq;
        }
        /// <summary>
        /// Thay đổi trạng thái
        /// </summary>
        /// <param name="ma"></param>
        /// <param name="trangThai"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool ThayDoiTrangThai(string ma, string trangThai)
        {
            bool kq = false;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_doiTrangThai", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramMa = new SqlParameter("@MaNH", ma);
                cmd.Parameters.Add(paramMa);
                SqlParameter paramTrangThai = new SqlParameter("@newTrangThai", trangThai);
                cmd.Parameters.Add(paramTrangThai);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    kq = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return kq;
        }

        /// <summary>
        /// Cập nhật tổng tiền
        /// </summary>
        /// <param name="ma"></param>
        /// <param name="tongTien"></param>
        /// <returns></returns>
        public bool capNhatTongTien(string ma, int tongTien)
        {
            bool kq = false;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"UPDATE NHAPHANG SET TongTien = {tongTien} where MaNH = '{ma}'", conn);
                cmd.CommandType = CommandType.Text;                                     

                if (cmd.ExecuteNonQuery() > 0)
                {
                    kq = true;
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
            return kq ;
        }

        /// <summary>
        /// Đưa sp vào kho
        /// </summary>
        /// <param name="ma"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool duaSPVaoKho(string ma)
        {
            bool kq = false;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_NhapKhoHangLoat", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@MaNH", ma);
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                kq = true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return kq;
        }

        /// <summary>
        /// Lấy ds nhập hàng
        /// </summary>
        /// <returns></returns>
        public DataTable LayDSNhapHang()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_DSNhapHang", conn);
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

        /// <summary>
        /// Thống kê nhập hàng
        /// </summary>
        /// <param name="thoiGianNhap"></param>
        /// <returns></returns>
        public DataTable ThongKeNhapHang(DateTime thoiGianNhap)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ThongKeNhapHang", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter para = new SqlParameter("@ThoiGianNhap", thoiGianNhap);
                cmd.Parameters.Add(para);
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
