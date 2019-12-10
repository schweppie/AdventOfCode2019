using AdventOfCode2019.Core;

namespace AdventOfCode2019.Puzzles.Day10
{
    public class Day10Part2Puzzle : Day10Puzzle
    {
        public override string GetSolution()
        {
            Asteroid asteroid;
            GetMostVisibleAsteroids(out asteroid);

            IntVector2 position = new IntVector2(0,0);
            for(int i=0;i<200;i++)
                asteroid.VaporizeNextAsteroid(out position);

            return ((position.X * 100) + position.Y).ToString();
        }
    }
}
