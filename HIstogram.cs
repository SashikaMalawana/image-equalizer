using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace Assignment01Question05
{
    class Histogram
    {
        IplImage src, grayImage, histImage;

        public void LoadOriginalImage(String fileName)
        {
            src = Cv.LoadImage(fileName, LoadMode.Color);
            Cv.SaveImage("originalImage.jpg", src);
        }

        public void ConvertToGrayScale()
        {
            grayImage = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            Cv.CvtColor(src, grayImage, ColorConversion.RgbToGray);
            Cv.SaveImage("grayImage.jpg", grayImage);
        }

        public void DrawHistogram(String fileName)
        {
            src = Cv.LoadImage(fileName, LoadMode.Color);
            grayImage = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            Cv.CvtColor(src, grayImage, ColorConversion.RgbToGray);

            float[] range = { 0, 255 };
            float[][] ranges = { range };

            int hist_size = 255;
            float min_value, max_value = 0;

            histImage = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            ConvertToGrayScale();

            CvHistogram hist = Cv.CreateHist(new int[] { hist_size }, HistogramFormat.Array, ranges, true);
            Cv.CalcHist(grayImage, hist);
            Cv.GetMinMaxHistValue(hist, out min_value, out max_value);
            Cv.Scale(hist.Bins, hist.Bins, ((double)histImage.Height) / max_value, 0);
            histImage.Set(CvColor.White);
            int bin_w = Cv.Round((double)histImage.Width / hist_size);

            int i;
            for (i = 0; i < hist_size; i++)
            {
                histImage.Rectangle(
                    new CvPoint(i * bin_w, grayImage.Height),
                    new CvPoint((i + 1) * bin_w, grayImage.Height - Cv.Round(hist.Bins[i])), CvColor.Black, -1, LineType.Link8, 0);
            }
            Cv.SaveImage("histogram" + fileName, histImage);
        }

        public void DrawEqualizedHistogram()
        {
            float[] range = { 0, 255 };
            float[][] ranges = { range };

            int hist_size = 255;
            float min_value, max_value = 0;

            histImage = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            ConvertToGrayScale();
            Cv.EqualizeHist(grayImage, grayImage);

            CvHistogram hist = Cv.CreateHist(new int[] { hist_size }, HistogramFormat.Array, ranges, true);
            Cv.CalcHist(grayImage, hist);
            Cv.GetMinMaxHistValue(hist, out min_value, out max_value);
            Cv.Scale(hist.Bins, hist.Bins, ((double)histImage.Height) / max_value, 0);
            histImage.Set(CvColor.White);
            int bin_w = Cv.Round((double)histImage.Width / hist_size);

            int i;
            for (i = 0; i < hist_size; i++)
            {
                histImage.Rectangle(
                      new CvPoint(i * bin_w, grayImage.Height),
                      new CvPoint((i + 1) * bin_w, grayImage.Height - Cv.Round(hist.Bins[i])), CvColor.Black, -1, LineType.Link8, 0);
            }
            Cv.SaveImage("equalizedGray.jpg", grayImage);
            Cv.SaveImage("equalizedHistogram.jpg", histImage);
        }
    }
}
