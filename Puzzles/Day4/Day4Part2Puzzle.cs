using System.Collections.Generic;
using System.Linq;
using AdventOfCode2019.Core;

namespace AdventOfCode2019.Puzzles.Day4
{
    public class Day4Part2Puzzle : Day4Puzzle
    {
        protected override bool IsNumberValid(int[] numberToCheck)
        {
            //numberToCheck = new int[] {1,1,1,1,2,2 };

            if (!base.IsNumberValid(numberToCheck))
                return false;

            // Keys.Count is amount of pairs. <index, pairLength>
            Dictionary<int, int> pairData = new Dictionary<int, int>();
            for(int i=0; i<5; i++)
            {
                int pairLength = GetPairLength(i, numberToCheck);
                if(pairLength == 0)
                    continue;

                pairData.Add(i, pairLength + 1);
                i+=pairLength;
            }

            if (pairData.Where(p => p.Value == 2).Count() == 0)
                return false;

            if (pairData.Where(p => Helpers.IsOdd(p.Value)).Count() > 0)
                return false;

            return true;
        }

        private int GetPairLength(int index, int[] numberToCheck)
        {
            int neighbours = 0;
            int number = numberToCheck[index];
            for(int j=index+1; j<6; j++)
            {
                if (numberToCheck[j] == number)
                    neighbours++;
            }

            return neighbours;           
        }
    }
}