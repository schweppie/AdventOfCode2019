using System.Collections.Generic;

namespace AdventOfCode2019.Puzzles.Day12
{
    public abstract class Day12Puzzle : PuzzleBase
    {
        protected override string GetPuzzleData()
        {
            return "/Day12Data.txt";
        }

        protected List<Moon> moons = new List<Moon>();

        public override void Initialize()
        {
            base.Initialize();

            moons.Add(new Moon(1,2,-9));
            moons.Add(new Moon(-1,-9,-4));
            moons.Add(new Moon(17,6,8));
            moons.Add(new Moon(12,4,2));

        }
    }
}
