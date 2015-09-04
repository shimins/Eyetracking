using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Tobii.EyeTracking.IO;

namespace BasicEyetrackingSample
{
    public partial class TrackStatusControl : UserControl
    {

        private readonly Queue<IGazeDataItem> _dataHistory;
        private Point2D _current;
        private Point2D _previous;

        private const int HistorySize = 30;
        private const int EyeRadius = 8;

        private readonly List<CircleImage> _images = new List<CircleImage>();
        private const int ImageLength = 5;

        private Point _point;
        private readonly Stopwatch _stopwatch;

        public TrackStatusControl()
        {
            _stopwatch = new Stopwatch();
            InitializeComponent();

            SetStyle(ControlStyles.UserPaint, true); 
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            _dataHistory = new Queue<IGazeDataItem>(HistorySize);

            const string imageFolder = "images/nature/";
            for (var i = ImageLength-1; i >= 0; i--)
            {
                var image = Image.FromFile(imageFolder + "Nature-" + i + ".jpg");
                image = ImageHelper.Resize(image, Size);
                var radius = (i*150) + 400;
                var eyeImage = new CircleImage(image, radius);
                _images.Add(eyeImage);
            }
        }


        public void OnGazeData(Point2D leftPoint, Point2D rightPoint)
        {
            // Add data to history
            //_dataHistory.Enqueue(gd);

            // Remove history item if necessary
            //while (_dataHistory.Count > HistorySize)
            //{
            //    _dataHistory.Dequeue();
            //}

            _current = new Point2D((leftPoint.X + rightPoint.X) / 2, (leftPoint.Y + rightPoint.Y) / 2);
            if (leftPoint.Y > -1.0 && _current.X != _previous.X)
            {
                _previous = _current;
                Invalidate();
            }
        }

        public void Clear()
        {
            _dataHistory.Clear();
            _current = new Point2D();

            Invalidate();
        }



        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            _point = new Point((int)(_previous.X * Width - EyeRadius), (int)(_previous.Y * Height - EyeRadius));
            // Draw gaze
            foreach (var image in _images)
            {
                image.DrawCircle(_point, e.Graphics);
            }
        }
    }
}