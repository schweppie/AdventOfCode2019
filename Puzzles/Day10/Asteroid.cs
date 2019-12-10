using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2019.Core;

namespace AdventOfCode2019.Puzzles.Day10
{
    public class Asteroid
    {
        private IntVector2 position;
        public IntVector2 Position => position;

        public int X => position.X;
        public int Y => position.Y;

        private Dictionary<double, List<Asteroid>> angleAsteroids = new Dictionary<double, List<Asteroid>>();

        private int vaporizeIndex = 0;

        public int GetAsteroidsInSight()
        {
            return angleAsteroids.Keys.Count;
        }

        private const double RAD_TO_DEG = 180 / Math.PI;

        public Asteroid(IntVector2 position)
        {
            this.position = position;
        }

        public bool VaporizeNextAsteroid(out IntVector2 position)
        {
            position = new IntVector2(0,0);

            if(angleAsteroids.Keys.Count == 0)
                return false;

            List<Asteroid> asteroids = angleAsteroids.Values.ElementAt(vaporizeIndex);
            if(asteroids.Count == 0)
            {
                IncreaseVaporizeIndex();
                return false;
            }

            position = asteroids.First().Position;
            asteroids.RemoveAt(0);

            IncreaseVaporizeIndex();
            return true;
        }

        private void IncreaseVaporizeIndex()
        {
            vaporizeIndex++;
            if(vaporizeIndex == angleAsteroids.Keys.Count)
                vaporizeIndex = 0;
        }

        public void FindNeighbours(List<Asteroid> neighbours)
        {
            foreach (Asteroid asteroid in neighbours)
            {
                if (asteroid == this)
                    continue;

                double angle = Math.Atan2(asteroid.Y - this.Y, asteroid.X - this.X) * RAD_TO_DEG;

                if(!angleAsteroids.ContainsKey(angle))
                    angleAsteroids.Add(angle, new List<Asteroid>());

                angleAsteroids[angle].Add(asteroid);
                angleAsteroids[angle] = angleAsteroids[angle].OrderBy(x => x.Position.ManhattenDist(this.Position)).ToList();
            }

            angleAsteroids = angleAsteroids.OrderBy(x => x.Key).ToDictionary((keyItem) => keyItem.Key, (valueItem) => valueItem.Value);
            vaporizeIndex = angleAsteroids.IndexOfKey(-90);
        }
    }
}
