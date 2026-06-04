using LiveChartsCore.Kernel.Observers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA_UDQLCuaHangTienLoi
{
    public partial class frmConfigNew : Form
    {
        public frmConfigNew()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            try
            {
                // 1. Dùng SqlConnectionStringBuilder để tạo chuỗi kết nối an toàn, tránh lỗi gõ sai cú pháp
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = cboSVName.Text.Trim();
                builder.InitialCatalog = cboDBName.Text.Trim();

                if (rdiWin.Checked)
                {
                    builder.IntegratedSecurity = true; // Dùng Windows Authentication
                }
                else
                {
                    builder.UserID = txtUName.Text.Trim();
                    builder.Password = txtPass.Text.Trim();
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

            //if (string.IsNullOrEmpty(cboSVName.Text) || string.IsNullOrEmpty(cboDBName.Text))
            //{
            //    MessageBox.Show("Vui lòng điền và chọn đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //string finalConnStr = GetConnectionString(cboDBName.Text);

            //try
            //{
            //    using (SqlConnection conn = new SqlConnection(finalConnStr))
            //    {
            //        conn.Open();
            //        MessageBox.Show("Kết nối đến hệ thống thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //        // TODO: Bạn lưu chuỗi 'finalConnStr' này vào App.config hoặc một class Static để toàn bộ hệ thống sử dụng.

            //        this.DialogResult = DialogResult.OK;
            //        this.Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Kết nối thất bại! Hãy kiểm tra lại cấu hình.\n\nChi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }

        private void frmConfigNew_Load(object sender, EventArgs e)
        {
            rdiWin.Checked = true; // Mặc định chọn Windows Authentication
            lblUName.Enabled = false;
            lblPass.Enabled = false;
            txtUName.Enabled = false;
            txtPass.Enabled = false;

            LoadServerNames();
        }

        private void LoadServerNames()
        {
            cboSVName.Items.Clear();
            cboSVName.Items.Add(".");
            cboSVName.Items.Add("(local)");
            cboSVName.Items.Add(Environment.MachineName);

            try
            {
                SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
                DataTable table = instance.GetDataSources();
                foreach (DataRow row in table.Rows)
                {
                    string serverName = row["ServerName"].ToString();
                    string instanceName = row["InstanceName"].ToString();
                    string fullPath = string.IsNullOrEmpty(instanceName) ? serverName : $"{serverName}\\{instanceName}";

                    if (!cboSVName.Items.Contains(fullPath))
                        cboSVName.Items.Add(fullPath);
                }
            }
            catch { }
            cboSVName.SelectedIndex = 0;
        }

        // 5. Hàm xây dựng chuỗi kết nối tự động dựa trên cấu hình người dùng nhập
        private string GetConnectionString(string databaseName = "master")
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = cboSVName.Text;
            builder.InitialCatalog = databaseName;

            if (rdiWin.Checked)
            {
                builder.IntegratedSecurity = true;
            }
            else
            {
                builder.IntegratedSecurity = false;
                builder.UserID = txtUName.Text;
                builder.Password = txtPass.Text;
            }
            return builder.ConnectionString;
        }

        private void cboDBName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rdiWin_CheckedChanged(object sender, EventArgs e)
        {
            if (rdiWin.Checked)
            {
                txtUName.Enabled = false;
                txtPass.Enabled = false;                
            }
        }

        private void rdiSQL_CheckedChanged(object sender, EventArgs e)
        {
            if (rdiSQL.Checked)
            {
                txtUName.Enabled = true;
                txtPass.Enabled = true;
            }
        }

        private void cboSVName_DropDown(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboSVName.Text)) return;

            if (rdiSQL.Checked && string.IsNullOrEmpty(txtUName.Text))
            {
                MessageBox.Show("Vui lòng nhập Username!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            cboDBName.Items.Clear();
            string masterConnStr = GetConnectionString("master"); // Kết nối tạm vào database 'master' để lấy list DB
            string query = "SELECT name FROM sys.databases WHERE state_desc = 'ONLINE' AND database_id > 4";

            try
            {
                using (SqlConnection conn = new SqlConnection(masterConnStr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cboDBName.Items.Add(reader["name"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể lấy danh sách database. Vui lòng kiểm tra lại thông tin Server hoặc Tài khoản!\n\nChi tiết: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
