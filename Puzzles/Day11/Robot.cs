using AdventOfCode2019.Core;
using AdventOfCode2019.Core.Emulation;

namespace AdventOfCode2019.Puzzles.Day11
{
    public class Robot
    {
        private IntComputer computer;
        private Direction direction;
        public Direction Direction => direction;

        private IntVector2 position;
        public IntVector2 Position => position;

        public Robot(int x, int y, string[] program)
        {
            direction = Direction.Up;
            position = new IntVector2(x, y);
            computer = new IntComputer(program);
            computer.Load();
        }

        public void AddComputerInput(int input)
        {
            computer.AddInput(input);
        }

        public void RunComputer()
        {
            computer.Run();
        }

        public bool IsFinished()
        {
            return computer.HasOutputs() == false;
        }

        public void Move()
        {
            position.X += direction == Direction.Right ? 1 : 0;
            position.X -= direction == Direction.Left ? 1 : 0;
            position.Y -= direction == Direction.Up ? 1 : 0;
            position.Y += direction == Direction.Down ? 1 : 0;
        }

        public int GetColorToPaint()
        {
            return (int)computer.GetOutput();
        }

        public void UpdateDirectionDirection()
        {
            int intDir = (int)direction;

            if ((int)computer.GetOutput() == 1)
            {
                intDir++;
                if (intDir == 4)
                    intDir = 0;
            }
            else
            {
                intDir--;
                if (intDir == -1)
                    intDir = 3;
            }

            direction = (Direction)intDir;
        }
    }
}
