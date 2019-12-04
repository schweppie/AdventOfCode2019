namespace AdventOfCode2019.Puzzles.Day1
{
    public class Day1Part2Puzzle : Day1Puzzle
    {
        public override int GetSolution()
        {
            int mass = 0;

            for (int i = 0; i < lines.Length; i++)
                mass += CalculateFuel(int.Parse(lines[i]));;

            return mass;
        }

        private int CalculateFuel(int mass)
        {
            int fuel = GetFuelRequiredForMass(mass);
            if(fuel >= 0)
                return fuel + CalculateFuel(fuel);
            return 0;
        }
    }
}
