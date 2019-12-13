using System;

namespace AdventOfCode2019.Puzzles.Day12
{
    public class Day12Part2Puzzle : Day12Puzzle
    {
        public override string GetSolution()
        {

        long steps = 0;
        bool allDone = false;
        while(true)
        {
            allDone = true;
            foreach(Moon moon in moons)
            {
                moon.UpdateVelocity(moons);
                if (moon.Velocity.X != 0 || moon.Velocity.Y != 0 || moon.Velocity.Z != 0)
                    allDone = false;
            }

            foreach(Moon moon in moons)
            {
                moon.UpdatePosition();
            }


            steps++;
            if(allDone)
                break;

            if(steps%100000000 == 1)
                Console.WriteLine(" steps: " + steps);

        }
            return (steps * 2).ToString();
        }
    }
}
