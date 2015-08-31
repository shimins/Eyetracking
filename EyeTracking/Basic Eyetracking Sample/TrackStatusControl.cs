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
        private int _leftValidity;
        private int _rightValidity;
        private SolidBrush _brush;
        private SolidBrush _eyeBrush;
        private Queue<IGazeDataItem> _dataHistory;

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

            _brush = new SolidBrush(Color.Red);
            _eyeBrush = new SolidBrush(Color.White);

            _leftValidity = 4;
            _rightValidity = 4;
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

            _leftValidity = gd.LeftValidity;
            _rightValidity = gd.RightValidity;
            //_leftEye = gd.LeftEyePosition3DRelative;
            //_rightEye = gd.RightEyePosition3DRelative;
            _leftEye = gd.LeftGazePoint2D;
            _rightEye = gd.RightGazePoint2D;

            Invalidate();
        }

        public void Clear()
        {
            _dataHistory.Clear();
            _leftValidity = 0;
            _rightValidity = 0;
            _leftEye = new Point2D();
            _rightEye = new Point2D();

            Invalidate();
        }


        /// <summary>
        /// Gets the current brush
        /// </summary>
        private SolidBrush Brush
        {
            get
            {
                if (_leftValidity == 4 && _rightValidity == 4)
                {
                    _brush.Color = Color.Red;
                }
                else if (_leftValidity == 0 && _rightValidity == 0)
                {
                    _brush.Color = Color.Lime;
                }
                else if (_leftValidity == 2 && _rightValidity == 2)
                {
                    _brush.Color = Color.Orange;
                }
                else
                {
                    _brush.Color = Color.Yellow;
                }

                return _brush;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //Debug.WriteLine("jeg skal paint trackStatus");
            //Debug.WriteLine(_leftEye.X);
            //Debug.WriteLine(_leftEye.Y);
            // Compute status bar color
            _brush.Color = ComputeStatusColor();
            
            // Draw bottom bar
            e.Graphics.FillRectangle(_brush, new Rectangle(0, Height - BarHeight, Width, BarHeight));

            // Draw eyes
            var currentX = (float)((_leftEye.X + _rightEye.X) / 2);
            var currentY = (float)((_leftEye.Y + _rightEye.Y) / 2);
            RectangleF r = new RectangleF((float)(currentX * Width - EyeRadius), (float)(currentY * Height - EyeRadius), 2 * EyeRadius, 2 * EyeRadius);
            e.Graphics.FillEllipse(_eyeBrush, r);
            //if (_leftValidity <= 2)
            //{
            //    double xProportion = 440.0/Screen.GetBounds(this).Right * 0.01;
            //    double yProportion = 260.0/Screen.GetBounds(this).Height * 0.01;
            //    Debug.WriteLine(_leftEye.Y);
            //    //Debug.WriteLine((_leftEye.Y - 140)*yProportion);
            //    RectangleF r = new RectangleF((float) ((_leftEye.X + 170) * xProportion * Width - EyeRadius), (float)((1-(_leftEye.Y - 100) * yProportion) * Height - EyeRadius), 2 * EyeRadius, 2 * EyeRadius);
            //    //RectangleF r = new RectangleF((float) ((1.0 - _leftEye.X) * Width - EyeRadius), (float) (_leftEye.Y * Height - EyeRadius), 2 * EyeRadius, 2 * EyeRadius);
            //    e.Graphics.FillEllipse(_eyeBrush, r);
            //}

            //if(_rightValidity <= 2)
            //{
            //    //RectangleF r = new RectangleF((float) ((1 - _rightEye.X) * Width - EyeRadius), (float) (_rightEye.Y * Height - EyeRadius), 2 * EyeRadius, 2 * EyeRadius);
            //    //e.Graphics.FillEllipse(_eyeBrush, r);
            //}
        }

        private Color ComputeStatusColor()
        {
            if (!Enabled)
                return Color.Gray;

            int quality = 0;
            int count = 0;

            foreach (IGazeDataItem item in _dataHistory)
            {
                if(item.LeftValidity == 4 && item.RightValidity == 4)
                {
                    quality += 0;
                }
                else if (item.LeftValidity == 0 && item.RightValidity == 0)
                {
                    quality += 2;
                }
                else
                {
                    quality++;
                }

                count++;
            }

            float q = (count == 0 ? 0 : quality / (2F*count));
            
            if(q > 0.8)
            {
                return Color.Lime;
            }
            if(q < 0.1)
            {
                return Color.Red;
            }

            return Color.Red;
        }
    }
}