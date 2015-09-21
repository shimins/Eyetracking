using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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

        public MainWindow()
        {
            InitializeComponent();

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

            var point = new Point(400, 600);
            foreach (var image in Images)
            {
                image.DrawCircle(point, drawingContext);
            }
        }
    }
}
