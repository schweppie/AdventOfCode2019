using System;
using AdventOfCode2019.Core;

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

        protected const int WIDTH = 10000;
        protected const int HEIGHT = 10000;

        protected IntVector2 origin = IntVector2.Max();
        protected IntVector2 extends = IntVector2.Min();

        public override void Initialize()
        {
            base.Initialize();

            panelGrid = new int[WIDTH,HEIGHT];
            isPaintedGrid = new bool[WIDTH,HEIGHT];

            for (int i=0; i<WIDTH; i++)
            {
                for (int j=0; j<HEIGHT; j++)
                {
                    panelGrid[i,j] = 0;
                    isPaintedGrid[i,j] = false;
                }
            }

            robot = new Robot(5000, 5000, lines);
        }

        protected void CheckBounds()
        {
            if(robot.Position.X < origin.X)
                origin.X = robot.Position.X;
            if(robot.Position.Y < origin.Y)
                origin.Y = robot.Position.Y;

            if(robot.Position.X > extends.X)
                extends.X = robot.Position.X;
            if(robot.Position.Y > extends.Y)
                extends.Y = robot.Position.Y;
        }

        protected void DrawGrid()
        {
            for (int i=origin.Y; i<=extends.Y; i++)
            {
                for (int j=origin.X; j<extends.X; j++)
                {
                    if (robot.Position.X == j && robot.Position.Y == i)
                    {
                        Console.Write("@");
                        continue;
                    }

                    Console.Write(panelGrid[j, i] == 1 ? "*" : " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
