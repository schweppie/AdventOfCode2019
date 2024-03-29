using System;

namespace AdventOfCode2019.Puzzles.Day9
{
    public class Day9Part1Puzzle : Day9Puzzle
    {
        public override string GetSolution()
        {
            intComputer = new Core.Emulation.IntComputer(lines);
            intComputer.Load();
            intComputer.AddInput(1);
            intComputer.Run();
            return intComputer.GetOutput().ToString();
        }
    }
}
