using AdventOfCode2019.Core;

namespace AdventOfCode2019.Puzzles.Day3
{
    public class Day3Part2Puzzle : Day3Puzzle
    {
        protected override int HandleIntersection(IntVector2 intersection) 
        {
            int steps = 0;
            foreach(var wire in wires)
                steps += wire.Path.IndexOf(intersection);

            return steps;
        }
    }
}
