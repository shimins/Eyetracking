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

        private Queue<IGazeDataItem> _dataHistory;
        private double currentX;
        private double currentY;
        private double previousX;
        private double previousY;

        private static int HistorySize = 30;
        private static int EyeRadius = 8;

        private List<CircleImage> images = new List<CircleImage>();
        private const int ImageLength = 5;

        private Point point;
        private Stopwatch stopwatch;

        public TrackStatusControl()
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
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
                images.Add(eyeImage);
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

            currentX = (leftPoint.X + rightPoint.X) / 2;
            currentY = (leftPoint.Y + rightPoint.Y) / 2;
            if (leftPoint.Y != -1.0)
            {
                previousX = currentX;
                previousY = currentY;
                Invalidate();
            }
        }

        public void Clear()
        {
            _dataHistory.Clear();
            currentX = 0.0;
            currentY = 0.0;

            Invalidate();
        }



        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            point = new Point((int)(previousX * Width - EyeRadius), (int)(previousY * Height - EyeRadius));
            // Draw gaze
            var i = 0;
            foreach (var image in images)
            {
                image.DrawCircle(point, e.Graphics);
                i++;
            }
            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
        }
    }
}