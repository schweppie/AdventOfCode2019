using System;

namespace AdventOfCode2019.Puzzles.Day12
{
    public class Day12Part1Puzzle : Day12Puzzle
    {
        public override string GetSolution()
        {

        int totalEnergy = 0;

            for(int i=0; i<1000; i++)
            {
                Console.WriteLine("After " + i + " steps:");
                foreach(Moon moon in moons)
                {
                    moon.Debug();
                }

                foreach(Moon moon in moons)
                    moon.UpdateVelocity(moons);

                foreach(Moon moon in moons)
                {
                    moon.UpdatePosition();
                }

                Console.WriteLine("");

                totalEnergy = 0;
                foreach(Moon moon in moons)
                    totalEnergy += moon.GetEnergy();
                Console.WriteLine(" energy: " + totalEnergy);

                Console.WriteLine("");
            }



            return totalEnergy.ToString();
        }
    }
}
