using System.Drawing;
using System.Drawing.Drawing2D;

namespace BasicEyetrackingSample
{
    public class CircleImage
    {
        public int Radidus { get; set; }
        public Bitmap Bitmap { get; set; }

        public CircleImage(Image image, int radius)
        {
            Radidus = radius;
            Bitmap = new Bitmap(image);
        }

        public void DrawCircle(Point center, Graphics graphics)
        {
            var rectangle = new Rectangle(center.X - Radidus, center.Y - Radidus, Radidus * 2, Radidus * 2);
            var path = new GraphicsPath();
            path.AddEllipse(rectangle);
            graphics.Clip = new Region(path);
            graphics.DrawImage(Bitmap, 0, 0);
        }
    }

    public class ImageHelper
    {
        public static Image Resize(Image image, Size size)
        {
            return new Bitmap(image, size);
        }
    }
}