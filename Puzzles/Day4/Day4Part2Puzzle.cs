using System.Linq;

namespace AdventOfCode2019.Puzzles.Day4
{
    public class Day4Part2Puzzle : Day4Puzzle
    {
        protected override bool IsNumberValid(int[] numberToCheck)
        {
            // Check ascending left to right
            if (!base.IsNumberValid(numberToCheck))
                return false;

            PopulatePairData(numberToCheck);

            bool groupOfTwoExists = PairData.Where(p => p.Value == 2).Count() > 0;
            bool bigGroupExists = PairData.Where(p => p.Value > 2).Count() > 0;

            if(bigGroupExists && !groupOfTwoExists)
                return false;

            if(!groupOfTwoExists)
                return false;

            return true;
        }
    }
}
