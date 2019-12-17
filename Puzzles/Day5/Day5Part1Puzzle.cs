using System;

namespace AdventOfCode2019.Puzzles.Day5
{
    public class Day5Part1Puzzle : Day5Puzzle
    {
        public override string GetSolution()
        {
            intComputer.Load();
            intComputer.AddInput(1);
            intComputer.Run();
            return intComputer.GetOutput(intComputer.OutputCount()-1).ToString();
        }
    }
}
