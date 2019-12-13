using System;
using System.Collections.Generic;
using AdventOfCode2019.Core;

namespace AdventOfCode2019.Puzzles.Day13
{
    public class Day13Part2Puzzle : Day13Puzzle
    {
        public override string GetSolution()
        {
            computer.Load();
            computer.Run();

            IntVector2 position = new IntVector2(0,0);
            Screen screen = new Screen();
            IntVector2 ballPosition = new IntVector2(0,0);
            IntVector2 paddlePosition = new IntVector2(0,0);
            int joystick = 0;
            int score = 0;
            int blockCount = 0;
            while(true)
            {
                if (!computer.HasOutputs(3))
                {
                    screen.Render();
                    Console.WriteLine("Score " + score );
                    ConsoleKeyInfo info =Console.ReadKey();

                    joystick = 0;
                    if(ballPosition.X < paddlePosition.X)
                        joystick = -1;
                    if(ballPosition.X > paddlePosition.X)
                        joystick = 1;


                    computer.AddInput(joystick);
                    computer.Run();
                }

                position.X = (int)computer.GetOutput();
                position.Y = (int)computer.GetOutput();
                int data = (int)computer.GetOutput();
                Sprite sprite = (Sprite)data;

                if( position.X == -1)
                {
                    score = data;
                    continue;
                }

                if (sprite == Sprite.Ball)
                    ballPosition = position;
                if (sprite == Sprite.Paddle)
                    paddlePosition = position;

                screen.SetPixel(position, sprite);
            }

            return score.ToString();
        }


    }
}
