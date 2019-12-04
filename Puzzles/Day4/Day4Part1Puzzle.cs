using System.Linq;

namespace AdventOfCode2019.Puzzles.Day4
{
    public class Day4Part1Puzzle : Day4Puzzle
    {
        protected override bool IsNumberValid(int[] numberToCheck)
        {
            // Check ascending left to right
            if (!base.IsNumberValid(numberToCheck))
                return false;

            PopulatePairData(numberToCheck);

            return PairData.Where(p => p.Value >= 2).Count() > 0; ;
        }
    }
}
