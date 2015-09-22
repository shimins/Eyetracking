using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Tobii.EyeTracking.IO;
using TobiiData;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<CircleImage> Images = new List<CircleImage>();
        private const int ImageCount = 5;
        private const int Radius = 400;

        private readonly EyeTrackerBrowser _browser;

        private bool _tracking;
        private IEyeTracker _tracker;

        private Point3D _leftPos;
        private Point3D _rightPos;
        private Point3D _leftGaze;
        private Point3D _rightGaze;

        public MainWindow()
        {
            InitializeComponent();
            Library.Init();

            _browser = new EyeTrackerBrowser();
            _browser.EyeTrackerFound += _browser_EyetrackerFound;
            _browser.EyeTrackerRemoved += _browser_EyetrackerRemoved;
            _browser.EyeTrackerUpdated += _browser_EyetrackerUpdated;

            SetNewImageSet(ImageCount, "images/nature/");
            InvalidateVisual();
        }

        private void SetNewImageSet(int imageCount, string imageFolder)
        {
            var factor = 500 / imageCount;
            for (var i = ImageCount; i >= 0; i = i - 1)
            {
                var bitmapImage = new BitmapImage(new Uri(imageFolder + "Nature-" + i + ".jpg", UriKind.Relative));
                var img = ImageHelper.ResizeImage(bitmapImage, new Size(Width, Height));
                var r = (i * factor) + Radius;
                Images.Add(new CircleImage(img, r));
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            drawingContext.DrawImage(Images.First().Bitmap, new Rect(RenderSize));
            var point = new Point(_leftGaze.X, _leftGaze.Y);
            foreach (var image in Images)
            {
                image.DrawCircle(point, drawingContext, new Size(Width, Height));
            }
        }

        private void _trackButton_Click(object sender, RoutedEventArgs e)
        {
            if (_tracking)
            {
                _tracker.GazeDataReceived -= _tracker_GazeDataReceived;
                _tracker.StopTracking();

                _tracker.Dispose();
                _trackButton.Content = "Track";
                _tracking = false;
            }
            else
            {
                EyeTrackerInfo etInfo = _trackerCombo.SelectedItem as EyeTrackerInfo;
                if (etInfo != null)
                {
                    _tracker = etInfo.Factory.CreateEyeTracker();


                    _tracker.StartTracking();

                    _tracker.GazeDataReceived += _tracker_GazeDataReceived;

                    _trackButton.Content = "Stop";
                    _tracking = true;
                }

            }
        }

        private void _tracker_GazeDataReceived(object sender, GazeDataEventArgs e)
        {
            // Convert to centimeters
            const double D = 10.0;

            _leftPos.X = e.GazeDataItem.LeftEyePosition3D.X / D;
            _leftPos.Y = e.GazeDataItem.LeftEyePosition3D.Y / D;
            _leftPos.Z = e.GazeDataItem.LeftEyePosition3D.Z / D;

            _rightPos.X = e.GazeDataItem.RightEyePosition3D.X / D;
            _rightPos.Y = e.GazeDataItem.RightEyePosition3D.Y / D;
            _rightPos.Z = e.GazeDataItem.RightEyePosition3D.Z / D;

            _leftGaze.X = e.GazeDataItem.LeftGazePoint3D.X / D;
            _leftGaze.Y = e.GazeDataItem.LeftGazePoint3D.Y / D;
            _leftGaze.Z = e.GazeDataItem.LeftGazePoint3D.Z / D;

            _rightGaze.X = e.GazeDataItem.RightGazePoint3D.X / D;
            _rightGaze.Y = e.GazeDataItem.RightGazePoint3D.Y / D;
            _rightGaze.Z = e.GazeDataItem.RightGazePoint3D.Z / D;

        }

        void _browser_EyetrackerUpdated(object sender, EyeTrackerInfoEventArgs e)
        {
            int index = _trackerCombo.Items.IndexOf(e);

            if (index >= 0)
            {
                _trackerCombo.Items[index] = e.EyeTrackerInfo;
            }
        }

        void _browser_EyetrackerRemoved(object sender, EyeTrackerInfoEventArgs e)
        {
            _trackerCombo.Items.Remove(e.EyeTrackerInfo);
        }

        private void _browser_EyetrackerFound(object sender, EyeTrackerInfoEventArgs e)
        {
            _trackerCombo.Items.Add(e.EyeTrackerInfo);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _browser.StartBrowsing();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            _browser.StopBrowsing();

            if (_tracker != null)
            {
                _tracker.Dispose();
            }
        }
    }
}
