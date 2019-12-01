using System;

namespace AdventOfCode2019.Puzzles.Day1
{
    public class Day1Part1Puzzle : Day1Puzzle
    {
        public override string GetSolution()
        {
            int mass = 0;

            for (int i = 0; i < lines.Length; i++)
                mass += (int)Math.Floor((float)(int.Parse(lines[i]) / 3)) - 2;

            return mass.ToString();      
        }
    }
}