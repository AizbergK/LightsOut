using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using static System.Net.Mime.MediaTypeNames;

namespace LightsOut.Views
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        public Menu()
        {
            InitializeComponent();
            Username.Text = MainWindow.programUser.Name;
            Uri imageUri = new Uri(MainWindow.programUser.Avatar, UriKind.Absolute);
            PfpUser.Source = new BitmapImage(imageUri);

        }
        private void StartGameClick(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.ChangeWindow(new Uri("/Views/Game_Page.xaml", UriKind.Relative));
        }
        private void StatisticsClick(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.ChangeWindow(new Uri("/Views/Statistics.xaml", UriKind.Relative));
        }
        private void SettingsClick(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.ChangeWindow(new Uri("/Views/Settings.xaml", UriKind.Relative));
            
        }
        private void AboutClick(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.ChangeWindow(new Uri("/Views/About.xaml", UriKind.Relative));
        }
        private void ExitClick(object sender, RoutedEventArgs e)
        {
            MainWindow.programUser.SaveToFile();
            MainWindow.Instance.ChangeWindow(new Uri("/Views/Sign_in.xaml", UriKind.Relative));
        }
        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            MainWindow.programUser.DeleteFile();
            MainWindow.Instance.ChangeWindow(new Uri("/Views/Sign_in.xaml", UriKind.Relative));
        }
    }
}

