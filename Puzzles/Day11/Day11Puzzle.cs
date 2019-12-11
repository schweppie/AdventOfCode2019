using System;

namespace AdventOfCode2019.Puzzles.Day11
{
    public abstract class Day11Puzzle : PuzzleBase
    {
        protected override string GetPuzzleData()
        {
            return "/Day11Data.txt";
        }

        protected int[,] panelGrid;
        protected bool[,] isPaintedGrid;

        protected Robot robot;

        protected const int SIZE = 1000;

        public override void Initialize()
        {
            base.Initialize();

            panelGrid = new int[SIZE,SIZE];
            isPaintedGrid = new bool[SIZE,SIZE];

            for (int i=0; i<SIZE; i++)
            {
                for (int j=0; j<SIZE; j++)
                {
                    panelGrid[i,j] = 0;
                    isPaintedGrid[i,j] = false;
                }
            }

            robot = new Robot(500, 500, lines);
        }

        protected void DebugGrid()
        {
            for (int i=0; i<SIZE; i++)
            {
                for (int j=0; j<SIZE; j++)
                {
                    if (robot.Position.X == j && robot.Position.Y == i)
                    {
                        Console.Write("@");
                        continue;
                    }

                    Console.Write(isPaintedGrid[j,i] ? "#" : ".");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
