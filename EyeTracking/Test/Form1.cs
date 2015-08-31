using System.Drawing;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        private const int EyeRadius = 75;
        private const int EyeOuterRadius = 200;
        private const int BackgroundRadius = 500;

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e); 

            var graphics = this.CreateGraphics();
            var image = Image.FromFile("images/blur-0.jpg");

            var eyeImage = new CircleImage(image, graphics);
            var point = new Point(Width/2, Height/2);
            eyeImage.DrawCircle(point, EyeRadius);
        }
    }
}
