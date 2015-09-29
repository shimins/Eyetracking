using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;
using Size = System.Windows.Size;

namespace WPF
{
    public class ImageHelper
    {
        public static BitmapImage ResizeImage(BitmapImage bitmapImage, Size size)
        {
            var bitmap = GetBitmap(bitmapImage);
            var resizedBitmap =  new Bitmap(bitmap, (int) size.Width, (int) size.Height);
            return GetBitmapImage(resizedBitmap);
        }

        private static Image ropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            return bmpImage.Clone(cropArea, bmpImage.PixelFormat);
        }

        private static Bitmap GetBitmap(BitmapSource bitmapImage)
        {
            using (var memory = new MemoryStream())
            {
                var bitmapEncoder = new BmpBitmapEncoder();
                bitmapEncoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                bitmapEncoder.Save(memory);
                var bitmap = new Bitmap(memory);
                return new Bitmap(bitmap);
            }
        }

        private static BitmapImage GetBitmapImage(Image bitmap)
        {
            using (var memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Bmp);
                memory.Position = 0;
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                return bitmapImage;
            }
        }
    }
}