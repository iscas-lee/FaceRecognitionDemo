using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


// EmguCv
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

// face verification dll
using System.Runtime.InteropServices;
        
namespace FaceRecognitionDemo
{
    public partial class MainWindows : Form
    {
        //private Mat imgFace1 = new Mat();
        //private Mat imgFace2 = new Mat();

        public Image<Bgr, Byte> imgFace1;
        public Image<Bgr, Byte> imgFace2;
        public float score;

        public static IntPtr EmgucvImageToIplImagePointer<TColor, TDepth>(Image<TColor, TDepth> image)
            where TColor : struct, IColor
            where TDepth : new()
        {
            return image.Ptr;
        }

        public MainWindows()
        {
            InitializeComponent();
        }

        // load image
        private void ImgBtn1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // read image
                Img1TextBox.Text = dialog.FileName;
                imgFace1 = new Image<Bgr, byte>(Img1TextBox.Text);
                ImgPicBox1.SizeMode = PictureBoxSizeMode.Zoom;
                ImgPicBox1.Image = imgFace1.ToBitmap();
            }
        }
        private void ImgBtn2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // read image
                Img2TextBox.Text = dialog.FileName;
                imgFace2 = new Image<Bgr, byte>(Img2TextBox.Text);
                ImgPicBox2.SizeMode = PictureBoxSizeMode.Zoom;
                ImgPicBox2.Image = imgFace2.ToBitmap();
            }
        }

        [DllImport("D:\\code\\FaceRecognitionDemo\\Debug\\FaceVerificationDLL.dll", EntryPoint="FaceVerfication")]
        private static extern float FaceVerfication(IntPtr imgFace1, IntPtr imgFace2, string modelPath, int layerIdx, int featLen);

        private void verifBtn_Click(object sender, EventArgs e)
        {
            string modelPath = "D:\\code\\cnnFace\\model\\cnnFace.bin";
            int layerIdx = 44;
            int featLen = 256;

            IntPtr img1 = EmgucvImageToIplImagePointer(imgFace1);
            IntPtr img2 = EmgucvImageToIplImagePointer(imgFace2);

            score = FaceVerfication(img1, img2, modelPath, layerIdx, featLen);
            textBox1.Text = score.ToString();
        }
    }
}
