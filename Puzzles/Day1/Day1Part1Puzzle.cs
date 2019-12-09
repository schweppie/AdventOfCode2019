namespace AdventOfCode2019.Puzzles.Day1
{
    public class Day1Part1Puzzle : Day1Puzzle
    {
        public override string GetSolution()
        {
            int mass = 0;

            for (int i = 0; i < lines.Length; i++)
                mass += GetFuelRequiredForMass(int.Parse(lines[i]));

            return mass.ToString();
        }
    }
}
