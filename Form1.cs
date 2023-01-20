using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment01Question05
{
    public partial class Form1 : Form
    {
        Histogram histogramObject = new Histogram();
        OpenFileDialog ofd = new OpenFileDialog();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ofd.Title = "Select Image File";
            ofd.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" + "All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                histogramObject.LoadOriginalImage(ofd.FileName);
                pictureBox1.ImageLocation = "originalImage.jpg";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string image = ofd.FileName.ToString();

            Bitmap bitmap = new Bitmap(image);

            Bitmap bitmapRed = new Bitmap(bitmap);
            Bitmap bitmapGreen = new Bitmap(bitmap);
            Bitmap bitmapBlue = new Bitmap(bitmap);

            for (int y = 0; y < bitmap.Width; y++)
            {
                for (int x = 0; x < bitmap.Height; x++)
                {
                    Color pixelColor = bitmap.GetPixel(x, y);

                    int alpha = pixelColor.A;
                    int red = pixelColor.R;
                    int green = pixelColor.G;
                    int blue = pixelColor.B;

                    bitmapRed.SetPixel(x, y, Color.FromArgb(alpha, red, 0, 0));
                    bitmapGreen.SetPixel(x, y, Color.FromArgb(alpha, 0, green, 0));
                    bitmapBlue.SetPixel(x, y, Color.FromArgb(alpha, 0, 0, blue));
                }
            }

            bitmapRed.Save("imageRed.jpg");
            bitmapGreen.Save("imageGreen.jpg");
            bitmapBlue.Save("imageBlue.jpg");

            pictureBox2.ImageLocation = "imageRed.jpg";
            pictureBox3.ImageLocation = "imageGreen.jpg";
            pictureBox4.ImageLocation = "imageBlue.jpg";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            histogramObject.DrawHistogram("imageRed.jpg");
            pictureBox5.ImageLocation = "histogramimageRed.jpg";

            histogramObject.DrawHistogram("imageGreen.jpg");
            pictureBox6.ImageLocation = "histogramimageGreen.jpg";

            histogramObject.DrawHistogram("imageBlue.jpg");
            pictureBox7.ImageLocation = "histogramimageBlue.jpg";

            /*
            string grayHistogramImage = "grayHistogram.jpg";

            Bitmap bitmap = new Bitmap(grayHistogramImage);

            Bitmap bitmapRed = new Bitmap(bitmap);
            Bitmap bitmapGreen = new Bitmap(bitmap);
            Bitmap bitmapBlue = new Bitmap(bitmap);

            for (int y = 0; y < bitmap.Width; y++)
            {
                for (int x = 0; x < bitmap.Height; x++)
                {
                    Color pixelColor = bitmap.GetPixel(x, y);

                    int alpha = pixelColor.A;
                    int red = pixelColor.R;
                    int green = pixelColor.G;
                    int blue = pixelColor.B;

                    bitmapRed.SetPixel(x, y, Color.FromArgb(alpha, 255 - red, 0, 0));
                    bitmapGreen.SetPixel(x, y, Color.FromArgb(alpha, 0, 255 - green, 0));
                    bitmapBlue.SetPixel(x, y, Color.FromArgb(alpha, 0, 0, 255 - blue));
                }
            }
            bitmapRed.Save("histogramRed.jpg");
            bitmapGreen.Save("histogramGreen.jpg");
            bitmapBlue.Save("histogramBlue.jpg");

            pictureBox5.ImageLocation = "histogramRed.jpg";
            pictureBox6.ImageLocation = "histogramGreen.jpg";
            pictureBox7.ImageLocation = "histogramBlue.jpg";
            */

        }

        private void button4_Click(object sender, EventArgs e)
        {
            histogramObject.DrawEqualizedHistogram();
            pictureBox8.ImageLocation = "equalizedGray.jpg";
            pictureBox9.ImageLocation = "equalizedHistogram.jpg";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            pictureBox4.Image = null;
            pictureBox5.Image = null;
            pictureBox6.Image = null;
            pictureBox7.Image = null;
            pictureBox8.Image = null;
            pictureBox9.Image = null;
        }
    }
}
