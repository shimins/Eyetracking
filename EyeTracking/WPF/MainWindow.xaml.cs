using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Tobii.EyeTracking.IO;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private readonly EyeTrackerBrowser _browser;

        public List<BitmapImage> BitmapImages { get; set; }
        private CreateImageForm createImageForm;
        
        public MainWindow()
        {
            Library.Init();
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
            BitmapImages = new List<BitmapImage>();
            InitializeComponent();

            InputUserControl.TrackerUpdate += TrackerUpdate;
            InputUserControl.UpdateChanges += UpdateChanges;

            createImageForm = new CreateImageForm();
            createImageForm.BitmapListUpdated += BitmapListUpdate;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Window_Closed(object sender, EventArgs e)
        {
        }


        private void TrackerUpdate(object sender, EventArgs e)
        {
            if (TrackerUserControl.IsTracking)
            {
                TrackerUserControl.StopTracking();
                InputUserControl._trackButton.Content = "Track";
            }
            else
            {
                var etInfo = InputUserControl._trackerCombo.SelectedItem as EyeTrackerInfo;
                if (etInfo != null)
                {
                    TrackerUserControl.StartTracking(etInfo);
                    InputUserControl._trackButton.Content = "Stop";
                }
            }
        }

        private void UpdateChanges(object sender, EventArgs e)
        {
            TrackerUserControl.SetValue(InputUserControl.GetImageCount(), InputUserControl.GetInnerRadius(),
                InputUserControl.GetOuterRadius(),InputUserControl.GetDrawCircles(), BitmapImages);
        }

        private void CreateImageButton_OnClick(object sender, RoutedEventArgs e)
        {
            createImageForm.SetBitmaps(BitmapImages);
            createImageForm.Show();
        }

        private void BitmapListUpdate(object sender, EventArgs e)
        {
            TrackerUserControl.SetValue(InputUserControl.GetImageCount(), InputUserControl.GetInnerRadius(),
                InputUserControl.GetOuterRadius(), InputUserControl.GetDrawCircles(), createImageForm.GeBitmapList());
        }
    }
}
