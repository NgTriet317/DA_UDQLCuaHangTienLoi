using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA_UDQLCuaHangTienLoi
{
    public partial class login : Form
    {
        
        public login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        BUS_TK tK = new BUS_TK();        
        private void btnLogin_Click(object sender, EventArgs e)
        {   
            if(frmMain.inActive == "1")
            {
                DialogResult result = MessageBox.Show("Tài khoản đăng nhập trên thiết bị khác, Bạn có muốn cưỡng chế đăng xuất trên thiết bị khác không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    // Cưỡng chế đăng xuất trên thiết bị khác
                    frmMain.inActive = "0";
                    tK.capNhatHoatDong(frmMain.mail, "Không hoạt động");
                }
                else
                {
                    return;
                }                
            }

            //check hoat dong tai khoan
            string mail = txtMail.Text;
            string pass = txtPass.Text; 
            
            //nếu tìm thấy mail
            if (tK.checkTK(mail))
            {
                //xóa tb lỗi
                errorProvider1.Clear();

                //nếu tìm thấy pass
                if(tK.checkMK(pass))
                {
                    //xóa thông báo lỗi
                    errorProvider1.Clear();
                    
                    //Gán thông tin tài khoảng vào các frm
                    TTSanPham.role = tK.checkRole(mail);
                    frmMain.inActive = "1";
                    frmMain.mail = mail;
                    NhapHang.mail = mail;

                    //Mở form sau login
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    //nếu ko đúng pass thì lỗi
                    errorProvider1.SetError(txtPass, "Password khong ton tai");
                    txtPass.Clear();
                    txtPass.Focus();
                }
            }
            else
            {
                //nếu mail ko tồn tại thì lỗi
                errorProvider1.SetError(txtMail, "Tai khoang khong ton tai");
                txtMail.Clear();
                txtMail.Focus();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void login_Load(object sender, EventArgs e)
        {
            txtMail.Text = "a@gmail.com";
            txtPass.Text = "1";
        }

        //thoát app
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
