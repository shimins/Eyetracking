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
        private int numberOfImages;
        private int radius;

        private Point _point;
        
        public TrackStatusControl(int blurLevel, int numberOfImages, int radius, List<Bitmap> imageList)
        {
            InitializeComponent();
            this.numberOfImages = numberOfImages;
            this.radius = radius;
            SetStyle(ControlStyles.UserPaint, true); 
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetNewImageSet(numberOfImages, imageList);
            SetBackGround(blurLevel, imageList);

            _previous.X = 0;
            _previous.Y = 0;
        }

        private void SetNewImageSet(int imageCount, List<Bitmap> imageList)
        {
            var factor = 500/imageCount;
            if (imageList.Count <= 0)
            {
                for (var i = numberOfImages; i >= 0; i = i - 1)
                {
                    var image = Image.FromFile("images/nature/" + "Nature-" + i + ".jpg");
                    image = ImageHelper.Resize(image, Size);
                    var r = (i * factor) + radius;
                    var eyeImage = new CircleImage(image, r);
                    _images.Add(eyeImage);
                }
            }
            else
            {
                for (var i = numberOfImages; i >= 0; i = i - 1)
                {
                    var image = imageList[i];
                    image = (Bitmap) ImageHelper.Resize(image, Size);
                    var r = (i * factor) + radius;
                    var eyeImage = new CircleImage(image, r);
                    _images.Add(eyeImage);
                }
            }
        }

        private void SetBackGround(int blurLevel, List<Bitmap> imageList)
        {
            if (imageList.Count <= 0)
            {
                this.BackgroundImage =
                    ((System.Drawing.Image) (Image.FromFile("images/nature/" + "Nature-" + numberOfImages + ".jpg")));
            }
            else
            {
                this.BackgroundImage =
                    ((System.Drawing.Image)(imageList[numberOfImages]));
            }
        }


        public void SetNumberOfCircles(int number)
        {
            this.numberOfImages = number;
        }

        public void SetRadius(int radius)
        {
            this.radius = radius;
        }

        public void OnGazeData(Point2D leftPoint, Point2D rightPoint)
        {

            if (!(leftPoint.X > -1.0)) return;
            _current = new Point2D((leftPoint.X + rightPoint.X) / 2, (leftPoint.Y + rightPoint.Y) / 2);
            if (!GazeHaveMoved(_current)) return;
            _previous = _current;
            Invalidate();
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

        }
    }
}