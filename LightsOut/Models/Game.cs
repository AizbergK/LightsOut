using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightsOut.Models
{
    public class Game
    {
        public int Width;
        public int Height;
        public int TotalMoves = 0;
        public bool[,] GameBoard;

        public Game(int width, int height)
        {
            Width = width;
            Height = height;
            GameBoard = new bool[Width, Height];
            initGame();
        }
        private void initGame()
        {
            Random rand = new Random();
            int steps = Width * Height / 3;
            for (int i = 0; i <= steps; ++i)
            {
                int randI = rand.Next(0, Width);
                int randJ = rand.Next(0, Height);
                if (GameBoard[randI, randJ] != true)
                    clickSquare(randI, randJ);
            }
            TotalMoves = 0;
        }

        public void clickSquare(int i, int j)
        {
            FlipSquare(i, j);
            FlipSquare(i + 1, j);
            FlipSquare(i - 1, j);
            FlipSquare(i, j + 1);
            FlipSquare(i, j - 1);
            ++TotalMoves;
        }

        private void FlipSquare(int i, int j)
        {
            if (i >= 0 && i < GameBoard.GetLength(0) && j >= 0 && j < GameBoard.GetLength(1))
                GameBoard[i, j] = !GameBoard[i, j];
        }
        public bool GameFinished()
        {
            for(int i = 0; i != GameBoard.GetLength(0); ++i)
                for(int j = 0; j != GameBoard.GetLength(1); ++j)
                    if (GameBoard[i,j]) return false;
            return true;
        }
    }
}
