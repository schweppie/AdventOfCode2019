using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2019.Puzzles.Day4
{
    public class Day4Part1Puzzle : Day4Puzzle
    {
        int[] number = new int[6];

        int[] multiplyMapping = {100000,10000,1000,100,10,1};



        StreamWriter writetext = new StreamWriter(Directory.GetCurrentDirectory() + "\\PuzzleData\\outputtest.txt");


        public override int GetSolution()
        {
            for (int i=0; i<6; i++)
                number[i] = int.Parse(inputCodes[0].Substring(i, 1));

            int validCodes = 0;

            int numberIndex = 5;
            
            while (GetFullNumber(number) < codeTo)
            {
                if (IsNumberValid(number))
                    validCodes++;

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

        private bool IsNumberValid(int[] numberToCheck)
        {
            // Check ascending
            int lowest = numberToCheck[0];
            for (int i=0; i<6; i++)
            {
                if (numberToCheck[i] < lowest)
                    return false;

                if (numberToCheck[i] > lowest)
                    lowest = numberToCheck[i];
            }


            var set = new HashSet<int>();
            int doublenumber;
            // Check if there is a double
            for (int i=0; i<6; i++)
            {
                doublenumber = numberToCheck[i];
                foreach(var x in numberToCheck)
                {
                    if(x == doublenumber && !set.Add(x)) 
                    {
                        return true;
                    }
                }
            }

            return false;       
        }
    }
}
