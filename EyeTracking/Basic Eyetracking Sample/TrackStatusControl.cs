using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Tobii.EyeTracking.IO;

namespace BasicEyetrackingSample
{
    public partial class TrackStatusControl : UserControl
    {
        
        private Point2D _current;
        private Point2D _previous;

        private readonly List<CircleImage> _images = new List<CircleImage>();
        private const int ImageLength = 5;

        private Point _point;

        readonly Stopwatch _sw;

        public TrackStatusControl()
        {
            InitializeComponent();

            SetStyle(ControlStyles.UserPaint, true); 
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            
            _previous.X = 0;
            _previous.Y = 0;

            _sw = new Stopwatch();

            const string imageFolder = "images/nature/";
            for (var i = ImageLength; i >= 0; i=i-1)
            {
                var image = Image.FromFile(imageFolder + "Nature-" + i + ".jpg");
                image = ImageHelper.Resize(image, Size);
                var radius = (i*50) + 400;
                var eyeImage = new CircleImage(image, radius);
                _images.Add(eyeImage);
            }

            _sw.Start();
        }


        public void OnGazeData(Point2D leftPoint, Point2D rightPoint)
        {

            if (!(leftPoint.X > -1.0)) return;
            _current = new Point2D((leftPoint.X + rightPoint.X) / 2, (leftPoint.Y + rightPoint.Y) / 2);
            if (!GazeHaveMoved(_current)) return;
            _previous = _current;
            Invalidate();
            Console.WriteLine(@"Called Invalidate");
        }

        private bool GazeHaveMoved(Point2D currentPoint)
        {
            if (Math.Abs(_previous.X - currentPoint.X) > 0.03 || Math.Abs(_previous.Y - currentPoint.Y) > 0.03)
            {
                return true;
            }
            return false;
        }

        public void Clear()
        {
            _current = new Point2D();
            Invalidate();
        }



        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);
            _point = new Point((int)(_previous.X * Width), (int)(_previous.Y * Height));

            e.Graphics.CompositingMode = CompositingMode.SourceOver;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
            e.Graphics.CompositingQuality = CompositingQuality.HighSpeed;
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.SmoothingMode = SmoothingMode.None;
            
            // Draw gaze
            foreach (var image in _images)
            {
                image.DrawCircle(_point, e.Graphics);
            }
            Console.WriteLine(@"Time taken: {0}ms", _sw.Elapsed.TotalMilliseconds);
            _sw.Restart();

        }
    }
}