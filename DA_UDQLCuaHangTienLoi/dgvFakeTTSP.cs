using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA_UDQLCuaHangTienLoi
{
    public partial class dgvFakeTTSP : UserControl
    {
        public dgvFakeTTSP()
        {
            InitializeComponent();

        }

        public event EventHandler OnXoaClicked;
        public event EventHandler OnUpdateClicked;
        public event EventHandler OnViewClicked;
        private void dgvFakeTTSP_Load(object sender, EventArgs e)
        {
         
        }

        public string MaSP_Data { get; private set; }

        //constructor dung de dua data vao card
        public void loadData(string maSP, Image imgName, string TenSP, string lsp,string sl, string gia, string hsd)
        {
            this.MaSP_Data = maSP;

            picImg.Image = imgName;
            lblName.Text = TenSP;
            lblLSP.Text = lsp;
            lblSL.Text = sl;
            lblGia.Text = gia;
            lblHSD.Text = hsd;

            if (frmMain.chucVu == "CV02")
            {
                btnSua.Visible = false;
                btnXoa.Visible = false;
            }
        }

        //Tạo sự kiện click cho các icon
        private void btnXem_Click(object sender, EventArgs e)
        {
            if (OnViewClicked != null)
            {
                OnViewClicked.Invoke(this, EventArgs.Empty);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(OnUpdateClicked != null)
            {
                OnUpdateClicked.Invoke(this, EventArgs.Empty);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (OnXoaClicked != null)
            {
                OnXoaClicked.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
