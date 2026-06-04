namespace DA_UDQLCuaHangTienLoi
{
    partial class frmConfigNew
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cboSVName = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cboDBName = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLuu = new Guna.UI2.WinForms.Guna2Button();
            this.rdiWin = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rdiSQL = new Guna.UI2.WinForms.Guna2RadioButton();
            this.txtUName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblUName = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtPass = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(119, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(290, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "KẾT NỐI HỆ THỐNG";
            // 
            // cboSVName
            // 
            this.cboSVName.BackColor = System.Drawing.Color.Transparent;
            this.cboSVName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSVName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSVName.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboSVName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboSVName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboSVName.ForeColor = System.Drawing.Color.Black;
            this.cboSVName.ItemHeight = 30;
            this.cboSVName.Location = new System.Drawing.Point(70, 132);
            this.cboSVName.Name = "cboSVName";
            this.cboSVName.Size = new System.Drawing.Size(365, 36);
            this.cboSVName.TabIndex = 1;
            this.cboSVName.DropDown += new System.EventHandler(this.cboSVName_DropDown);
            // 
            // cboDBName
            // 
            this.cboDBName.BackColor = System.Drawing.Color.Transparent;
            this.cboDBName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboDBName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDBName.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboDBName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboDBName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboDBName.ForeColor = System.Drawing.Color.Black;
            this.cboDBName.ItemHeight = 30;
            this.cboDBName.Location = new System.Drawing.Point(70, 203);
            this.cboDBName.Name = "cboDBName";
            this.cboDBName.Size = new System.Drawing.Size(365, 36);
            this.cboDBName.TabIndex = 1;
            this.cboDBName.SelectedIndexChanged += new System.EventHandler(this.cboDBName_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(73, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Server name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(73, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Database name";
            // 
            // btnLuu
            // 
            this.btnLuu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLuu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLuu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLuu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(70, 393);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(365, 45);
            this.btnLuu.TabIndex = 2;
            this.btnLuu.Text = "Kết nối";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // rdiWin
            // 
            this.rdiWin.AutoSize = true;
            this.rdiWin.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdiWin.CheckedState.BorderThickness = 0;
            this.rdiWin.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdiWin.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rdiWin.CheckedState.InnerOffset = -4;
            this.rdiWin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.rdiWin.ForeColor = System.Drawing.Color.Black;
            this.rdiWin.Location = new System.Drawing.Point(70, 245);
            this.rdiWin.Name = "rdiWin";
            this.rdiWin.Size = new System.Drawing.Size(166, 19);
            this.rdiWin.TabIndex = 3;
            this.rdiWin.Text = "Window Authenication";
            this.rdiWin.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rdiWin.UncheckedState.BorderThickness = 2;
            this.rdiWin.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rdiWin.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rdiWin.CheckedChanged += new System.EventHandler(this.rdiWin_CheckedChanged);
            // 
            // rdiSQL
            // 
            this.rdiSQL.AutoSize = true;
            this.rdiSQL.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdiSQL.CheckedState.BorderThickness = 0;
            this.rdiSQL.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdiSQL.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rdiSQL.CheckedState.InnerOffset = -4;
            this.rdiSQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.rdiSQL.ForeColor = System.Drawing.Color.Black;
            this.rdiSQL.Location = new System.Drawing.Point(247, 245);
            this.rdiSQL.Name = "rdiSQL";
            this.rdiSQL.Size = new System.Drawing.Size(188, 19);
            this.rdiSQL.TabIndex = 3;
            this.rdiSQL.Text = "SQL Server Authenication";
            this.rdiSQL.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rdiSQL.UncheckedState.BorderThickness = 2;
            this.rdiSQL.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rdiSQL.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rdiSQL.CheckedChanged += new System.EventHandler(this.rdiSQL_CheckedChanged);
            // 
            // txtUName
            // 
            this.txtUName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUName.DefaultText = "";
            this.txtUName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUName.ForeColor = System.Drawing.Color.Black;
            this.txtUName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUName.Location = new System.Drawing.Point(185, 281);
            this.txtUName.Name = "txtUName";
            this.txtUName.PlaceholderText = "";
            this.txtUName.SelectedText = "";
            this.txtUName.Size = new System.Drawing.Size(250, 31);
            this.txtUName.TabIndex = 4;
            // 
            // lblUName
            // 
            this.lblUName.AutoSize = true;
            this.lblUName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.lblUName.ForeColor = System.Drawing.Color.Black;
            this.lblUName.Location = new System.Drawing.Point(73, 281);
            this.lblUName.Name = "lblUName";
            this.lblUName.Size = new System.Drawing.Size(83, 20);
            this.lblUName.TabIndex = 0;
            this.lblUName.Text = "Username";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.lblPass.ForeColor = System.Drawing.Color.Black;
            this.lblPass.Location = new System.Drawing.Point(74, 334);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(78, 20);
            this.lblPass.TabIndex = 0;
            this.lblPass.Text = "Password";
            // 
            // txtPass
            // 
            this.txtPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPass.DefaultText = "";
            this.txtPass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPass.ForeColor = System.Drawing.Color.Black;
            this.txtPass.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPass.Location = new System.Drawing.Point(185, 334);
            this.txtPass.Name = "txtPass";
            this.txtPass.PlaceholderText = "";
            this.txtPass.SelectedText = "";
            this.txtPass.Size = new System.Drawing.Size(250, 31);
            this.txtPass.TabIndex = 4;
            // 
            // frmConfigNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(503, 450);
            this.ControlBox = false;
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUName);
            this.Controls.Add(this.rdiSQL);
            this.Controls.Add(this.rdiWin);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.cboDBName);
            this.Controls.Add(this.cboSVName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblUName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmConfigNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmConfigNew";
            this.Load += new System.EventHandler(this.frmConfigNew_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cboSVName;
        private Guna.UI2.WinForms.Guna2ComboBox cboDBName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button btnLuu;
        private Guna.UI2.WinForms.Guna2RadioButton rdiWin;
        private Guna.UI2.WinForms.Guna2RadioButton rdiSQL;
        private Guna.UI2.WinForms.Guna2TextBox txtUName;
        private System.Windows.Forms.Label lblUName;
        private System.Windows.Forms.Label lblPass;
        private Guna.UI2.WinForms.Guna2TextBox txtPass;
    }
}