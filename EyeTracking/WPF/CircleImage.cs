using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Point = System.Windows.Point;
using Size = System.Windows.Size;

namespace WPF
{
    public class CircleImage
    {
        public int Radidus { get; set; }
        public BitmapImage Bitmap { get; set; }

        public CircleImage(BitmapImage image, int radius)
        {
            Radidus = radius;
            Bitmap = image;
        }

        public void DrawCircle(Point center, DrawingContext drawingContext)
        {
            var rectangle = new Rect(center.X - Radidus, center.Y - Radidus, Radidus * 2, Radidus * 2);
            var path = new PathGeometry();
            path.AddGeometry(new EllipseGeometry(rectangle));
            drawingContext.PushClip(path);
            drawingContext.DrawImage(Bitmap, rectangle);
            //drawingContext.DrawEllipse(new Pen(new SolidColorBrush(Colors.Black), 200), rectangle);
        }
    }

    public class ImageHelper
    {
        public static BitmapImage ResizeImage(BitmapImage bitmapImage, Size size)
        {
            var bitmap = GetBitmap(bitmapImage);
            var resizedBitmap =  new Bitmap(bitmap, (int) size.Width, (int) size.Height);
            return GetBitmapImage(resizedBitmap);
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