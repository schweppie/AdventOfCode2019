namespace AdventOfCode2019.Puzzles.Day5
{
    public class Day5Part1Puzzle : Day5Puzzle
    {
        public override int GetSolution()
        {
            intComputer.LoadProgram();
            intComputer.AddInput(1);
            intComputer.Run();
            return intComputer.GetOutput();
        }
    }
}
