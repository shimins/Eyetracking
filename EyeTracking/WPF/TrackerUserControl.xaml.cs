using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Linq;
using Tobii.EyeTracking.IO;

namespace WPF
{
    /// <summary>
    /// Interaction logic for TrackerUserControl.xaml
    /// </summary>
    public partial class TrackerUserControl : UserControl
    {
        public bool IsTracking { get; set; }
        public List<CircleImage> Images = new List<CircleImage>();
        private IEyeTracker EyeTracker { get; set; }

        private Point2D _leftGaze;
        private Point2D _rightGaze;

        private Point2D _current;
        private Point2D _previous;

        private Point Point { get; set; }
        private bool DrawCircles { get; set; }

        public UserTest UserTest { get; set; }

        public TrackerUserControl()
        {
            InitializeComponent();
            UserTest = Tests.tests[0];
            if (StaticValues.developerMode)
            {
                SetValue(5, 300, 600, DrawCircles, new List<BitmapImage>());
            }
            else if (!StaticValues.developerMode)
            {
                SetValue(2, 100, 750, false, new List<BitmapImage>());
            }
            _previous.X = 0;
            _previous.Y = 0;
        }

        private void SetNewImageSet(int imageCount,int innerRadius,int outerRadius, List<BitmapImage> images)
        {
            Images = new List<CircleImage>();
            if (images.Count <= 0)
            {
                for (var i = imageCount; i >= 0; i = i - 1)
                {
                    var bitmapImage = new BitmapImage(new Uri("images/nature/Nature-" + i + ".jpg", UriKind.Relative));
                    var img = ImageHelper.ResizeImage(bitmapImage, new Size(Width, Height));
                    var r = GetRadius(i, imageCount, innerRadius, outerRadius);
                    Images.Add(new CircleImage(img, r));
                }
            }
            else
            {
                for (var i = imageCount; i >= 0; i = i - 1)
                {
                    var bitmapImage = images[i];
                    var img = ImageHelper.ResizeImage(bitmapImage, new Size(Width, Height));
                    var r = GetRadius(i, imageCount, innerRadius, outerRadius);
                    Images.Add(new CircleImage(img, r));
                }
                InvalidateVisual();
            }
        }

        private static int GetRadius(int index, int count, int innerRadius, int outerRadius)
        {
            var factor = (outerRadius - innerRadius) / count;
            var r = outerRadius + ((index - count) * factor);
            return r < innerRadius ? innerRadius : r > outerRadius ? outerRadius : r;
        }


        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            // Background Image
            drawingContext.DrawImage(Images.First().Bitmap, new Rect(RenderSize));

            foreach (var image in Images)
            {
                image.DrawCircle(Point, drawingContext, RenderSize, DrawCircles);
            }
        }


        private void _tracker_GazeDataReceived(object sender, GazeDataEventArgs e)
        {
            // Convert to centimeters
            var gd = e.GazeDataItem;

            _leftGaze.X = gd.LeftGazePoint2D.X*Width;
            _leftGaze.Y = gd.LeftGazePoint2D.Y*Height;

            _rightGaze.X = gd.RightGazePoint2D.X*Width;
            _rightGaze.Y = gd.RightGazePoint2D.Y*Height;

            if (_leftGaze.X < 0 && _rightGaze.X < 0) return;
            if (_leftGaze.X > 0 && _rightGaze.X > 0)
            {
                _current = new Point2D((_leftGaze.X + _rightGaze.X) / 2, (_leftGaze.Y + _rightGaze.Y) / 2);
            }
            else if (_rightGaze.X > 0)
            {
                _current = new Point2D(_rightGaze.X, _rightGaze.Y);
            }
            else if (_leftGaze.X > 0)
            {
                _current = new Point2D(_leftGaze.X, _leftGaze.Y);
            }
            if (!StaticValues.developerMode)
            {
                SaveData(_current, gd.RightEyePosition3D.Z/10);
            }
            if (GazeHaveMoved(_current))
            {
                Point = new Point(_current.X, _current.Y);
                _previous = _current;
            }
            InvalidateVisual();
        }

        private void SaveData(Point2D current, double z)
        {
            var element = new XElement("InnerRow");

            element.Add(new XAttribute("Timestamp", DateTime.Now));
            var position = new XElement("Position");
            position.Add(new XAttribute("X", current.X));
            position.Add(new XAttribute("Y", current.Y));
            element.Add(position);
            element.Add(new XAttribute("Distance", z));

            UserTest.Document.Root.Add(element);
        }

        private bool GazeHaveMoved(Point2D currentPoint)
        {
            if (Math.Abs(_previous.X - currentPoint.X) > 30 || Math.Abs(_previous.Y - currentPoint.Y) > 30)
            {
                return true;
            }
            return false;
        }

        public void StopTracking()
        {
            EyeTracker.GazeDataReceived -= _tracker_GazeDataReceived;
            EyeTracker.StopTracking();

            EyeTracker.Dispose();
            IsTracking = false;

        }

        public void StartTracking(EyeTrackerInfo eyeTrackerInfo)
        {
            EyeTracker = eyeTrackerInfo.Factory.CreateEyeTracker();
            EyeTracker.StartTracking();
            EyeTracker.GazeDataReceived += _tracker_GazeDataReceived;
            IsTracking = true;
        }

        public void StartTest(string name, int blurness, int radius)
        {
            UserTest = new UserTest(name, radius, blurness);
        }

        public void StopTest(int index, int blurness, int radius)
        {
            StaticValues.User.Tests.Add(UserTest);
            UserTest.SaveTest(StaticValues.User.Name,index, blurness, radius);
        }

        public void SetValue(int imageCount, int innerRadius, int outerRadius, bool drawCircles, List<BitmapImage> imageList)
        {
            DrawCircles = drawCircles;
            SetNewImageSet(imageCount, innerRadius, outerRadius, imageList);
        }
    }
}
