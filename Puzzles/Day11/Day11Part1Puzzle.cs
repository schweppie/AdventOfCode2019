using System;

namespace AdventOfCode2019.Puzzles.Day11
{
    public class Day11Part1Puzzle : Day11Puzzle
    {

        public override string GetSolution()
        {
            while(true)
            {
                robot.Move();
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

            int paintedPanels = 0;
            for (int i=0; i<WIDTH; i++)
            {
                for (int j=0; j<WIDTH; j++)
                {
                    if(isPaintedGrid[i,j])
                        paintedPanels++;
                }
            }
            return paintedPanels.ToString();

        }
    }
}
