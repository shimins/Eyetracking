using System.Drawing;
using System.Drawing.Drawing2D;

namespace BasicEyetrackingSample
{
    public class CircleImage
    {
        public Graphics Graphics { get; set; }
        public Bitmap Bitmap { get; set; }

        public CircleImage(Image image, Graphics graphics)
        {
            Graphics = graphics;
            Bitmap = new Bitmap(image);
        }

        public void DrawCircle(Point center, int radius)
        {
            var rectangle = new Rectangle(center.X - radius, center.Y - radius, radius * 2, radius * 2);
            var path = new GraphicsPath();
            path.AddEllipse(rectangle);
            Graphics.Clip = new Region(path);
            Graphics.DrawImage(Bitmap, 0, 0);
        }
    }

    public class ImageHelper
    {
        public static Image Resize(Image image, int width, int height)
        {
            return new Bitmap(image, new Size(width, height));
        }
    }
}