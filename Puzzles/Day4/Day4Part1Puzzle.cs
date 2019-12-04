using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Puzzles.Day4
{
    public class Day4Part1Puzzle : Day4Puzzle
    {
        protected override bool IsNumberValid(int[] numberToCheck)
        {
            if (!base.IsNumberValid(numberToCheck))
                return false;

            Dictionary<int, int> doubles = new Dictionary<int, int>();
            for (int i=0; i<6; i++)
            {
                int value = numberToCheck[i];

                if (doubles.ContainsKey(value))
                    doubles[value]++;
                else
                    doubles.Add(value, 1);
            }

            return (doubles.Where(n => n.Value >= 2).Count() >= 1);
        }
    }
}
