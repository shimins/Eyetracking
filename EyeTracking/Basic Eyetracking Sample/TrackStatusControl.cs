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
        private const int ImageLength = 10;

        private Point point;

        public TrackStatusControl()
        {
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
                var radius = (i*75) + 400;
                var eyeImage = new CircleImage(image, radius);
                images.Add(eyeImage);
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
            currentX = (float)((_leftEye.X + _rightEye.X) / 2);
            currentY = (float)((_leftEye.Y + _rightEye.Y) / 2);
            if (_leftEye.Y != -1.0)
            {
                previousX = currentX;
                previousY = currentY;
                Invalidate();
            }
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
            point = new Point((int)(previousX * Width - EyeRadius), (int)(previousY * Height - EyeRadius));
            // Draw gaze
            var i = 0;
            foreach (var image in images)
            {
                image.DrawCircle(point, e.Graphics);
                i++;
            }
        }
    }
}