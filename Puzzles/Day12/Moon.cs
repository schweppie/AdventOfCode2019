using System;
using System.Collections.Generic;
using AdventOfCode2019.Core;

namespace AdventOfCode2019.Puzzles.Day12
{
    public class Moon
    {
        private IntVector3 position;
        public IntVector3 Position => position;

        private IntVector3 startPosition;

        private IntVector3 velocity;
        public IntVector3 Velocity => velocity;

        public Moon(int x, int y, int z)
        {
            position = new IntVector3(x,y,z);
            startPosition = new IntVector3(x,y,z);
            velocity = new IntVector3(0,0,0);
        }

        public bool IsAtOrigin()
        {
            return position == startPosition;
        }

        public void Debug()
        {
            Console.WriteLine("pos=<x=" + position.X + ", y=" + position.Y + ", z=" + position.Z + ">, vel=<x=" + velocity.X + ", y=" + velocity.Y + ", z= " + velocity.Z);
        }

        public void UpdateVelocity(List<Moon> otherMoons)
        {
            foreach(Moon moon in otherMoons)
            {
                if (moon == this)
                    continue;

                int xDelta = position.X - moon.Position.X;
                if(xDelta > 0)
                    velocity.X--;
                if(xDelta < 0)
                    velocity.X++;

                int yDelta = position.Y - moon.Position.Y;
                if(yDelta > 0)
                    velocity.Y--;
                if(yDelta < 0)
                    velocity.Y++;

                int zDelta = position.Z - moon.Position.Z;
                if(zDelta > 0)
                    velocity.Z--;
                if(zDelta < 0)
                    velocity.Z++;
            }
        }

        public void UpdatePosition()
        {
            position += velocity;
        }

        public int GetEnergy()
        {
            int potentialEnergy = 0;
            potentialEnergy += Math.Abs(position.X);
            potentialEnergy += Math.Abs(position.Y);
            potentialEnergy += Math.Abs(position.Z);

            int kineticEnergy = 0;
            kineticEnergy += Math.Abs(velocity.X);
            kineticEnergy += Math.Abs(velocity.Y);
            kineticEnergy += Math.Abs(velocity.Z);

            return potentialEnergy * kineticEnergy;
        }
    }
}
