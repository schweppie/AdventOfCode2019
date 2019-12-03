using System;
using AdventOfCode2019.Core;

namespace AdventOfCode2019.Puzzles.Day3
{
    public class Day3Part1Puzzle : Day3Puzzle
    {
        protected override int HandleIntersection(IntVector2 intersection) 
        {
            return Math.Abs(intersection.X) + Math.Abs(intersection.Y);
        }
    }
}
