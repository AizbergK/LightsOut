using LightsOut.Models;
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
using static System.Net.Mime.MediaTypeNames;

namespace LightsOut.Views
{
    /// <summary>
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : Page
    {
        public Statistics()
        {
            InitializeComponent();
            FillGrid();
            Username.Text = MainWindow.programUser.Name;
            Uri imageUri = new Uri(MainWindow.programUser.Avatar, UriKind.Absolute);
            PfpUser.Source = new BitmapImage(imageUri);
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.ChangeWindow(new Uri("/Views/Menu.xaml", UriKind.Relative));
        }
        private void FillGrid()
        {
            int rowNumber = 1;
            StatisticsView.RowDefinitions.Clear();
            StatisticsView.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            TextBlock dateRow = new TextBlock
            {
                Text = "Date",
                FontWeight = FontWeights.Bold,
            };
            Grid.SetRow(dateRow, 0);
            Grid.SetColumn(dateRow, 0);
            StatisticsView.Children.Add(dateRow);
            TextBlock movesRow = new TextBlock
            {
                Text = "Moves",
                FontWeight = FontWeights.Bold,
            };
            Grid.SetRow(movesRow, 0);
            Grid.SetColumn(movesRow, 1);
            StatisticsView.Children.Add(movesRow);
            TextBlock finishedRow = new TextBlock
            {
                Text = "Finished",
                FontWeight = FontWeights.Bold,
            };
            Grid.SetRow(finishedRow, 0);
            Grid.SetColumn(finishedRow, 2);
            StatisticsView.Children.Add(finishedRow);

            //if(MainWindow.programUser.Statistics.Count() != 0 && MainWindow.programUser.Statistics[0] != "")
            //{
            var arr = MainWindow.programUser.Statistics;
                for (var i = arr.Count - 1; i >= 0;--i)
                {
                    SolidColorBrush brush;
                    string[] tableElements = arr[i].Split(' ');
                    if (rowNumber % 2 == 1)
                        brush = Brushes.LightGray;
                    else
                        brush = Brushes.White;

                    StatisticsView.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                    TextBlock dateRowStats = new TextBlock
                    {
                        Text = tableElements[0],
                        FontWeight = FontWeights.Bold,
                        Background = brush,
                    };
                    Grid.SetRow(dateRowStats, rowNumber);
                    Grid.SetColumn(dateRowStats, 0);
                    StatisticsView.Children.Add(dateRowStats);

                    TextBlock movesRowStats = new TextBlock
                    {
                        Text = tableElements[1],
                        FontWeight = FontWeights.Bold,
                        Background = brush,
                    };
                    Grid.SetRow(movesRowStats, rowNumber);
                    Grid.SetColumn(movesRowStats, 1);
                    StatisticsView.Children.Add(movesRowStats);

                    TextBlock finishedRowStats = new TextBlock
                    {
                        Text = tableElements[2],
                        FontWeight = FontWeights.Bold,
                        Background = brush,
                    };
                    Grid.SetRow(finishedRowStats, rowNumber);
                    Grid.SetColumn(finishedRowStats, 2);
                    StatisticsView.Children.Add(finishedRowStats);

                    ++rowNumber;
                }
            //}
        }
    }
}
