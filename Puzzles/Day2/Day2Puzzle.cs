using AdventOfCode2019.Core.IntProgram;

namespace AdventOfCode2019.Puzzles.Day2
{
    public abstract class Day2Puzzle : PuzzleBase
    {
        protected override string GetPuzzleData()
        {
            return "/Day2Data.txt";
        }

        protected IntComputer intComputer;

        public override void Initialize()
        {
            base.Initialize();
            intComputer = new IntComputer(lines);
        }
   }
}
