namespace AdventOfCode2019.Puzzles.Day2
{
    public class Day2Part1Puzzle : Day2Puzzle
    {
        public override string GetSolution()
        {
            intComputer.Load();
            intComputer.OverrideInstruction(1,12);
            intComputer.OverrideInstruction(2,2);
            intComputer.Run();
            return intComputer.GetMemory(0).ToString();
        }
    }
}
