/**
 * MainWindow.xaml.cs
 * 3/3/14
 * @author Camille Rasmussen
 **/

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
using System.Windows.Threading;

namespace ConnectFourGui
{
    public partial class MainWindow : Window
    {
        public System.Windows.Visibility visible { get; set; }
        public System.Windows.Visibility hidden { get; set; }

        private int[,] grid = new int[6, 7];
        private readonly DispatcherTimer timer; // read-only gets initialized once, and only in constructor
        Ellipse gameStone = new Ellipse();
        private const int stepSize = 10; //affects the speed of the object
        private int bottomStop = 128;
        bool redsTurn = true;
        int c1count, c2count, c3count, c4count, c5count, c6count, c7count = 0;

        public MainWindow()
        {
            InitializeComponent();

            Canvas.SetZIndex(GameBoard, 100);
            Canvas.SetZIndex(GameOver, 100);
            CreateRectangle();

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 25); //update 40 times a second
            timer.Tick += timer_Tick;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            double bottom = Canvas.GetBottom(gameStone);

            if (bottom - stepSize >= bottomStop)
                Canvas.SetBottom(gameStone, bottom - stepSize);
            else
            {
                Canvas.SetBottom(gameStone, bottomStop);
                timer.Stop();
            }
        }

        public void InitGrid()
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] = 0;
                }
            }
        }

        private void UpdateGrid(int newMove, int color)
        {
            for (int i = grid.GetLength(0) - 1; i >= 0; i--)
            {
                if (grid[i, newMove - 1] == 0)
                {
                    grid[i, newMove - 1] = color;
                    GameStatus(i, newMove - 1, color);
                    return;
                }
            }
        }

        private void GameStatus(int row, int column, int color)
        {
            if (CheckVertical(row, column, color) >= 4 || CheckHorizontal(row, column, color) >= 4 ||
                CheckForwardDiag(row, column, color) >= 4 || CheckBackDiag(row, column, color) >= 4)
            {
                GameOver.Visibility = visible;
                instructions.Content = "";
                if (color == 1)
                    lblRedWon.Visibility = visible;
                else if (color == 2)
                    lblYellowWon.Visibility = visible;
                whosTurn.Content = "";
            }
        }

        private int CheckVertical(int row, int column, int color)
        {
            int numInRow = 0;
            while (row != grid.GetLength(0))
            {
                if (grid[row, column] == color)
                    numInRow++;
                else
                    return numInRow;
                row++;
            }
            return numInRow;
        }
        private int CheckHorizontal(int row, int column, int color)
        {
            int numInRow = 1;
            int tempColumn = column;
            column++;
            tempColumn--;
            //count to the right
            while (column != grid.GetLength(1))
            {
                if (grid[row, column] == color)
                    numInRow++;
                else
                    break;
                column++;
            }
            //count to the left
            while (tempColumn >= 0)
            {
                if (grid[row, tempColumn] == color)
                    numInRow++;
                else
                    return numInRow;
                tempColumn--;
            }
            return numInRow;
        }
        private int CheckForwardDiag(int row, int column, int color)
        {
            int numInRow = 0;
            int tempRow = row + 1;
            int tempColumn = column - 1;
            //count to the right
            while (column != grid.GetLength(1) && row >= 0)
            {
                if (grid[row, column] == color)
                    numInRow++;
                else
                    break;
                row--; column++;
            }
            //count to the left
            while (tempColumn >= 0 && tempRow < grid.GetLength(0))
            {
                if (grid[tempRow, tempColumn] == color)
                    numInRow++;
                else
                    return numInRow;
                tempColumn--; tempRow++;
            }
            return numInRow;
        }
        private int CheckBackDiag(int row, int column, int color)
        {
            int numInRow = 0;
            int tempRow = row - 1;
            int tempColumn = column - 1;
            //count to the right
            while (column != grid.GetLength(1) && row < grid.GetLength(0))
            {
                if (grid[row, column] == color)
                    numInRow++;
                else
                    break;
                row++; column++;
            }
            //count to the left
            while (tempColumn >= 0 && tempRow >= 0)
            {
                if (grid[tempRow, tempColumn] == color)
                    numInRow++;
                else
                    return numInRow;
                tempColumn--; tempRow--;
            }
            return numInRow;
        }

        private void CreateRectangle()
        {
            Rectangle rect = new Rectangle();
            rect.Width = 496;
            rect.Height = 25;
            rect.Fill = Brushes.Black;

            MyCanvas.Children.Add(rect);
            Canvas.SetLeft(rect, 0);
            Canvas.SetBottom(rect, 101);
        }

        private Ellipse DrawCircle(int left, SolidColorBrush color)
        {
            Ellipse newCircle = new Ellipse();
            newCircle.Width = 55;
            newCircle.Height = 55;
            newCircle.Fill = color;

            MyCanvas.Children.Add(newCircle);
            Canvas.SetLeft(newCircle, left);
            Canvas.SetBottom(newCircle, 700);

            return newCircle;
        }

        private void SetBottomLimit(int numInColumn)
        {
            if (numInColumn == 0)
                bottomStop = 128;
            if (numInColumn == 1)
                bottomStop = 188;
            if (numInColumn == 2)
                bottomStop = 248;
            if (numInColumn == 3)
                bottomStop = 308;
            if (numInColumn == 4)
                bottomStop = 368;
            if (numInColumn == 5)
                bottomStop = 428;
        }

        private void RedsTurn(int lefty, int column)
        {
            gameStone = DrawCircle(lefty, Brushes.Red);
            redsTurn = false;
            whosTurn.Content = "Yellow's Turn!";
            whosTurn.Foreground = Brushes.Yellow;
            UpdateGrid(column, 1);
        }

        private void YellowsTurn(int lefty, int column)
        {
            gameStone = DrawCircle(lefty, Brushes.Gold);
            redsTurn = true;
            whosTurn.Content = "Red's Turn!";
            whosTurn.Foreground = Brushes.Red;
            UpdateGrid(column, 2);
        }

        private void Column1_Click(object sender, RoutedEventArgs e)
        {
            SetBottomLimit(c1count);
            if (redsTurn)
            {
                RedsTurn(10, 1);
            }
            else
            {
                YellowsTurn(10, 1);
            }
            timer.IsEnabled = true;
            timer.Start();
            c1count++;
        }

        private void Column2_Click(object sender, RoutedEventArgs e)
        {
            SetBottomLimit(c2count);
            if (redsTurn)
            {
                RedsTurn(77, 2);
            }
            else
            {
                YellowsTurn(77, 2);
            }
            timer.IsEnabled = true;
            timer.Start();
            c2count++;
        }

        private void Column3_Click(object sender, RoutedEventArgs e)
        {
            SetBottomLimit(c3count);
            if (redsTurn)
            {
                RedsTurn(144, 3);
            }
            else
            {
                YellowsTurn(144, 3);
            }
            timer.IsEnabled = true;
            timer.Start();
            c3count++;
        }

        private void Column4_Click(object sender, RoutedEventArgs e)
        {
            SetBottomLimit(c4count);
            if (redsTurn)
            {
                RedsTurn(213, 4);
            }
            else
            {
                YellowsTurn(213, 4);
            }
            timer.IsEnabled = true;
            timer.Start();
            c4count++;
        }

        private void Column5_Click(object sender, RoutedEventArgs e)
        {
            SetBottomLimit(c5count);
            if (redsTurn)
            {
                RedsTurn(280, 5);
            }
            else
            {
                YellowsTurn(280, 5);
            }
            timer.IsEnabled = true;
            timer.Start();
            c5count++;
        }

        private void Column6_Click(object sender, RoutedEventArgs e)
        {
            SetBottomLimit(c6count);
            if (redsTurn)
            {
                RedsTurn(348, 6);
            }
            else
            {
                YellowsTurn(348, 6);
            }
            timer.IsEnabled = true;
            timer.Start();
            c6count++;
        }

        private void Column7_Click(object sender, RoutedEventArgs e)
        {
            SetBottomLimit(c7count);
            if (redsTurn)
            {
                RedsTurn(415, 7);
            }
            else
            {
                YellowsTurn(415, 7);
            }
            timer.IsEnabled = true;
            timer.Start();
            c7count++;
        }
    }
}
