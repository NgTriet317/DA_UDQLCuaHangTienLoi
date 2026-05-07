using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBConnect
    {
        // 1. Biến tĩnh duy nhất để chứa chuỗi kết nối cho toàn bộ DAL
        public static string ChuoiKetNoi = "";

        // 2. Biến conn dùng từ khóa 'protected' để các class con có thể xài ké
        protected SqlConnection conn;

        // 3. Hàm khởi tạo tự động gắn chuỗi kết nối
        public DBConnect()
        {
            conn = new SqlConnection(ChuoiKetNoi);
        }
    }
}
