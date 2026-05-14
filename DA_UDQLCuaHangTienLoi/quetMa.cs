using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;


namespace DA_UDQLCuaHangTienLoi
{
    public partial class quetMa : Form
    {
        private VideoCaptureDevice videoCaptureDevice;

        public string MaSPQuetDuoc { get; private set; }
        public quetMa()
        {
            InitializeComponent();
        }

        private void quetMa_Load(object sender, EventArgs e)
        {
            FilterInfoCollection filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (filterInfoCollection.Count == 0)
            {
                MessageBox.Show("Không tìm thấy Camera nào trên máy tính!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Mặc định lấy camera đầu tiên (vì máy bạn chỉ có 1 cam)
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[0].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();

            // Bật bộ đếm giờ để bắt đầu quét ảnh tìm QR
            timerQuetMa.Start();
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // Đổ hình ảnh từ cam vào PictureBox
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            picCamera.Image = bitmap;
        }

        private void timerQuetMa_Tick(object sender, EventArgs e)
        {
            if (picCamera.Image != null)
            {
                try
                {
                    BarcodeReader barcodeReader = new BarcodeReader();
                    var result = barcodeReader.Decode((Bitmap)picCamera.Image);

                    // NẾU TÌM THẤY MÃ QR
                    if (result != null)
                    {
                        timerQuetMa.Stop(); // Dừng quét
                        MaSPQuetDuoc = result.Text; // Lưu mã vào biến public

                        this.DialogResult = DialogResult.OK; // Báo hiệu là quét thành công
                        this.Close(); // Tự động đóng Form Camera
                    }
                }
                catch
                {
                    // Lỗi mờ ảnh, bỏ qua để quét frame tiếp theo
                }
            }
        }

        private void frmQuetMa_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Bắt buộc phải tắt Camera khi đóng form, nếu không cam sẽ sáng mãi
            if (videoCaptureDevice != null && videoCaptureDevice.IsRunning)
            {
                videoCaptureDevice.SignalToStop();
                videoCaptureDevice.WaitForStop();
            }
        }
    }
}
