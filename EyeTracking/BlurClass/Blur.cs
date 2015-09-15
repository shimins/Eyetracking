using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace BlurClass
{
    public class Blur
    {

        private static double[,] filterMatrix;
        private static string test = null;

        public static Bitmap _GaussianBlur(Bitmap _Image, int _blurLevel)
        {
            Calculate(_blurLevel);
            BitmapData sourceData = _Image.LockBits(new Rectangle(0, 0,
                                     _Image.Width, _Image.Height),
                                                       ImageLockMode.ReadOnly,
                                                 PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            _Image.UnlockBits(sourceData);

            double blue = 0.0;
            double green = 0.0;
            double red = 0.0;

            double factor = 1;
            int bias = 0;

            int filterWidth = filterMatrix.GetLength(1);
            Console.WriteLine(filterMatrix.GetLength(1));
            int filterHeight = filterMatrix.GetLength(0);

            int filterOffset = (filterWidth - 1) / 2;
            int calcOffset = 0;

            int byteOffset = 0;

            for (int offsetY = filterOffset; offsetY <
                _Image.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX <
                    _Image.Width - filterOffset; offsetX++)
                {
                    blue = 0;
                    green = 0;
                    red = 0;

                    byteOffset = offsetY *
                                 sourceData.Stride +
                                 offsetX * 4;

                    for (int filterY = -filterOffset;
                        filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;
                            filterX <= filterOffset; filterX++)
                        {

                            calcOffset = byteOffset +
                                         (filterX * 4) +
                                         (filterY * sourceData.Stride);

                            blue += (double)(pixelBuffer[calcOffset]) *
                                    filterMatrix[filterY + filterOffset,
                                                        filterX + filterOffset];

                            green += (double)(pixelBuffer[calcOffset + 1]) *
                                     filterMatrix[filterY + filterOffset,
                                                        filterX + filterOffset];

                            red += (double)(pixelBuffer[calcOffset + 2]) *
                                   filterMatrix[filterY + filterOffset,
                                                      filterX + filterOffset];
                        }
                    }

                    blue = factor * blue + bias;
                    green = factor * green + bias;
                    red = factor * red + bias;

                    blue = (blue > 255 ? 255 : (blue < 0 ? 0 : blue));
                    green = (green > 255 ? 255 : (green < 0 ? 0 : green));
                    red = (red > 255 ? 255 : (red < 0 ? 0 : red));

                    resultBuffer[byteOffset] = (byte)(blue);
                    resultBuffer[byteOffset + 1] = (byte)(green);
                    resultBuffer[byteOffset + 2] = (byte)(red);
                    resultBuffer[byteOffset + 3] = 255;
                }
            }

            Bitmap resultBitmap = new Bitmap(_Image.Width, _Image.Height);

            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                     resultBitmap.Width, resultBitmap.Height),
                                                      ImageLockMode.WriteOnly,
                                                 PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);
            return resultBitmap;
        }

        private static void Calculate(int _blurLevel)
        {
            filterMatrix = new double[_blurLevel, _blurLevel];
            double sumTotal = 0;
            double weight = 2.5;

            int kernelRadius = _blurLevel / 2;
            double distance = 0;

            double calculatedEuler = 1.0 /
           (2.0 * Math.PI * Math.Pow(weight, 2));


            for (int filterY = -kernelRadius;
                 filterY <= kernelRadius; filterY++)
            {
                for (int filterX = -kernelRadius;
                    filterX <= kernelRadius; filterX++)
                {
                    distance = ((filterX * filterX) +
                               (filterY * filterY)) /
                               (2 * (weight * weight));


                    filterMatrix[filterY + kernelRadius,
                           filterX + kernelRadius] =
                           calculatedEuler * Math.Exp(-distance);

                    sumTotal += filterMatrix[filterY + kernelRadius,
                                       filterX + kernelRadius];
                }
            }

            for (int y = 0; y < _blurLevel; y++)
            {
                for (int x = 0; x < _blurLevel; x++)
                {
                    filterMatrix[y, x] = filterMatrix[y, x] *
                                   (1.0 / sumTotal);
                }
            }
        }
    }
}
