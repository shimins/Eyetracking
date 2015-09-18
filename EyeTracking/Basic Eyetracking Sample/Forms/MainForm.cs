using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicEyetrackingSample
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void eyeTrackingButton_Click(object sender, EventArgs e)
        {
            Form trackerForm =  new TrackerForm();
            trackerForm.Show();
            this.Close();
        }

        //private void blurImageButton_Click(object sender, EventArgs e)
        //{
        //    Form blurForm = new CreateSettingForm();
        //    blurForm.Show();
        //    this.Close();
        //}
    }
}
