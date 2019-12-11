namespace AdventOfCode2019.Puzzles.Day11
{
    public class Day11Part2Puzzle : Day11Puzzle
    {
        public override string GetSolution()
        {
            bool firstRun = true;

            while(true)
            {
                robot.Move();

                if (firstRun)
                {
                    robot.AddComputerInput(1);
                    firstRun = false;
                }
                else
                    robot.AddComputerInput(panelGrid[robot.Position.X, robot.Position.Y]);

                robot.RunComputer();

                CheckBounds();

                if(robot.IsFinished())
                    break;

                int color = robot.GetColorToPaint();
                robot.UpdateDirectionDirection();

                panelGrid[robot.Position.X, robot.Position.Y] = color;
                isPaintedGrid[robot.Position.X, robot.Position.Y] = true;
            }

            DrawGrid();

            return "";

        }
    }
}
