namespace AdventOfCode2019.Puzzles.Day6
{
    public class Day6Part1Puzzle : Day6Puzzle
    {
        public override string GetSolution()
        {
            int totalOrbits = 0;
            foreach (var pair in orbits)
                totalOrbits += pair.Value.Parents;

            return totalOrbits.ToString();
        }
    }
}