using System;
using System.Linq;

namespace AdventOfCode2019.Puzzles.Day2
{
    public abstract class Day2Puzzle : PuzzleBase
    {
        protected const int OPCODE_TERMINATE = 99;
        protected const int OPCODE_ADD = 1;
        protected const int OPCODE_MULTIPLY = 2;
        protected const int ERROR_CODE = -1;

        protected override string GetPuzzleData()
        {
            return "/Day2Data.txt";
        }

        protected int[] GetProgramData()
        {
            string[] programInput = lines[0].Split(',');
            int[] programData = new int[programInput.Length];

            for(int i=0; i< programInput.Length; i++)
                programData[i] = int.Parse(programInput[i]);

            return programData;
        }
   }
}
