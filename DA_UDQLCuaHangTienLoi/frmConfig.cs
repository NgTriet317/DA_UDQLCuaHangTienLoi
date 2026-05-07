using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA_UDQLCuaHangTienLoi
{
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Dùng SqlConnectionStringBuilder để tạo chuỗi kết nối an toàn, tránh lỗi gõ sai cú pháp
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = txtServer.Text.Trim();
                builder.InitialCatalog = txtDatabase.Text.Trim();

                if (chkIntegratedSecurity.Checked)
                {
                    builder.IntegratedSecurity = true; // Dùng Windows Authentication
                }
                else
                {
                    builder.UserID = txtUsername.Text.Trim();
                    builder.Password = txtPassword.Text.Trim();
                }

                // 2. Mở file cấu hình của ứng dụng (file .exe.config)
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                // 3. KIỂM TRA VÀ CẬP NHẬT CHUỖI KẾT NỐI
                if (config.ConnectionStrings.ConnectionStrings["MyDbConnection"] == null)
                {
                    // Tình huống file config chưa có: TẠO MỚI
                    ConnectionStringSettings newConn = new ConnectionStringSettings(
                        "MyDbConnection",
                        builder.ConnectionString,
                        "System.Data.SqlClient"
                    );
                    config.ConnectionStrings.ConnectionStrings.Add(newConn);
                }
                else
                {
                    // Tình huống file config đã có sẵn: CẬP NHẬT
                    config.ConnectionStrings.ConnectionStrings["MyDbConnection"].ConnectionString = builder.ConnectionString;
                    config.ConnectionStrings.ConnectionStrings["MyDbConnection"].ProviderName = "System.Data.SqlClient";
                }

                // 4. Lưu lại các thay đổi
                config.Save(ConfigurationSaveMode.Modified);

                // 3. Cập nhật chuỗi kết nối (Giả sử tên connection string trong App.config của bạn là "MyDbConnection")
                config.ConnectionStrings.ConnectionStrings["MyDbConnection"].ConnectionString = builder.ConnectionString;

                // Cập nhật luôn ProviderName nếu cần
                config.ConnectionStrings.ConnectionStrings["MyDbConnection"].ProviderName = "System.Data.SqlClient";

                // 4. Lưu lại các thay đổi
                config.Save(ConfigurationSaveMode.Modified);

                // 5. Làm mới bộ nhớ cache để app nhận chuỗi kết nối mới ngay lập tức mà không cần tắt mở lại app
                ConfigurationManager.RefreshSection("connectionStrings");

                MessageBox.Show("Đã lưu cấu hình kết nối thành công! Vui lòng khởi động lại ứng dụng hoặc thử kết nối lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu cấu hình: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
