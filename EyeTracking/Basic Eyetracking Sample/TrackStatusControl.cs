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
        private Point2D _leftEye;
        private Point2D _rightEye;
        private Queue<IGazeDataItem> _dataHistory;
        private float currentX;
        private float currentY;
        private float previousX;
        private float previousY;

        private static int HistorySize = 30;
        private static int EyeRadius = 8;

        private List<CircleImage> images = new List<CircleImage>();


        public TrackStatusControl()
        {
            InitializeComponent();

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            _dataHistory = new Queue<IGazeDataItem>(HistorySize);

            var imageNames = new string[4]
            {"nature/Nature-14.jpg", "nature/Nature-8.jpg", "nature/Nature-4.jpg", "nature/Nature-0.jpg"};
            var radiusArray = new[] { 800, 600, 500, 400 };

            var i = 0;
            foreach (var imageName in imageNames)
            {
                var image = Image.FromFile("images/" + imageName);
                image = ImageHelper.Resize(image, Size);
                var eyeImage = new CircleImage(image, radiusArray[i]);
                images.Add(eyeImage);
                i++;
            }
        }


        public void OnGazeData(IGazeDataItem gd)
        {
            // Add data to history
            _dataHistory.Enqueue(gd);

            // Remove history item if necessary
            while (_dataHistory.Count > HistorySize)
            {
                _dataHistory.Dequeue();
            }

            _leftEye = gd.LeftGazePoint2D;
            _rightEye = gd.RightGazePoint2D;

            Invalidate();
        }

        public void Clear()
        {
            _dataHistory.Clear();
            _leftEye = new Point2D();
            _rightEye = new Point2D();

            Invalidate();
        }



        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // Draw bottom bar
            //e.Graphics.FillRectangle(_brush, new Rectangle(0, Height - BarHeight, Width, BarHeight));
            Point point;

            // Draw images
            currentX = (float)((_leftEye.X + _rightEye.X) / 2);
            currentY = (float)((_leftEye.Y + _rightEye.Y) / 2);
            if(_leftEye.Y != -1.0)
            //if (IsGazeMoving())
            {
                previousX = currentX;
                previousY = currentY;
                point = new Point((int)(currentX * Width - EyeRadius), (int)(currentY * Height - EyeRadius));
            }
            else
            {
                point = new Point((int)(previousX * Width - EyeRadius), (int)(previousY * Height - EyeRadius));
            }
            //var images = new string [4] {"nature/Nature-14.jpg", "nature/Nature-8.jpg", "nature/Nature-4.jpg", "nature/Nature-0.jpg"};
            //var radiusArray = new[] {800, 600, 500, 400};

            // Draw gaze
            var i = 0;
            foreach (var image in images)
            {
                image.DrawCircle(point, e.Graphics);
                i++;
            }
        }

        //private bool IsGazeMoving()
        //{
        //    if (_leftEye.Y == -1.0) //gaze data will be -1 if the gaze was not found
        //        return false;
        //    // Else
        //    return Math.Abs(previousX - currentX) / currentX >= 0.005 && Math.Abs(previousY - currentX) / currentY >= 0.005;
        //}
    }
}