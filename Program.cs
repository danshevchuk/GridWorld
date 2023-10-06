using System;
using System.Collections.Generic;

namespace GridWorld
{
    class Program
    {
        static void Main()
        {
            var grid = InitGrid("Maps/map01.txt");
            var maxMoves = GameParameters.MaxMoves;
            PlayerLoop(grid, maxMoves);
        }

        private static void PlayerLoop(Grid grid, int maxMoves)
        {
            int moves = 0;
            while (moves < maxMoves)
            {
                var goalAchieved = grid.Update();
                if(goalAchieved)
                {
                    Console.WriteLine("Goal Reached!");
                    break;
                }
                moves++;

                Thread.Sleep(50);
            }

            if (moves >= maxMoves)
            {
                Console.WriteLine("Moves exhausted. Try again.");
            }
        }

        private static Grid InitGrid(string mapPath)
        {
            var grid = new Grid();

            grid.LoadGridFromFile(mapPath);
            grid.DisplayGrid();

            return grid;
        }
    }
}
