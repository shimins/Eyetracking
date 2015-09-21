using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using ImageBlur;

namespace BasicEyetrackingSample
{
    public partial class CreateImageForm : Form
    {
        private Bitmap _Image;
        private Bitmap _resultImage;
        private Bitmap _blurredImage;
        private Blur blur;
        private int blurFactor;
        private TrackerForm trackerForm;

        public CreateImageForm()
        {
            InitializeComponent();
            blur = new Blur();
            trackerForm = new TrackerForm();
        }


        private void _ImportImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Filter = "JPG files|*jpg|PNG files|*.png|JPEG files|*.jpeg|BMP files|*.bmp|GIF files|*.gif";
            DialogResult result = fDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                _Image = (Bitmap)Image.FromFile(fDialog.FileName);
                _ImagePath.Text = fDialog.FileName;
                Upate();
            }
        }

        private void _GobackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Upate()
        {
            blurFactor = _Image.Width/250;
            _blurredImage = blur.BlurImage(_Image, blurFactor);
            _LowestBlurLevel.Image = _Image;
            _HighestBlurLevel.Image = _blurredImage;
        }


        private void _saveButton_Click(object sender, EventArgs e)
        {
            if (_blurredImage != null)
            {
                trackerForm.ClearImageList();
                trackerForm.SetImageList(_Image);
                for (var i = 1; i <= 10; i++)
                {
                    trackerForm.SetImageList(blur.BlurImage(_Image, i));
                }
            }
            trackerForm.NewImageListConfirmed();
            this.Close();
        }
    }
}
