namespace AdventOfCode2019.Puzzles.Day5
{
    public class Day5Part2Puzzle : Day5Puzzle
    {
        public override int GetSolution()
        {
            intComputer.LoadProgram();
            intComputer.AddInput(5);
            intComputer.Run();
            return intComputer.GetOutput();
        }
    }
}
