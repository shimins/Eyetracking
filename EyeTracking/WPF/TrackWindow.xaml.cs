using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Tobii.EyeTracking.IO;

namespace WPF
{
    /// <summary>
    /// Interaction logic for TrackWindow.xaml
    /// </summary>
    public partial class TrackWindow : Window
    {
        //private readonly EyeTrackerBrowser _browser;

        private List<BitmapImage> BitmapImages { get; set; }
        private CreateImageForm _createImageForm;

        private List<int> Radius;
        private List<int> Blurness;

        private int testNumber = 0;
        private int index = 1;

        public TrackWindow()
        {
            Library.Init();
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
            BitmapImages = new List<BitmapImage>();
            CreateTestList();
            InitializeComponent();

            InputUserControl.TrackerUpdate += TrackerUpdate;
            InputUserControl.UpdateChanges += UpdateChanges;

            _createImageForm = new CreateImageForm();
            _createImageForm.BitmapListUpdated += BitmapListUpdate;
            
        }

        private void TrackerUpdate(object sender, EventArgs e)
        {
            if (TrackerUserControl.IsTracking)
            {
                TrackerUserControl.StopTracking();
                InputUserControl.TrackButton.Content = "Track";
            }
            else
            {
                var etInfo = InputUserControl.TrackerCombo.SelectedItem as EyeTrackerInfo;
                if (etInfo != null)
                {
                    TrackerUserControl.StartTracking(etInfo);
                    InputUserControl.TrackButton.Content = "Stop";
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
            _createImageForm.SetBitmaps(BitmapImages);
            _createImageForm.Show();
        }

        private void BitmapListUpdate(object sender, EventArgs e)
        {
            TrackerUserControl.SetValue(InputUserControl.GetImageCount(), InputUserControl.GetInnerRadius(),
                InputUserControl.GetOuterRadius(), InputUserControl.GetDrawCircles(), _createImageForm.GeBitmapList());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Window_Closed(object sender, EventArgs e)
        {
        }

        private void CreateTestList()
        {
            Radius = new List<int>() {100,200,300,400};
            Blurness = new List<int>() {2,4,6,8};
            List<UserTest> list = new List<UserTest>();
            var temp = 1;
            foreach (var r in Radius)
            {
                foreach (var b in Blurness)
                {
                    list.Add(new UserTest("Test" + temp, r, b));
                    temp++;
                }
            }
            Shuffle(list);
            Tests.tests = list;
        }

        private void NextTestButton_OnClick(object sender, RoutedEventArgs e)
        {
            TrackerUserControl.SetValue(Tests.tests[testNumber].Blurness, Tests.tests[testNumber].Radius,
                750, false, BitmapImages);
            testNumber += 1;
            NextTestButton.IsEnabled = false;
            ReadyButton.IsEnabled = true;
            TrackerUserControl.StopTest(index, Tests.tests[testNumber].Blurness, Tests.tests[testNumber].Radius);
            TrackerUserControl.StopTracking();
            StatusEllipse.Fill = Brushes.Red;
        }

        public static void Shuffle<T>( IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        private void ReadyButton_OnClick(object sender, RoutedEventArgs e)
        {
            if(testNumber < Tests.tests.Count)
            {
                TrackerUserControl.StartTest(Tests.tests[testNumber].Name, Tests.tests[testNumber].Blurness,
                    Tests.tests[testNumber].Radius);
                index = testNumber + 1;
                TestCount.Content = "Test nr " + index + " av " + Tests.tests.Count;
                var etInfo = InputUserControl.TrackerCombo.SelectedItem as EyeTrackerInfo;
                if (etInfo != null)
                {
                    TrackerUserControl.StartTracking(etInfo);
                }
                NextTestButton.IsEnabled = true;
                ReadyButton.IsEnabled = false;
                StatusEllipse.Fill = Brushes.GreenYellow;
            }
            else
            {
                FinishWindow finishWindow = new FinishWindow();
                finishWindow.Show();
                this.Close();
            }
        }
    }
}
