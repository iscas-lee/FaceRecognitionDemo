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

namespace FaceRecognitionDemo
{
    public partial class MainWindows : Form
    {
        private Mat imgFace1 = new Mat();
        private Mat imgFace2 = new Mat();
        private float score;

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
                imgFace1 = CvInvoke.Imread(Img1TextBox.Text, LoadImageType.Color);
                ImgPicBox1.SizeMode = PictureBoxSizeMode.Zoom;
                ImgPicBox1.Image = imgFace1.ToImage<Bgr, Byte>().ToBitmap();
            }
        }
        private void ImgBtn2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // read image
                Img2TextBox.Text = dialog.FileName;
                imgFace2 = CvInvoke.Imread(Img2TextBox.Text, LoadImageType.Color);
                ImgPicBox2.SizeMode = PictureBoxSizeMode.Zoom;
                ImgPicBox2.Image = imgFace2.ToImage<Bgr, Byte>().ToBitmap();
            }
        }


    }
}
