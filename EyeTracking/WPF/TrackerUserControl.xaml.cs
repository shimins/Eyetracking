﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Tobii.EyeTracking.IO;

namespace WPF
{
    /// <summary>
    /// Interaction logic for TrackerUserControl.xaml
    /// </summary>
    public partial class TrackerUserControl : UserControl
    {
        public bool IsTracking { get; set; }
        public readonly List<CircleImage> Images = new List<CircleImage>();
        private IEyeTracker EyeTracker { get; set; }

        private Point2D _leftGaze;
        private Point2D _rightGaze;

        private Point2D _current;
        private Point2D _previous;

        private Point Point { get; set; }

        public TrackerUserControl()
        {
            InitializeComponent();
            SetValue(5,400,new List<BitmapImage>());

            _previous.X = 0;
            _previous.Y = 0;
            InvalidateVisual();
        }

        private void SetNewImageSet(int imageCount,int radius, List<BitmapImage> images)
        {
            var factor = 500 / imageCount;
            if (images.Count <= 0)
            {
                for (var i = imageCount; i >= 0; i = i - 1)
                {
                    var bitmapImage = new BitmapImage(new Uri("images/nature/Nature-" + i + ".jpg", UriKind.Relative));
                    var img = ImageHelper.ResizeImage(bitmapImage, new Size(Width, Height));
                    var r = (i*factor) + radius;
                    Images.Add(new CircleImage(img, r));
                }
            }
            else
            {
                for (var i = imageCount; i >= 0; i = i - 1)
                {
                    var bitmapImage = images[i];
                    var img = ImageHelper.ResizeImage(bitmapImage, new Size(Width, Height));
                    var r = (i * factor) + radius;
                    Images[i] = new CircleImage(img, r);
                }
            }
        }

        private void SetBackGround(int imageCount, List<BitmapImage> imageList)
        {
            if (imageList.Count <= 0)
            {
                this.Background =
                    new ImageBrush(new BitmapImage(new Uri("images/nature/Nature-" + imageCount + ".jpg", UriKind.Relative)));
            }
            else
            {
                this.Background =
                   new ImageBrush(imageList[imageCount]);
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            drawingContext.DrawImage(Images.First().Bitmap, new Rect(RenderSize));
            //var point = new Point(_leftGaze.X, _leftGaze.Y);
            foreach (var image in Images)
            {
                image.DrawCircle(Point, drawingContext, RenderSize);
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

            if (!(_leftGaze.X > -1.0)) return;
            _current = new Point2D((_leftGaze.X + _rightGaze.X)/2, (_leftGaze.Y + _rightGaze.Y)/2);
            if (!GazeHaveMoved(_current)) return;
            _previous = _current;

            Point = new Point(_previous.X, _previous.Y);
            InvalidateVisual();
        }

        private bool GazeHaveMoved(Point2D currentPoint)
        {
            if (Math.Abs(_previous.X - currentPoint.X) > 0.05 || Math.Abs(_previous.Y - currentPoint.Y) > 0.05)
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

        public void SetValue(int imageCount, int radius, List<BitmapImage> imageList)
        {
            SetBackGround(imageCount, imageList);
            SetNewImageSet(imageCount, radius, imageList);
        }
    }
}
