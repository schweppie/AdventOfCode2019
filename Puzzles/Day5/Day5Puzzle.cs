using AdventOfCode2019.Core.Emulation;

namespace AdventOfCode2019.Puzzles.Day5
{
    public abstract class Day5Puzzle : PuzzleBase
    {
        protected override string GetPuzzleData()
        {
            return "/Day5Data.txt";
        }

        protected IntComputer intComputer;

        public override void Initialize()
        {
            base.Initialize();
            intComputer = new IntComputer(lines);
        }
   }
}
