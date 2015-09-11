using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Linq.Expressions;

namespace BlurClass
{
    public class Blur
    {
        public Bitmap blurImage(Bitmap image, int blurLevel)
        {
            var blurred = new Bitmap(image.Width, image.Height);

            // make an exact copy of the bitmap provided
            using (var graphics = Graphics.FromImage(blurred))
                graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height),
                    new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);

            // look at every pixel in the blur rectangle
            for (var xx = 0; xx < image.Width; xx++)
            {
                for (var yy = 0; yy < image.Height; yy++)
                {
                    int avgR = 0, avgG = 0, avgB = 0;
                    var blurPixelCount = 0;

                    // average the color of the red, green and blue for each pixel in the
                    // blur size while making sure you don't go outside the image bounds
                    for (var x = xx; (x < xx + blurLevel && x < image.Width); x++)
                    {
                        for (var y = yy; (y < yy + blurLevel && y < image.Height); y++)
                        {
                            var pixel = blurred.GetPixel(x, y);

                            avgR += pixel.R;
                            avgG += pixel.G;
                            avgB += pixel.B;

                            blurPixelCount++;
                        }
                    }
                    if (blurPixelCount > 0)
                    {
                        avgR = avgR / blurPixelCount;
                        avgG = avgG / blurPixelCount;
                        avgB = avgB / blurPixelCount;
                    }

                    // now that we know the average for the blur size, set each pixel to that color
                    for (Int32 x = xx; x < xx + blurLevel && x < image.Width && x < image.Width; x++)
                        for (Int32 y = yy; y < yy + blurLevel && y < image.Height && y < image.Height; y++)
                            blurred.SetPixel(x, y, Color.FromArgb(avgR, avgG, avgB));
                }
            }

            return blurred;
        }
    }
}
