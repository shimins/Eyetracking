using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlurClass;

namespace BasicEyetrackingSample
{
    public partial class BlurForm : Form
    {
        private Bitmap _Image;
        private Bitmap _resultImage;
        private Bitmap _blurredImage;
         
        public BlurForm()
        {
            InitializeComponent();
        }

        private void _ImportImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Filter = "PNG files|*.png|JPEG files|*.jpeg|JPG files|*jpg|BMP files|*.bmp|GIF files|*.gif";
            DialogResult result = fDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                _Image = (Bitmap) Image.FromFile(fDialog.FileName);
                _ImagePath.Text = fDialog.FileName;
                if (_Image.Width > _HighestBlurLevel.Width && _Image.Height > _HighestBlurLevel.Height)
                {
                    _resultImage = new Bitmap(_Image, _HighestBlurLevel.Size);
                }
            }
            Upate();
        }

        private void _blurButton_Click(object sender, EventArgs e)
        {
            Upate();
        }

        private void _GobackButton_Click(object sender, EventArgs e)
        {
            Form mainForm = new MainForm();
            mainForm.Show();
            this.Close();
        }

        private void Upate()
        {
            _blurredImage = new Bitmap(Blur.GaussianBlur(_resultImage, (Int32.Parse(_blurLevel.Text) * 2 + 1)), _HighestBlurLevel.Size);
            _LowestBlurLevel.Image = _resultImage;
            _HighestBlurLevel.Image = _blurredImage;
        }

        private void _blurLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Upate();
        }
    }
}
