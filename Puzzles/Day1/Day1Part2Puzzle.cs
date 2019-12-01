namespace AdventOfCode2019.Puzzles.Day1
{
    public class Day1Part2Puzzle : Day1Puzzle
    {
        int totalFuel = 0;

        public override int GetSolution()
        {
            int mass = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                totalFuel = 0;
                CalculateFuel(int.Parse(lines[i]));
                mass += totalFuel;
            }

            return mass; 
        }

        private int CalculateFuel(int mass)
        {
            int fuel = GetFuelRequiredForMass(mass);
            if(fuel > 0)
            {
                totalFuel += fuel;
                return CalculateFuel(fuel);
            }

            return fuel;
        }
    }
}
