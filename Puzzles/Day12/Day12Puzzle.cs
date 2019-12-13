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
// Puzzle data
            moons.Add(new Moon(1,2,-9));
            moons.Add(new Moon(-1,-9,-4));
            moons.Add(new Moon(17,6,8));
            moons.Add(new Moon(12,4,2));

/*

            moons.Add(new Moon(-1,0,2));

            moons.Add(new Moon(2,-10,-7));

            moons.Add(new Moon(4,-8, 8));

            moons.Add(new Moon(3,5,-1));*/

        }
    }
}
