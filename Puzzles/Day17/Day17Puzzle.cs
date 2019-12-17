using System;
using System.Collections.Generic;
using AdventOfCode2019.Core;
using AdventOfCode2019.Core.Emulation;

namespace AdventOfCode2019.Puzzles.Day17
{
    public abstract class Day17Puzzle : PuzzleBase
    {
        protected override string GetPuzzleData()
        {
            return "/Day17Data.txt";
        }

        protected IntComputer computer;
        protected Dictionary<IntVector2, int> viewData;

        public override void Initialize()
        {
            base.Initialize();

            computer = new IntComputer(lines);
            computer.Load();
            computer.Run();

            viewData = new Dictionary<IntVector2, int>();

            IntVector2 origin = new IntVector2(0,0);
            while (computer.HasOutputs())
            {
                int output = (int)computer.GetOutput();

                if (output == 10)
                {
                    origin.X = 0;
                    origin.Y++;
                    continue;
                }

                viewData.Add(new IntVector2(origin.X, origin.Y), output);

                origin.X++;
            }
        }

        protected void Debug(List<IntVector2> intersections = null)
        {
            foreach (var pair in viewData)
            {
                Console.SetCursorPosition(pair.Key.X, pair.Key.Y);
                Console.Write(GetAscii(pair.Value));

                if (intersections == null)
                    continue;

                int index = intersections.IndexOf(pair.Key);
                if (index == -1)
                    continue;

                Console.SetCursorPosition(pair.Key.X, pair.Key.Y);
                Console.Write("O");
            }
        }

        protected string GetAscii(int code)
        {
            switch(code)
            {
                case 35:
                    return "#";
                case 46:
                    return ".";
            }

            return "?";
        }
    }
}
