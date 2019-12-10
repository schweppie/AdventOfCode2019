namespace AdventOfCode2019.Puzzles.Day10
{
    public class Day10Part1Puzzle : Day10Puzzle
    {
        public override string GetSolution()
        {
            int visibleAsteroids = int.MinValue;
            for(int i=0; i<asteroids.Count; i++)
            {
                int visible = asteroids[i].GetAsteroidsInSight();
                if(visible > visibleAsteroids)
                    visibleAsteroids = visible;
            }

            return visibleAsteroids.ToString();
        }
    }
}
