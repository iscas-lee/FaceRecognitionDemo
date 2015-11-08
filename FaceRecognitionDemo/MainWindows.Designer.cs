namespace FaceRecognitionDemo
{
    partial class MainWindows
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ImgPicBox1 = new System.Windows.Forms.PictureBox();
            this.ImgPicBox2 = new System.Windows.Forms.PictureBox();
            this.Img1TextBox = new System.Windows.Forms.TextBox();
            this.ImgBtn1 = new System.Windows.Forms.Button();
            this.ImgBtn2 = new System.Windows.Forms.Button();
            this.Img2TextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ImgPicBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgPicBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // ImgPicBox1
            // 
            this.ImgPicBox1.Location = new System.Drawing.Point(12, 66);
            this.ImgPicBox1.Name = "ImgPicBox1";
            this.ImgPicBox1.Size = new System.Drawing.Size(270, 335);
            this.ImgPicBox1.TabIndex = 0;
            this.ImgPicBox1.TabStop = false;
            // 
            // ImgPicBox2
            // 
            this.ImgPicBox2.Location = new System.Drawing.Point(420, 66);
            this.ImgPicBox2.Name = "ImgPicBox2";
            this.ImgPicBox2.Size = new System.Drawing.Size(270, 335);
            this.ImgPicBox2.TabIndex = 1;
            this.ImgPicBox2.TabStop = false;
            // 
            // Img1TextBox
            // 
            this.Img1TextBox.Location = new System.Drawing.Point(13, 424);
            this.Img1TextBox.Name = "Img1TextBox";
            this.Img1TextBox.Size = new System.Drawing.Size(252, 21);
            this.Img1TextBox.TabIndex = 2;
            // 
            // ImgBtn1
            // 
            this.ImgBtn1.Location = new System.Drawing.Point(269, 424);
            this.ImgBtn1.Name = "ImgBtn1";
            this.ImgBtn1.Size = new System.Drawing.Size(21, 21);
            this.ImgBtn1.TabIndex = 3;
            this.ImgBtn1.Text = "...";
            this.ImgBtn1.UseVisualStyleBackColor = true;
            this.ImgBtn1.Click += new System.EventHandler(this.ImgBtn1_Click);
            // 
            // ImgBtn2
            // 
            this.ImgBtn2.Location = new System.Drawing.Point(676, 425);
            this.ImgBtn2.Name = "ImgBtn2";
            this.ImgBtn2.Size = new System.Drawing.Size(21, 21);
            this.ImgBtn2.TabIndex = 5;
            this.ImgBtn2.Text = "...";
            this.ImgBtn2.UseVisualStyleBackColor = true;
            this.ImgBtn2.Click += new System.EventHandler(this.ImgBtn2_Click);
            // 
            // Img2TextBox
            // 
            this.Img2TextBox.Location = new System.Drawing.Point(420, 425);
            this.Img2TextBox.Name = "Img2TextBox";
            this.Img2TextBox.Size = new System.Drawing.Size(252, 21);
            this.Img2TextBox.TabIndex = 4;
            // 
            // MainWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 467);
            this.Controls.Add(this.ImgBtn2);
            this.Controls.Add(this.Img2TextBox);
            this.Controls.Add(this.ImgBtn1);
            this.Controls.Add(this.Img1TextBox);
            this.Controls.Add(this.ImgPicBox2);
            this.Controls.Add(this.ImgPicBox1);
            this.Name = "MainWindows";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ImgPicBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgPicBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ImgPicBox1;
        private System.Windows.Forms.PictureBox ImgPicBox2;
        private System.Windows.Forms.TextBox Img1TextBox;
        private System.Windows.Forms.Button ImgBtn1;
        private System.Windows.Forms.Button ImgBtn2;
        private System.Windows.Forms.TextBox Img2TextBox;
    }
}

