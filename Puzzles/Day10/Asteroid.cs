using System;
using System.Collections.Generic;
using AdventOfCode2019.Core;

namespace AdventOfCode2019.Puzzles.Day10
{
    public class Asteroid
    {
        private IntVector2 position;
        public IntVector2 Position => position;

        public int X => position.X;
        public int Y => position.Y;

        private Dictionary<double, Asteroid> angleAsteroids = new Dictionary<double, Asteroid>();

        public int GetAsteroidsInSight()
        {
            return angleAsteroids.Keys.Count;
        }

        private const double RAD_TO_DEG = 180 / Math.PI;

        public Asteroid(IntVector2 position)
        {
            this.position = position;
        }

        public void FindNeighbours(List<Asteroid> neighbours)
        {
            foreach (Asteroid asteroid in neighbours)
            {
                if (asteroid == this)
                    continue;

                double angle = Math.Atan2(asteroid.Y - this.Y, asteroid.X - this.X) * RAD_TO_DEG;

                if(angleAsteroids.ContainsKey(angle))
                {
                    Asteroid current = angleAsteroids[angle];
                    if (this.Position.ManhattenDist(current.Position) > this.Position.ManhattenDist(asteroid.Position))
                    {
                        angleAsteroids[angle] = asteroid;
                    }
                }
                else
                {
                    angleAsteroids.Add(angle, asteroid);
                }
            }
        }
    }
}
