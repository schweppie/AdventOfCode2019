using System;

namespace AdventOfCode2019.Puzzles.Day1
{
    public abstract class Day1Puzzle : PuzzleBase
    {
        protected override string GetPuzzleData()
        {
            return "/Day1Data.txt";
        }

        protected int GetFuelRequiredForMass(int mass)
        {
            return (int)Math.Floor((float)(mass / 3)) - 2;;
        }
    }
}
