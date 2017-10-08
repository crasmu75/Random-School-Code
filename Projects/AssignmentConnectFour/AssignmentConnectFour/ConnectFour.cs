/**
 * Connect Four
 * @author Camille Rasmussen
 **/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentConnectFour
{
    class ConnectFour
    {
        private int[,] grid = new int[6, 7];
        string title = "         CONNECT FOUR       ";
        string title1 = "                            \n";
        string prompt1 = "Press enter to start.";
        string prompt2 = "Which column would you like to place your piece in?";
        string promptRed = "     Red's Turn!     ";
        string promptYellow = "    Yellow's Turn!";
        string gameOver = "     Game Over!    ";

        Boolean gameWon = false;
        Boolean redsTurn = true;
        bool redWon = true;

        public ConnectFour()
        {
            Console.SetWindowSize(59, 45);
            InitGrid();
            Start();
            Finish();
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

        public void Start()
        {
            DisplayTitle();
            DisplayGrid();
            DisplayPrompts();
            do
            {
                Console.SetCursorPosition(21, 37);
                if (redsTurn)
                    UpdateGrid(RedsTurn(), 1);
                else
                    UpdateGrid(YellowsTurn(), 2);
                DisplayGrid();
                Console.SetCursorPosition(0, 31);
                Console.Write("     ");
            } while (!gameWon);
        }

        private void Finish()
        {
            Console.SetCursorPosition(19, 24);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(gameOver);
            Console.ResetColor();
            Console.SetCursorPosition(0, 30);
            if (redWon)
                Console.WriteLine("Red was the victor this round.                     ");
            else
                Console.WriteLine("Yellow was the victor this round.                  ");
        }

        private void DisplayGrid()
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                Console.SetCursorPosition(15, 10 + (i*2));
                Console.Write(" ");
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    if (grid[i, j] == 0)
                        Console.ForegroundColor = ConsoleColor.White;
                    if (grid[i, j] == 1)
                        Console.ForegroundColor = ConsoleColor.Red;
                    if (grid[i, j] == 2)
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(grid[i, j] == 0 ? "   " : " O ");
                    Console.ResetColor();
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        private void UpdateGrid(int newMove, int color)
        {
            for (int i = grid.GetLength(0) -1; i >= 0; i--)
            {
                if (grid[i, newMove - 1] == 0)
                {
                    grid[i, newMove - 1] = color;
                    GameStatus(i, newMove - 1, color);
                    return;
                }
            }
        }

        private void DisplayTitle()
        {
            Console.SetCursorPosition(15, 6);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(title1);
            Console.SetCursorPosition(15, 7);
            Console.WriteLine(title);
            Console.SetCursorPosition(15, 8);
            Console.WriteLine(title1);
            Console.ResetColor();
        }

        private void DisplayPrompts()
        {
            Console.SetCursorPosition(19, 24);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(prompt1);
            Console.ReadLine();
        }

        private int RedsTurn()
        {
            Console.SetCursorPosition(19, 24);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(promptRed);
            Console.ResetColor();
            Console.WriteLine("\n\n\n\n\n" + prompt2);
            int column = int.Parse(Console.ReadLine());
            redsTurn = false;
            return column;
        }

        private int YellowsTurn()
        {
            Console.SetCursorPosition(19, 24);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(promptYellow);
            Console.ResetColor();
            Console.WriteLine("\n\n\n\n\n" + prompt2);
            int column = int.Parse(Console.ReadLine());
            redsTurn = true;
            return column;
        }

        private void GameStatus(int row, int column, int color)
        {
            if (CheckVertical(row, column, color) >= 4 || CheckHorizontal(row, column, color) >= 4 ||
                CheckForwardDiag(row, column, color) >= 4 || CheckBackDiag(row, column, color) >= 4)
            {
                gameWon = true;
                if (color == 2)
                    redWon = false;
            }
        }

        private int CheckVertical(int row, int column, int color)
        {
            int numInRow = 0;
            while(row != grid.GetLength(0))
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
            while(column != grid.GetLength(1))
            {
                if (grid[row, column] == color)
                    numInRow++;
                else
                    break;
                column++;
            }
            //count to the left
            while(tempColumn >= 0)
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
            while(tempColumn >= 0 && tempRow < grid.GetLength(0))
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
    }
}
