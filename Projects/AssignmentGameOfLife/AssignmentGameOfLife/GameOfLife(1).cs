/* Camille Rasmussen
 * A02 - The Game of Life
 * January 30, 2014
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AssignmentGameOfLife
{
    class GameOfLife
    {
        private int[,] grid = new int[25, 40];
        private int[,] tempGrid;
        string title = "     T H E   G A M E   O F   L I F E    ";
        string title1 = "                                        \n";
        string prompt1 = "Press enter to start game.";
        string prompt2 = "  Press any key to stop.  ";
       
        public GameOfLife()
        {
            Console.SetWindowSize(70, 45);
            InitGrid();
            tempGrid = new int[grid.GetLength(0), grid.GetLength(1)];
            Start();
        }

        public void InitGrid()
        {
            //every cell is dead
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] = 0;
                }
            }

            //init beginning live cells
            for (int k = 14; k <= 26; k++)
            {
                grid[13, k] = 1;
            }
            for (int i = 8; i <= 10; i++)
            {
                grid[i, 12] = 1;
                grid[i, 20] = 1;
                grid[i, 28] = 1;
            }
        }

        public void Start()
        {
            DisplayTitle();
            DisplayGrid();
            DisplayPrompts();
            do
            {
                UpdateGrid();
                DisplayGrid();
                Console.SetCursorPosition(21, 37);
            }
            while (!Console.KeyAvailable);
        }

        public void UpdateGrid()
        {
            Array.Copy(grid, tempGrid, grid.Length);
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (CalculateNeighbors(i, j) == 0 || CalculateNeighbors(i, j) == 1)
                        tempGrid[i, j] = 0;
                    if (CalculateNeighbors(i, j) == 3)
                        tempGrid[i, j] = 1;
                    if (CalculateNeighbors(i, j) >= 4)
                        tempGrid[i, j] = 0;
                }
            }
            Array.Copy(tempGrid, grid, grid.Length);
        }

        public void DisplayGrid()
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                Console.SetCursorPosition(15, 10 + i);
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    if (grid[i, j] == 0)
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                    else
                        Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Write(grid[i, j] == 0 ? '.' : '.');
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }

        public void DisplayTitle()
        {
            Console.SetCursorPosition(15, 6);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(title1);
            Console.SetCursorPosition(15, 7);
            Console.WriteLine(title);
            Console.SetCursorPosition(15, 8);
            Console.WriteLine(title1);
            Console.ResetColor();
        }

        public void DisplayPrompts()
        {
            Console.SetCursorPosition(23, 37);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(prompt1);
            Console.ReadLine();
            Console.SetCursorPosition(23, 37);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(prompt2);
            Console.ResetColor();
        }

        private int CalculateNeighbors(int row, int column)
        {
            int neighbors = 0;
            neighbors += CalcAboveNeib(row, column);
            neighbors += CalcBelowNeib(row, column);
            neighbors += CalcMiddleNeib(row, column);
            neighbors += CalcLeftDiagonalNeib(row, column);
            neighbors += CalcRightDiagonalNeib(row, column);
            return neighbors;
        }

        private int CalcAboveNeib(int row, int column)
        {
            int aboveNeib = 0;
            if (row != 0)
                if (grid[row - 1, column] == 1)
                    aboveNeib++;
            return aboveNeib;
        }
        private int CalcMiddleNeib(int row, int column)
        {
            int middleNeib = 0;
            if (column != 39)
                if (grid[row, column + 1] == 1)
                    middleNeib++;
            if (column != 0)
                if (grid[row, column - 1] == 1)
                    middleNeib++;
            return middleNeib;
        }
        private int CalcBelowNeib(int row, int column)
        {
            int belowNeib = 0;
            if (row != 24)
                if (grid[row + 1, column] == 1)
                    belowNeib++;
            return belowNeib;
        }
        private int CalcLeftDiagonalNeib(int row, int column)
        {
            int diagNeib = 0;
            if (row != 0 && column != 0)
                if (grid[row - 1, column - 1] == 1)
                    diagNeib++;
            if (row != 24 && column != 0)
                if (grid[row + 1, column - 1] == 1)
                    diagNeib++;
            return diagNeib;
        }
        private int CalcRightDiagonalNeib(int row, int column)
        {
            int diagNeib = 0;
            if (row != 0 && column != 39)
                if (grid[row - 1, column + 1] == 1)
                    diagNeib++;
            if (row != 24 && column != 39)
                if (grid[row + 1, column + 1] == 1)
                    diagNeib++;
            return diagNeib;
        }
    }//end class GameOfLife
}
