using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPF
{
    public class CircleImage
    {
        public int Radius { get; set; }
        public BitmapImage Bitmap { get; set; }

        public CircleImage(BitmapImage image, int radius)
        {
            Radius = radius;
            Bitmap = image;
        }

        public void DrawCircle(Point center, DrawingContext drawingContext, Size windowSize)
        {
            var rectangle = new Rect(center.X - Radius, center.Y - Radius, Radius * 2, Radius * 2);
            var path = new PathGeometry();
            path.AddGeometry(new EllipseGeometry(rectangle));
            drawingContext.PushClip(path);
            var windowRect = new Rect(windowSize);
            drawingContext.DrawImage(Bitmap, windowRect);
            //drawingContext.DrawEllipse(Brushes.Transparent, new Pen(Brushes.Red, 2.0), center, Radius, Radius);
            //drawingContext.DrawRectangle(Brushes.Transparent, new Pen(Brushes.Chocolate, 4.0), rectangle);
        }
    }
}