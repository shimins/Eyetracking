using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Media.Imaging;
using ImageBlur;
using Microsoft.Win32;

namespace WPF
{
    /// <summary>
    /// Interaction logic for CreateImageForm.xaml
    /// </summary>
    public partial class CreateImageForm : Window
    {
        private List<BitmapImage> _bitmapList;
        private Blur _blur;
        private Bitmap _image;
        private Bitmap _blurredImage;
        

        public event EventHandler BitmapListUpdated;
        //private BlurBitmapEffect blur; prøve dette når du har tid

        public CreateImageForm()
        {
            _bitmapList = new List<BitmapImage>();
            InitializeComponent();
            _blur = new Blur();
        }

        private void ImportButton_OnClick(object sender, RoutedEventArgs e)
        {

            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Filter = "JPG files|*jpg|PNG files|*.png|JPEG files|*.jpeg|BMP files|*.bmp|GIF files|*.gif";
            Nullable<bool> result = fDialog.ShowDialog();
            if (result == true)
            {
                _image = (Bitmap)System.Drawing.Image.FromFile(fDialog.FileName);
                ImagePath.Text = fDialog.FileName;
                Update();
            }
        }

        private void Update()
        {
            var blurFactor = 10;
            _blurredImage = _blur.BlurImage(_image, (int)blurFactor);
            ImageBeforeBlur.Source = ImageHelper.GetBitmapImage(_image);
            ImageAfterBlur.Source = ImageHelper.GetBitmapImage(_blurredImage);
        }

        public void SetBitmaps(List<BitmapImage> bitmapList)
        {
            this._bitmapList = bitmapList;
        }

        public List<BitmapImage> GeBitmapList()
        {
            return this._bitmapList;
        } 

        private void ComfirmButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (_blurredImage != null)
            {
                _bitmapList.Clear();
                _bitmapList.Add(ImageHelper.GetBitmapImage(_image));
                for (var i = 1; i <= 10; i++)
                {
                    _bitmapList.Add(ImageHelper.GetBitmapImage(_blur.BlurImage(_image, i)));
                }
            }
            BitmapListUpdated(this, EventArgs.Empty);
            this.Hide();
        }
    }
}
