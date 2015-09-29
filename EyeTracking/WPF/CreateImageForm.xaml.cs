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
        private List<BitmapImage> bitmapList;
        private Blur blur;
        private Bitmap Image;
        private Bitmap blurredImage;
        

        public event EventHandler BitmapListUpdated;
        //private BlurBitmapEffect blur; prøve dette når du har tid

        public CreateImageForm()
        {
            bitmapList = new List<BitmapImage>();
            InitializeComponent();
            blur = new Blur();
        }

        private void ImportButton_OnClick(object sender, RoutedEventArgs e)
        {

            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Filter = "JPG files|*jpg|PNG files|*.png|JPEG files|*.jpeg|BMP files|*.bmp|GIF files|*.gif";
            Nullable<bool> result = fDialog.ShowDialog();
            if (result == true)
            {
                Image = (Bitmap)System.Drawing.Image.FromFile(fDialog.FileName);
                ImagePath.Text = fDialog.FileName;
                Update();
            }
        }

        private void Update()
        {
            var blurFactor = Image.Width / 250;
            blurredImage = blur.BlurImage(Image, (int)blurFactor);
            imageBeforeBlur.Source = ImageHelper.GetBitmapImage(Image);
            imageAfterBlur.Source = ImageHelper.GetBitmapImage(blurredImage);
        }

        public void SetBitmaps(List<BitmapImage> bitmapList)
        {
            this.bitmapList = bitmapList;
        }

        public List<BitmapImage> GeBitmapList()
        {
            return this.bitmapList;
        } 

        private void ComfirmButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (blurredImage != null)
            {
                bitmapList.Clear();
                bitmapList.Add(ImageHelper.GetBitmapImage(Image));
                for (var i = 1; i <= 10; i++)
                {
                    bitmapList.Add(ImageHelper.GetBitmapImage(blur.BlurImage(Image, i)));
                }
            }
            this.BitmapListUpdated(this, EventArgs.Empty);
            this.Close();
        }
    }
}
