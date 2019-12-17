using System;
using AdventOfCode2019.Core.Pathfinding;

namespace AdventOfCode2019.Puzzles.Day15
{
    public class Day15Part2Puzzle : Day15Puzzle
    {
        public override string GetSolution()
        {
            PathFiller filler = new PathFiller();

            filler.SetMapData(mapData);
            int steps = filler.Fill(target);

            Debug();
            DebugBitmap();

            Console.ReadKey();
            return steps.ToString();
        }
    }
}
