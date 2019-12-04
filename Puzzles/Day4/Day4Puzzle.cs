namespace AdventOfCode2019.Puzzles.Day4
{
    public abstract class Day4Puzzle : PuzzleBase
    {
        protected string[] inputCodes;
        protected int codeFrom;
        protected int codeTo;

        protected override string GetPuzzleData()
        {
            return "/Day4Data.txt";
        }    

        public override void Initialize()
        {
            base.Initialize();
            inputCodes = lines[0].Split('-');
            codeFrom = int.Parse(inputCodes[0]);
            codeTo = int.Parse(inputCodes[1]);
        }
    }
}
