using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MenyWindow.xaml
    /// </summary>
    public partial class MenyWindow : Window
    {
        private TrackWindow _trackWindow;

        public MenyWindow()
        {
            InitializeComponent();
        }

        private void NewUserTestButton_OnClick(object sender, RoutedEventArgs e)
        {
            StaticValues.developerMode = false;
            StaticValues.User = new User(TesterName.Text);
            _trackWindow = new TrackWindow();
            this.Close();
            _trackWindow.Show();
        }

        private void DeveloperButton_OnClick(object sender, RoutedEventArgs e)
        {
            StaticValues.developerMode = true;
            _trackWindow = new TrackWindow();
            this.Close();
            _trackWindow.Show();
        }

        private void TesterName_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            NewUserTestButton.IsEnabled = true;
        }
    }
}
