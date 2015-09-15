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
                _Image = (Bitmap) Bitmap.FromFile(fDialog.FileName.ToString());
                _ImagePath.Text = fDialog.FileName.ToString();
            }
            _upDate();
        }

        private void _blurButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine(_blurLevel.Value);
            _upDate();
        }

        private void _GobackButton_Click(object sender, EventArgs e)
        {
            Form mainForm = new MainForm();
            mainForm.Show();
            this.Close();
        }

        private void _upDate()
        {
            _blurredImage = Blur._GaussianBlur(_Image, (int) _blurLevel.Value);
            _LowestBlurLevel.BackgroundImage = _Image;
            _HighestBlurLevel.BackgroundImage = _blurredImage;
        }

        private void _blurLevel_ValueChanged_1(object sender, EventArgs e)
        {
            _upDate();
        }
    }
}
