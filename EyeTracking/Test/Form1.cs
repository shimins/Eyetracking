using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e); 

            var graphics = this.CreateGraphics();
            var point = new Point(Width / 2, Height / 2);

            var images = new[] {"blur-0.jpg", "blur-20.jpg", "blur-50.jpg", "blur-80.jpg"};
            var radiusArray = new[] {75, 200, 450, 800};

            var radiusReverse = radiusArray.Reverse().ToArray();

            var i = 0;
            foreach (var imageName in images.Reverse())
            {
                var image = Image.FromFile("images/" + imageName);
                var eyeImage = new CircleImage(image, graphics);
                eyeImage.DrawCircle(point, radiusReverse[i]);
                i++;
            }

        }
    }
}
