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

namespace LightsOut.Views
{
    /// <summary>
    /// Interaction logic for Game_Page.xaml
    /// </summary>
    public partial class Game_Page : Page
    {
        public static LightsOut.Models.Game? currentGame { get; private set; }
        public Game_Page()
        {
            InitializeComponent();
            currentGame = new LightsOut.Models.Game(MainWindow.programUser.Width, MainWindow.programUser.Height);
            CreateColorGrid(currentGame.Width, currentGame.Height, 25);
            Username.Text = MainWindow.programUser.Name;
            Uri imageUri = new Uri(MainWindow.programUser.Avatar, UriKind.Absolute);
            PfpUser.Source = new BitmapImage(imageUri);
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            if (currentGame.TotalMoves != 0)
                MainWindow.programUser.Statistics.Add(DateOnly.FromDateTime(DateTime.Now).ToString() + " " + currentGame.TotalMoves.ToString() + " " + currentGame.GameFinished().ToString());
            MainWindow.Instance.ChangeWindow(new Uri("/Views/Menu.xaml", UriKind.Relative));
        }

        private void CreateColorGrid(int cols, int rows, int squareSize)
        {
            GameGrid.RowDefinitions.Clear();
            GameGrid.ColumnDefinitions.Clear();
            GameGrid.Children.Clear();

            // Define rows and columns
            for (int i = 0; i < rows; i++)
                GameGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(squareSize + 1) });

            for (int j = 0; j < cols; j++)
                GameGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(squareSize + 1) });

            Random rand = new Random();
            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    Rectangle rect = new Rectangle
                    {
                        Width = squareSize,
                        Height = squareSize,
                        
             
                    };
                    rect.MouseDown += ClickSquareEvent;
                    if (currentGame.GameBoard[i, j] == true)
                        rect.Fill = Brushes.LightGray;
                    else
                        rect.Fill = Brushes.Gray;
                    Grid.SetRow(rect, j);
                    Grid.SetColumn(rect, i);
                    GameGrid.Children.Add(rect);
                }
            }
        }

        private void ClickSquareEvent(object sender, MouseButtonEventArgs e)
        {
            if(!currentGame.GameFinished())
            {
                Rectangle clickedRectangle = sender as Rectangle;
                int j = Grid.GetRow(clickedRectangle);
                int i = Grid.GetColumn(clickedRectangle);

                currentGame.clickSquare(i, j);
                MovesCount.Text = currentGame.TotalMoves.ToString();
                CreateColorGrid(currentGame.Width, currentGame.Height, 25);
            }
            else
            {
                MessageBox.Show("Victory!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
    }
}
