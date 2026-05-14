namespace DA_UDQLCuaHangTienLoi
{
    partial class quetMa
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
            this.components = new System.ComponentModel.Container();
            this.picCamera = new Guna.UI2.WinForms.Guna2PictureBox();
            this.timerQuetMa = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).BeginInit();
            this.SuspendLayout();
            // 
            // picCamera
            // 
            this.picCamera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCamera.ImageRotate = 0F;
            this.picCamera.Location = new System.Drawing.Point(0, 0);
            this.picCamera.Name = "picCamera";
            this.picCamera.Size = new System.Drawing.Size(800, 450);
            this.picCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCamera.TabIndex = 0;
            this.picCamera.TabStop = false;
            // 
            // timerQuetMa
            // 
            this.timerQuetMa.Interval = 500;
            this.timerQuetMa.Tick += new System.EventHandler(this.timerQuetMa_Tick);
            // 
            // quetMa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.picCamera);
            this.Name = "quetMa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "quetMa";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmQuetMa_FormClosing);
            this.Load += new System.EventHandler(this.quetMa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox picCamera;
        private System.Windows.Forms.Timer timerQuetMa;
    }
}