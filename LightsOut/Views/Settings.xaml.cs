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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LightsOut.Views
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        private int GridWidth = 3;
        private int GridHeight = 3;
        public Settings()
        {
            InitializeComponent();
            width.Text = $"{MainWindow.programUser.Width}";
            height.Text = $"{MainWindow.programUser.Height}";
            Username.Text = MainWindow.programUser.Name;
            Uri imageUri = new Uri(MainWindow.programUser.Avatar, UriKind.Absolute);
            PfpUser.Source = new BitmapImage(imageUri);
        }
        private void BackClick(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.ChangeWindow(new Uri("/Views/Menu.xaml", UriKind.Relative));

        }

        private void DecreaseWidth(object sender, RoutedEventArgs e)
        {
            if(MainWindow.programUser.Width > 3)
                width.Text = $"{--MainWindow.programUser.Width}";
        }

        private void IncreaseWidth(object sender, RoutedEventArgs e)
        {
            if (MainWindow.programUser.Width < 10)
                width.Text = $"{++MainWindow.programUser.Width}";
        }

        private void DecreaseHeight(object sender, RoutedEventArgs e)
        {
            if (MainWindow.programUser.Height > 3)
                height.Text = $"{--MainWindow.programUser.Height}";
        }

        private void IncreaseHeight(object sender, RoutedEventArgs e)
        {
            if (MainWindow.programUser.Height < 10)
                height.Text = $"{++MainWindow.programUser.Height}";
        }
    }
}
