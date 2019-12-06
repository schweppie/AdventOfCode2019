namespace AdventOfCode2019.Puzzles.Day2
{
    public class Day2Part1Puzzle : Day2Puzzle
    {
        public override int GetSolution()
        {
            intComputer.LoadProgram();
            intComputer.SetOverrideInstruction(1,12);
            intComputer.SetOverrideInstruction(2,2);
            return intComputer.GetProgramOutput();
        }
    }
}
