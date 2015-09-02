using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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
        private static int BarHeight = 25;
        private static int EyeRadius = 8;

        public TrackStatusControl()
        {
            InitializeComponent();

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            _dataHistory = new Queue<IGazeDataItem>(HistorySize);
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
            var point = new Point();

            // Draw images
            currentX = (float)((_leftEye.X + _rightEye.X) / 2);
            currentY = (float)((_leftEye.Y + _rightEye.Y) / 2);
            if (IsGazeMoving())
            {
                previousX = currentX;
                previousY = currentY;
                point = new Point((int) (currentX*Width - EyeRadius), (int) (currentY*Height - EyeRadius));
            }
            else
            {
                point = new Point((int)(previousX * Width - EyeRadius), (int)(previousY * Height - EyeRadius));
            }
            var images = new[] { "blur-0.jpg", "blur-20.jpg", "blur-50.jpg", "blur-80.jpg" };
            var radiusArray = new[] { 400, 500, 600, 800 };

            var radiusReverse = radiusArray.Reverse().ToArray();
            
            // Draw gaze
            var i = 0;
            foreach (var imageName in images.Reverse())
            {
                var image = Image.FromFile("images/" + imageName);
                var eyeImage = new CircleImage(image, e.Graphics);
                eyeImage.DrawCircle(point, radiusReverse[i]);
                i++;
            }
        }

        private bool IsGazeMoving()
        {
            if (_leftEye.Y == -1.0) //gaze data will be -1 if the gaze was not found
            {
                return false;
            }
            else if (Math.Abs(previousX - currentX)/currentX >= 0.005 && Math.Abs(previousY - currentX)/currentY >= 0.005)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}