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

namespace LightsOut
{
    /// <summary>
    /// Interaction logic for Game_Page.xaml
    /// </summary>
    public partial class Game_Page : Page
    {
        public Game_Page()
        {
            InitializeComponent();
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.ChangeWindow(new Uri("./Menu.xaml", UriKind.Relative));
        }
    }
}
