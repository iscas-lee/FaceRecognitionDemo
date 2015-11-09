using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;


// EmguCv
using Emgu.CV;
using Emgu.CV.ML;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.Cuda;
using Emgu.Util;


// face verification dll
using System.Runtime.InteropServices;
        
namespace FaceRecognitionDemo
{
    public partial class MainWindows : Form
    {
        private Mat imgFace1 = new Mat();
        private Mat imgFace2 = new Mat();

        private Single thr = 0.5F;

        //public Image<Gray, Byte> imgFace1;
        //public Image<Gray, Byte> imgFace2;
        public Single score = 0.0F;

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

        private void ImgBtn1_Click(object sender, EventArgs e)
        {

            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // read image
                Img1TextBox.Text = gb2312_utf8(dialog.FileName);
                imgFace1 = CvInvoke.Imread(Img1TextBox.Text, LoadImageType.Grayscale);
                ImgPicBox1.SizeMode = PictureBoxSizeMode.Zoom;
                ImgPicBox1.Image = new Bitmap(Img1TextBox.Text);
            }
        }
        private void ImgBtn2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // read image
                Img2TextBox.Text = gb2312_utf8(dialog.FileName);
                imgFace2 = CvInvoke.Imread(Img2TextBox.Text, LoadImageType.Grayscale);
                ImgPicBox2.SizeMode = PictureBoxSizeMode.Zoom;
                ImgPicBox2.Image = new Bitmap(Img2TextBox.Text);
            }
        }


        [DllImport("FaceVerificationDLL.dll", EntryPoint = "FaceVerification", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern Single FaceVerification(IntPtr imgFace1, IntPtr imgFace2, string modelPath, int layerIdx, int featLen);
        private void verifBtn_Click(object sender, EventArgs e)
        {
            // image 1
            List<Rectangle> faces1 = new List<Rectangle>();
            List<Rectangle> eyes1 = new List<Rectangle>();

            FaceDetection.DetectFace.Detect( 
               imgFace1, "haarcascade_frontalface_default.xml", "haarcascade_eye.xml",
               faces1, eyes1);

            if (faces1.Count() != 1)
            {
                warning warn = new warning();
                warn.Show();
                return;
            }
            Bitmap temp = imgFace1.ToImage<Gray, Byte>().ToBitmap();
            Bitmap crop1 = crop_image(temp, faces1[0]);
            Image<Gray, Byte> imgTemp1 = new Image<Gray, Byte>(crop1);
            Image<Gray, Byte> resizedImg1 = imgTemp1.Resize(128, 128, Inter.Linear);
            IntPtr faceImg1 = EmgucvImageToIplImagePointer(resizedImg1);

            // image 2
            List<Rectangle> faces2 = new List<Rectangle>();
            List<Rectangle> eyes2 = new List<Rectangle>();

            FaceDetection.DetectFace.Detect(
               imgFace2, "haarcascade_frontalface_default.xml", "haarcascade_eye.xml",
               faces2, eyes2);

            if (faces2.Count() != 1)
            {
                warning warn = new warning();
                warn.Show();
                return;
            }

            temp = imgFace2.ToImage<Bgr, Byte>().ToBitmap();
            Bitmap crop2 = crop_image(temp, faces1[0]);
            Image<Gray, Byte> imgTemp2 = new Image<Gray, Byte>(crop2);
            Image<Gray, Byte> resizedImg2 = imgTemp2.Resize(128, 128, Inter.Linear);
            IntPtr faceImg2 = EmgucvImageToIplImagePointer(resizedImg2);

            // cnn predict
            string modelPath = "cnnFace.bin";
            int layerIdx = 44;
            int featLen = 256;

            score = FaceVerification(faceImg1, faceImg2, modelPath, layerIdx, featLen);
            textBox1.Text = score.ToString();

            if (score > thr)
            {
                Result result = new Result("两张照片是一个人");
                result.Show();
            }
            else
            {
                Result result = new Result("两张照片不是一个人");
                result.Show();
            }
        }

        private Bitmap crop_image(Image image, Rectangle rect)
        {
            Bitmap crop = new Bitmap(rect.Width, rect.Height, PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(crop);
            g.DrawImage(image, 0, 0, rect, GraphicsUnit.Pixel);
            g.Dispose();
            return crop;
        }


        public static string gb2312_utf8(string text)
        {
            //声明字符集   
            System.Text.Encoding utf8, gb2312;
            //gb2312   
            gb2312 = System.Text.Encoding.GetEncoding("gb2312");
            //utf8   
            utf8 = System.Text.Encoding.GetEncoding("utf-8");
            byte[] gb;
            gb = gb2312.GetBytes(text);
            gb = System.Text.Encoding.Convert(gb2312, utf8, gb);
            //返回转换后的字符   
            return utf8.GetString(gb);
        }
    }
}
