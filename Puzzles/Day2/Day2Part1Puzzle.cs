using AdventOfCode2019.Core.Emulation;

namespace AdventOfCode2019.Puzzles.Day2
{
    public class Day2Part1Puzzle : Day2Puzzle
    {
        public override int GetSolution()
        {
            intComputer.LoadProgram();
            intComputer.SetOverrideInstruction(1,12);
            intComputer.SetOverrideInstruction(2,2);
            intComputer.Run();
            return intComputer.GetOutput(OutputMode.Address0);
        }
    }
}
