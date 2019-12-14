namespace AdventOfCode2019.Puzzles.Day14
{
    public class Day14Part1Puzzle : Day14Puzzle
    {
        public override string GetSolution()
        {
            Chemical chemical = availableChemicals["FUEL"];
            chemical.Produce(1);

            return availableChemicals["ORE"].AvailableAmount.ToString();
        }
    }
}
