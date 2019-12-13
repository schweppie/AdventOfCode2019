using System;
using System.Collections.Generic;
using AdventOfCode2019.Core;

namespace AdventOfCode2019.Puzzles.Day13
{
    public class Screen
    {
        private IntVector2 resolution = IntVector2.Min();
        private bool foundResolution = false;

        private Dictionary<IntVector2, Sprite> screen = new Dictionary<IntVector2, Sprite>();

        private void FindResolution()
        {
            foreach(IntVector2 key in screen.Keys)
            {
                if (key.X > resolution.X)
                    resolution.X = key.X;
                if (key.Y > resolution.Y)
                    resolution.Y = key.Y;
            }
        }

        public void SetPixel(IntVector2 pos, Sprite sprite)
        {
            if (screen.ContainsKey(pos))
                screen[pos] = sprite;
            else
                screen.Add(pos, sprite);
        }

        public void Render()
        {
            Console.Clear();
            if (!foundResolution)
                FindResolution();

            IntVector2 plotter = new IntVector2(0,0);
            for(int i=0; i<=resolution.Y; i++)
            {
                for(int j=0; j<=resolution.X; j++)
                {
                    plotter.X = j;
                    plotter.Y = i;

                    if(screen.ContainsKey(plotter))
                    {
                        Sprite sprite = screen[plotter];
                        Console.Write(Day13Puzzle.GetSpriteString(sprite));
                    }
                }

                Console.WriteLine("");
            }
        }
    }
}
