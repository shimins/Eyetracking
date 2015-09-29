using System;
using System.Windows;
using System.Windows.Controls;
using Tobii.EyeTracking.IO;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private readonly EyeTrackerBrowser _browser;
        
        public MainWindow()
        {
            Library.Init();
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
            InitializeComponent();


            InputUserControl.TrackerUpdate += TrackerUpdate;
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
    }
}
