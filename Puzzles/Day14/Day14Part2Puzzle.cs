using System;

namespace AdventOfCode2019.Puzzles.Day14
{
    public class Day14Part2Puzzle : Day14Puzzle
    {
        public override string GetSolution()
        {
            Chemical ore = availableChemicals["ORE"];
            Chemical fuel = availableChemicals["FUEL"];

            long fuelAmount = 0;
            while (true)
            {
                fuel.Produce(1);

                if (ore.AvailableAmount > 1000000000000)
                    break;

                fuelAmount++;
            }

            return fuelAmount.ToString();
        }
    }
}
