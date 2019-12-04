using System;
using System.Collections.Generic;

namespace AdventOfCode2019.Puzzles.Day4
{
    public abstract class Day4Puzzle : PuzzleBase
    {
        private string[] inputCodes;
        private int codeTo;

        protected int[] number = new int[6];
        private int[] multiplyMapping = {100000,10000,1000,100,10,1};

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

        public override int GetSolution()
        {
            for (int i=0; i<6; i++)
                number[i] = int.Parse(inputCodes[0].Substring(i, 1));

            int validCodes = 0;
            int numberIndex = 5;

            while (GetFullNumber(number) < codeTo)
            {
                if (IsNumberValid(number))
                {
                    validCodes++;
                    Console.WriteLine( GetFullNumber(number));
                }

                number[numberIndex]++;
                if (number[numberIndex] == 10)
                {
                    for (int i=numberIndex; i<6; i++)
                        number[i] = 0;

                    int index = numberIndex - 1;
                    while (index >= 0)
                    {
                        number[index]++;

                        if (number[index] == 10)
                        {
                            number[index] = 0;
                            index--;
                        }
                        else
                            break;
                    }
                    numberIndex = 5;
                }
            }

            return validCodes;
        }

        private int GetFullNumber(int[] number)
        {
            int fullNumber = 0;
            for (int i=0; i<6; i++)
                fullNumber += number[i] * multiplyMapping[i];

            return fullNumber;
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
