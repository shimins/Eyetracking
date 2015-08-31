using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using Tobii.EyeTracking.IO;

namespace BasicEyetrackingSample
{
    public partial class SimulationStatusControl : UserControl
    {
        private Point3D _leftEye;
        private Point3D _rightEye;
        private readonly SolidBrush _leftGazeBrush;
        private readonly SolidBrush _rightGazeBrush;
        private Queue<IGazeDataItem> _dataHistory;

        private static int HistorySize = 30;
        private static int gazeRadius = 8;

        public SimulationStatusControl()
        {
            InitializeComponent();

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            _dataHistory = new Queue<IGazeDataItem>(HistorySize);

            _leftGazeBrush = new SolidBrush(Color.White);
            _rightGazeBrush = new SolidBrush(Color.Red);
        }

        public void OnGazeData(IGazeDataItem gd)
        {
            _dataHistory.Enqueue(gd);

            while (_dataHistory.Count > HistorySize)
            {
                _dataHistory.Dequeue();
            }
            
            _leftEye = gd.LeftGazePoint3D;
            _rightEye = gd.RightGazePoint3D;

            Invalidate();
        }

        public void Clear()
        {
            _leftEye = new Point3D();
            _rightEye = new Point3D();

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Debug.WriteLine("jeg skal paint");
            Debug.WriteLine(_leftEye.X);
            Debug.WriteLine(_leftEye.Y);
            // Draw eyes
            RectangleF r1 = new RectangleF((float)((1.0 - _leftEye.X) * Width - gazeRadius), (float)(_leftEye.Y * Height - gazeRadius), 2 * gazeRadius, 2 * gazeRadius);
            e.Graphics.FillEllipse(_leftGazeBrush, r1);
            RectangleF r2 = new RectangleF((float)((1 - _rightEye.X) * Width - gazeRadius), (float)(_rightEye.Y * Height - gazeRadius), 2 * gazeRadius, 2 * gazeRadius);
            e.Graphics.FillEllipse(_rightGazeBrush, r2);
        }
    }
}
