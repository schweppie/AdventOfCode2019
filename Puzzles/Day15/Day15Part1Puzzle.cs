using System.Collections.Generic;
using System.Linq;
using AdventOfCode2019.Core;

namespace AdventOfCode2019.Puzzles.Day15
{
    public class Day15Part1Puzzle : Day15Puzzle
    {
        public override string GetSolution()
        {
            List<IntVector2> path = pathFinder.GetPath(origin, target);

            // For debugging
            foreach( var node in path)
                mapData[node] = 2;

            Debug();
            DebugBitmap();

            return path.Count().ToString();
        }
    }
}
