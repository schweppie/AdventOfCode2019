using System;
using AdventOfCode2019.Core.Emulation;

namespace AdventOfCode2019.Puzzles.Day7
{
    public abstract class Day7Puzzle : PuzzleBase
    {
        protected override string GetPuzzleData()
        {
            return "/Day7Data.txt";
        }

        protected IntComputer[] amps;

        public override void Initialize()
        {
            base.Initialize();

            amps = new IntComputer[5];
            for(int i=0; i<amps.Length; i++)
                amps[i] = new IntComputer(lines);
        }
    }
}
