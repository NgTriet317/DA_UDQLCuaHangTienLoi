    using ET;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL__NHANVIEN : DBConnect
    {
        /// <summary>
        /// Lay thong tin nhan vien
        /// </summary>
        /// <returns>datatable</returns>
        /// <exception cref="Exception"></exception>
        public DataTable layTTNhanVien()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_LayTTNhanVien", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { conn.Close(); }
            return dt;
        }
        /// <summary>
        /// lay chuc vu
        /// </summary>
        /// <param name="ma"></param>
        /// <returns>string</returns>
        /// <exception cref="Exception"></exception>
        public string layChucVu(string ma)
        {
            string cv = "";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT TenChucVu FROM CHUCVU WHERE MaChucVu like '{ma}'", conn);
                cmd.CommandType = CommandType.Text;

                cv = (string)cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { conn.Close(); }
            return cv;
        }
        /// <summary>
        /// lay nv theo ma
        /// </summary>
        /// <param name="ma"></param>
        /// <returns>datatable</returns>
        /// <exception cref="Exception"></exception>
        public DataTable layTTNhanVienTheoMa(string ma)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_LayTTNhanVienTheoMa", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter("@MaNV", ma);
                cmd.Parameters.Add(parameter);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { conn.Close(); }
            return dt;
        }

        /// <summary>
        /// Xóa nhân viên (Nghỉ việc)
        /// </summary>
        /// <param name="ma"></param>
        /// <returns>bool</returns>
        public bool xoaNhanVien(string ma)
        {
            bool kq = false;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_XoaNhanVien", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter("@MaNV", ma);
                cmd.Parameters.Add(parameter);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    kq = true;
                }
            }
            catch
            {
                return kq;
            }
            finally
            {
                conn.Close();
            }
            return kq;
        }
        public bool themNhanVien(ET_NHANVIEN et)
        {
            bool kq = false;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_InsertNhanVien", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter[] parameters =
                {
                    new SqlParameter("@MaNV",et.MaNV),
                    new SqlParameter("@HoTenNV",et.TenNV),
                    new SqlParameter("@Hinh",et.Hinh),
                    new SqlParameter("@NgaySinh",SqlDbType.Date) { Value = et.NgaySinh },
                    new SqlParameter("@GioiTinh",et.GioiTinh),
                    new SqlParameter("@DiaChi",et.DiaChi),
                    new SqlParameter("@SDT",et.Sdt),
                    new SqlParameter("@MaChucVu",et.ChucVu),
                    new SqlParameter("@Email",et.Email),
                    new SqlParameter("@NgayBatDau",DateTime.Today),
                    new SqlParameter("@NgayKetThuc", SqlDbType.Date) { Value = DBNull.Value },
                };
                cmd.Parameters.AddRange(parameters);

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
            return kq;
        }

        public bool taoTaiKhoan(string email, string vaiTro)
        {
            bool kq = false;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"INSERT INTO TAIKHOAN(TenTK,MatKhau,VaiTro) values ('{email}',1,'{vaiTro}')", conn);
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
            return kq;
        }
        public bool suaNhanVien(ET_NHANVIEN et)
        {
            bool kq = false;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_UpdateNhanVien", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter[] parameters =
                {
                    new SqlParameter("@MaNV",et.MaNV),
                    new SqlParameter("@HoTenNV",et.TenNV),
                    new SqlParameter("@Hinh",et.Hinh),
                    new SqlParameter("@NgaySinh",et.NgaySinh),
                    new SqlParameter("@GioiTinh",et.GioiTinh),
                    new SqlParameter("@DiaChi",et.DiaChi),
                    new SqlParameter("@SDT",et.Sdt),
                    new SqlParameter("@MaChucVu",et.ChucVu),
                    new SqlParameter("@Email",et.Email)
                };

                cmd.Parameters.AddRange(parameters);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    kq = true;
                }
            }
            catch
            {
                return kq;
            }
            finally
            {
                conn.Close();
            }
            return kq;
        }
        //lay full table chuc vu
        public DataTable layAllChucVu()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM CHUCVU", conn);
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { conn.Close(); }
            return dt;
        }
        //Khoi phuc nhan vien
        public bool khoiPhucNhanVien(string ma)
        {
            bool kq = false;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_KhoiPhucNhanVien", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter("@MaNV", ma);
                cmd.Parameters.Add(parameter);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    kq = true;
                }
            }
            catch
            {
                return kq;
            }
            finally
            {
                conn.Close();
            }
            return kq;
        }

        //tim kiem
        public DataTable timKiemNhanVienKoTuKhoa(string hoatDong, string chucVu)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_DSNVTheoTrangThaiVaChucVu", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterCV = new SqlParameter("@MaChucVu", chucVu);
                cmd.Parameters.Add(parameterCV);
                SqlParameter parameterHD = new SqlParameter("@TrangThai", hoatDong);
                cmd.Parameters.Add(parameterHD);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { conn.Close(); }
            return dt;
        }
        //tim kiem
        public DataTable timKiemNhanVienCoTuKhoa(string hoatDong, string chucVu, string tuKhoa)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_DSNVTheoTenTrangThaiVaChucVu", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameterCV = new SqlParameter("@MaChucVu", chucVu);
                cmd.Parameters.Add(parameterCV);
                SqlParameter parameterHD = new SqlParameter("@TrangThai", hoatDong);
                cmd.Parameters.Add(parameterHD);
                SqlParameter parameterTK = new SqlParameter("@TenNV", "%" + tuKhoa + "%");
                cmd.Parameters.Add(parameterTK);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { conn.Close(); }
            return dt;

        }
        //Lay nhan vien ca lam
        public DataTable layTTNhanVienCalam()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_layNhanVienCaLam", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { conn.Close(); }
            return dt;
        }

        //Lấy nhân viên còn hoạt động
        public DataTable layDSNhanVienHoatDong()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_LayDSNhanVienHD", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { conn.Close(); }
            return dt;
        }
    }
}
