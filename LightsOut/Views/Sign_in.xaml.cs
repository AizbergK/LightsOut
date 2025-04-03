using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
    /// Interaction logic for sing_in.xaml
    /// </summary>
    public partial class Sign_in : Page
    {
        public Sign_in()
        {
            InitializeComponent();
        }

        private void LogInClick(object sender, RoutedEventArgs e)
        {
            if (UsernameBox.Text.Length < 3 || UsernameBox.Text.Length > 20)
            {
                Username.Text = "Name must between 2 and 20 letters";
                return;
            }

            MainWindow.programUser.Name = UsernameBox.Text;

            string directoryPath = "./users";
            string fileName = UsernameBox.Text + ".txt";

            string[] files = Directory.GetFiles(directoryPath, fileName, SearchOption.TopDirectoryOnly);

            if (files.Length > 0)
            {
                MainWindow.programUser.LoadFromFile($"./users/{UsernameBox.Text}.txt");
                MainWindow.Instance.ChangeWindow(new Uri("/Views/Menu.xaml", UriKind.Relative));
            }
            else
            {
                Username.Text = "Enter a valid name or sign-up";
            }
        }
     

        private void SignUpClick(object sender, RoutedEventArgs e)
        {
            if (UsernameBox.Text.Length < 3 || UsernameBox.Text.Length > 20)
            {
                Username.Text = $"Name must between 2 and 20 letters";
                return;
            }

            if (!File.Exists($"./users/{UsernameBox.Text}.txt"))
            { 
                MainWindow.programUser.Name = UsernameBox.Text;
                MainWindow.programUser.Width = 3;
                MainWindow.programUser.Height = 3;
                MainWindow.programUser.Statistics = new List<string>();
            }
            else
            { 
                Username.Text = $"User already exists";
                return;
            }
            MainWindow.Instance.ChangeWindow(new Uri("/Views/Menu.xaml", UriKind.Relative));
        }

        private void PfpSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedUri = PfpSelect.SelectedItem?.ToString();
            MainWindow.programUser.Avatar = selectedUri;
        }
    }
}
