using System.IO;

namespace AdventOfCode2019.Puzzles
{
    public abstract class PuzzleBase
    {
        protected string[] lines;

        protected const string NO_SOLUTION = "No solution :(!";
        protected const int ERROR = -1;

        public virtual void Initialize()
        {
            lines = File.ReadAllLines(GetPuzzlesDataPath());
        }

        protected string GetPuzzlesDataPath()
        {
            return Directory.GetCurrentDirectory() + "\\PuzzleData\\" + GetPuzzleData();
        }

        protected abstract string GetPuzzleData();

        public abstract int GetSolution();
    }
}
