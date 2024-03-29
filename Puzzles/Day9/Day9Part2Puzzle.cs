using System;

namespace AdventOfCode2019.Puzzles.Day9
{
    public class Day9Part2Puzzle : Day9Puzzle
    {
        public override string GetSolution()
        {
            intComputer = new Core.Emulation.IntComputer(lines);
            intComputer.Load();
            intComputer.AddInput(2);
            intComputer.Run();
            return intComputer.GetOutput().ToString();
        }
    }
}
