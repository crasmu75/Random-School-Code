using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DemoSimulationJetMan
{
    class Simulation
    {
        private int[,] grid = {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,1,1,1,1,1,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0}};
        //you will update this from right to left, that way the front of the plane moves first
        //and the plane doesn't end up eating itself

        private int[,] tempGrid;
       
        public Simulation()
        {
            tempGrid = new int[grid.GetLength(0), grid.GetLength(1)];
            Start();
        }

        public void Start()
        {
            //DisplayGrid();
            do
            {
                UpdateGrid();
                DisplayGrid();
                Thread.Sleep(30);
            }
            while (!Console.KeyAvailable);
        }

        private void DisplayGrid()
        {
            Console.SetCursorPosition(0, 5);
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for(int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.Write(grid[i,j] == 0 ? '.' : '@');
                }
                Console.WriteLine();
            }
        }

        private void UpdateGrid()
        {
            for(int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (j != 0)
                        tempGrid[i, j] = grid[i, j - 1];
                    else
                        tempGrid[i, j] = grid[i, grid.GetUpperBound(1)];
                }
            }
            Array.Copy(tempGrid, grid, grid.Length);
        }
    }
}
