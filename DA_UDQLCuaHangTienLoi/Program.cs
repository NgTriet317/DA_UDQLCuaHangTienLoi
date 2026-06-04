using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA_UDQLCuaHangTienLoi
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 1. HAI DÒNG NÀY BẮT BUỘC PHẢI Ở TRÊN CÙNG
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new LuongBong());

            openDongGoi();
           
        }
        
        static void openDongGoi()
        {
            //2.Kiểm tra kết nối CSDL

            if (!CheckDatabaseConnection())
            {
                // Hiện Form Cấu hình nếu lỗi
                frmConfigNew configForm = new frmConfigNew();
                if (configForm.ShowDialog() != DialogResult.OK)
                {
                    // Người dùng bấm Hủy (hoặc dấu X) -> thoát app luôn
                    return;
                }
            }

            //Đọc chuỗi kết nối từ cấu hình App.config
            string chuoiConfig = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

            //string chuoiConfig = "Data Source=MSI;Initial Catalog=QLCHTL;Integrated Security=True;";

            // TRUYỀN CHO THẰNG CHA ĐÚNG 1 LẦN DUY NHẤT!
            DAL.DBConnect.ChuoiKetNoi = chuoiConfig;

            // 4. Mở Form Đăng Nhập
            login log = new login();
            if (log.ShowDialog() == DialogResult.OK)
            {
                // Đăng nhập đúng thì mở Form Chính (Form1)
                Application.Run(new frmMain());
            }
            else
            {
                Application.Exit();
            }
        }

        static bool CheckDatabaseConnection()
        {
            try
            {
                // Lấy connection string từ App.config
                string connString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
                //string connString = "Data Source=MSI;Initial Catalog=QLCHTL;Integrated Security=True;";

                if (string.IsNullOrEmpty(connString)) return false;

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open(); // Thử mở kết nối
                    return true; // Nếu code chạy qua dòng này tức là kết nối thành công
                }
            }
            catch
            {
                return false; // Kết nối thất bại
            }
        }       
    }
}
