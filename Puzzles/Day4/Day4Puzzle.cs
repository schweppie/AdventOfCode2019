using System;
using System.Collections.Generic;
using AdventOfCode2019.Core;

namespace AdventOfCode2019.Puzzles.Day4
{
    public abstract class Day4Puzzle : PuzzleBase
    {
        private string[] inputCodes;
        private int codeTo;

        protected NumberSequence code = new NumberSequence(6,9);

        // Keys.Count is amount of pairs. <index, pairLength>
        private Dictionary<int, int> pairData = new Dictionary<int, int>();
        protected Dictionary<int, int> PairData => pairData;

        protected override string GetPuzzleData()
        {
            return "/Day4Data.txt";
        }

        public override void Initialize()
        {
            base.Initialize();

            inputCodes = lines[0].Split('-');
            codeTo = int.Parse(inputCodes[1]);
        }

        public override string GetSolution()
        {
            for (int i=0; i<6; i++)
                code.SetValue(i,int.Parse(inputCodes[0].Substring(i, 1)));

            int validCodes = 0;

            Console.WriteLine(code.GetFullNumber());
            while (code.GetFullNumber() < codeTo)
            {


                if (IsNumberValid(code.GetSequence()))
                {
                    validCodes++;
                    Console.WriteLine( code.GetFullNumber());
                }

                code.Increase();
            }

            return validCodes.ToString();
        }

        protected virtual bool IsNumberValid(int[] numberToCheck)
        {
            // Check ascending left to right
            int lowest = numberToCheck[0];
            for (int i=0; i<6; i++)
            {
                if (numberToCheck[i] < lowest)
                    return false;

                if (numberToCheck[i] > lowest)
                    lowest = numberToCheck[i];
            }

            return true;
        }

        protected void PopulatePairData(int[] numberToCheck)
        {
            pairData.Clear();
            for(int i=0; i<5; i++)
            {
                int pairLength = GetPairLength(i, numberToCheck);
                if(pairLength == 0)
                    continue;

                pairData.Add(i, pairLength + 1);
                i+=pairLength;
            }
        }

        private int GetPairLength(int index, int[] numberToCheck)
        {
            int neighbours = 0;
            int number = numberToCheck[index];
            for(int i=index+1; i<6; i++)
            {
                if (numberToCheck[i] == number)
                    neighbours++;
            }

            return neighbours;
        }
    }
}
