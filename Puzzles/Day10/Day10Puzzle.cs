using System.Collections.Generic;
using AdventOfCode2019.Core;

namespace AdventOfCode2019.Puzzles.Day10
{
    public abstract class Day10Puzzle : PuzzleBase
    {
        protected override string GetPuzzleData()
        {
            return "/Day10Data.txt";
        }

        protected IntVector2 dimensions;

        protected List<Asteroid> asteroids = new List<Asteroid>();

        public override void Initialize()
        {
            base.Initialize();

            dimensions = new IntVector2(lines[0].Length, lines.Length);

            for(int i=0; i< dimensions.Y; i++)
            {
                for(int j=0; j < dimensions.X; j++)
                {
                    bool isAsteroid = lines[i].Substring(j,1) == "#";
                    if(!isAsteroid)
                        continue;

                    IntVector2 position = new IntVector2(j, i);
                    Asteroid asteroid = new Asteroid(position);
                    asteroids.Add(asteroid);
                }
            }

            foreach(Asteroid asteroid in asteroids)
                asteroid.FindNeighbours(asteroids);
        }

        protected Asteroid GetBestAsteroid()
        {
            int visibleAsteroids = int.MinValue;
            Asteroid asteroid = null;
            for(int i=0; i<asteroids.Count; i++)
            {
                int visible = asteroids[i].GetAsteroidsInSight();
                if(visible > visibleAsteroids)
                {
                    asteroid = asteroids[i];
                    visibleAsteroids = visible;
                }
            }

            return asteroid;
        }
    }
}
