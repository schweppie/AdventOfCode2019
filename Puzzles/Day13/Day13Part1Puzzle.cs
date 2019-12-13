using System;
using System.Collections.Generic;
using AdventOfCode2019.Core;

namespace AdventOfCode2019.Puzzles.Day13
{
    public class Day13Part1Puzzle : Day13Puzzle
    {
        public override string GetSolution()
        {
            computer.Load();
            computer.Run();

            Dictionary<IntVector2, Sprite> screen = new Dictionary<IntVector2, Sprite>();
            IntVector2 position = new IntVector2(0,0);

            while(true)
            {
                if (!computer.HasOutputs(3))
                    break;

                position.X = (int)computer.GetOutput();
                position.Y = (int)computer.GetOutput();
                Sprite sprite = (Sprite)computer.GetOutput();

                if (screen.ContainsKey(position))
                    screen[position] = sprite;
                else
                    screen.Add(position, sprite);
            }

            IntVector2 resolution = IntVector2.Min();
            foreach(IntVector2 key in screen.Keys)
            {
                if (key.X > resolution.X)
                    resolution.X = key.X;
                if (key.Y > resolution.Y)
                    resolution.Y = key.Y;
            }

            IntVector2 plotter = new IntVector2(0,0);
            int blockTiles = 0;
            for(int i=0; i<=resolution.Y; i++)
            {
                for(int j=0; j<=resolution.X; j++)
                {
                    plotter.X = j;
                    plotter.Y = i;

                    if(screen.ContainsKey(plotter))
                    {
                        Sprite sprite = screen[plotter];
                        Console.Write(GetSpriteString(sprite));

                        if (sprite == Sprite.Block)
                            blockTiles++;
                    }
                }

                Console.WriteLine("");
            }

            return blockTiles.ToString();;
        }
    }
}
