using System;
using System.Collections.Generic;
using AdventOfCode2019.Core;

namespace AdventOfCode2019.Puzzles.Day8
{
    public abstract class Day8Puzzle : PuzzleBase
    {
        protected override string GetPuzzleData()
        {
            return "/Day8Data.txt";
        }

        protected readonly IntVector2 dimensions = new IntVector2(25,6);

        protected List<Layer> layers = new List<Layer>();

        public override void Initialize()
        {
            base.Initialize();

            int length = dimensions.X * dimensions.Y;

            for(int i=0; i<lines[0].Length; i+=length)
            {
                Layer layer = new Layer(dimensions);

                for(int j=0; j<length; j++)
                {
                    int pixel = int.Parse(lines[0].Substring(i+j,1));
                    layer.AddPixel(pixel);
                }

                layers.Add(layer);
            }
        }
    }
}
