namespace AdventOfCode2019.Puzzles.Day10
{
    public class Day10Part1Puzzle : Day10Puzzle
    {
        public override string GetSolution()
        {
            return GetBestAsteroid().GetAsteroidsInSight().ToString();
        }
    }
}
