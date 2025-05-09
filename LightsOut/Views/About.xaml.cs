﻿using System;
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
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : Page
    {
        public About()
        {
            InitializeComponent();
            Username.Text = MainWindow.programUser.Name;
            Uri imageUri = new Uri(MainWindow.programUser.Avatar, UriKind.Absolute);
            PfpUser.Source = new BitmapImage(imageUri);
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.ChangeWindow(new Uri("/Views/Menu.xaml", UriKind.Relative));
        }
    }
}
