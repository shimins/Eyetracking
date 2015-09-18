using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlurClass;

namespace BasicEyetrackingSample
{
    public partial class CreateSettingForm : Form
    {
        private Bitmap _Image;
        private Bitmap _resultImage;
        private Bitmap _blurredImage;

        public CreateSettingForm()
        {
            InitializeComponent();
        }

        //private void _ImportImageButton_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog fDialog = new OpenFileDialog();
        //    fDialog.Filter = "PNG files|*.png|JPEG files|*.jpeg|JPG files|*jpg|BMP files|*.bmp|GIF files|*.gif";
        //    DialogResult result = fDialog.ShowDialog();
        //    if (result == DialogResult.OK)
        //    {
        //        _Image = (Bitmap) Image.FromFile(fDialog.FileName);
        //        _ImagePath.Text = fDialog.FileName;
        //        if (_Image.Width > _HighestBlurLevel.Width && _Image.Height > _HighestBlurLevel.Height)
        //        {
        //            _resultImage = new Bitmap(_Image, _Image.Size);
        //            //_resultImage = new Bitmap(_Image, _HighestBlurLevel.Size);
        //        }
        //    }
        //    Upate();
        //}

        //private void _blurButton_Click(object sender, EventArgs e)
        //{
        //    Upate();
        //}

        //private void _GobackButton_Click(object sender, EventArgs e)
        //{
        //    Form trackerForm = new TrackerForm();
        //    trackerForm.Show();
        //    this.Hide();
        //}

        //private void Upate()
        //{
        //    //_blurredImage = Blur.BlurImage(_resultImage, (Int32.Parse(_blurLevel.Text) * 2 + 1));
        //    _blurredImage = Blur.BlurImage(_resultImage, (Int32.Parse(_blurLevel.Text)));
        //    _LowestBlurLevel.Image = _resultImage;
        //    _HighestBlurLevel.Image = _blurredImage;
        //}

        //private void _blurLevel_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Upate();
        //}

        //private void _saveButton_Click(object sender, EventArgs e)
        //{
        //    if (_blurredImage != null)
        //    {
        //        SaveFileDialog sfd = new SaveFileDialog();
        //        sfd.Title = "Specify a file name and file path";
        //        sfd.Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg";
        //        sfd.Filter += "|Bitmap Images(*.bmp)|*.bmp";

        //        if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //        {
        //            string fileExtension = Path.GetExtension(sfd.FileName).ToUpper();
        //            ImageFormat imgFormat = ImageFormat.Png;

        //            if (fileExtension == "BMP")
        //            {
        //                imgFormat = ImageFormat.Bmp;
        //            }
        //            else if (fileExtension == "JPG")
        //            {
        //                imgFormat = ImageFormat.Jpeg;
        //            }
        //            for (var i = 0; i < Int32.Parse(_numberOfImages.Text); i++)
        //            {
        //                StreamWriter streamWriter = new StreamWriter(sfd.FileName, false);
        //                _blurredImage = new Bitmap(Blur.GaussianBlur(_resultImage, (i*2 + 1)), _HighestBlurLevel.Size);
        //                _blurredImage.Save(streamWriter.BaseStream, imgFormat);
        //                streamWriter.Flush();
        //                streamWriter.Close();
        //            }
        //            _blurredImage = null;
        //        }
        //    }
        //}



        //private void applyButton_Click(object sender, EventArgs e)
        //{
        //    this._blurLevel.SelectedIndex = _blurLevel.SelectedIndex;
        //    this._numberOfImages.SelectedIndex = _numberOfImages.SelectedIndex;
        //    this.radiusBox.SelectedIndex = radiusBox.SelectedIndex;
        //}
    }
}
