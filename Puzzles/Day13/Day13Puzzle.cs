using AdventOfCode2019.Core.Emulation;

namespace AdventOfCode2019.Puzzles.Day13
{
    public abstract class Day13Puzzle : PuzzleBase
    {
        protected override string GetPuzzleData()
        {
            return "/Day13Data.txt";
        }

        protected IntComputer computer;

        public override void Initialize()
        {
            base.Initialize();
            computer = new IntComputer(lines);
        }

        public enum Sprite
        {
            Empty = 0,
            Wall = 1,
            Block = 2,
            Paddle = 3,
            Ball = 4,
        }

        protected string GetSpriteString(Sprite sprite)
        {
            switch(sprite)
            {
                case Sprite.Empty:
                    return " ";
                case Sprite.Wall:
                    return "=";
                case Sprite.Block:
                    return "#";
                case Sprite.Paddle:
                    return "_";
                case Sprite.Ball:
                    return "*";
            }
            return " ";
        }
    }
}
