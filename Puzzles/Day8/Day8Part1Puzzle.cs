using System;
using System.Linq;

namespace AdventOfCode2019.Puzzles.Day8
{
    public class Day8Part1Puzzle : Day8Puzzle
    {
        public override int GetSolution()
        {
            Layer layer = layers.First();

            int pixelCount = int.MaxValue;
            for(int i=0; i<layers.Count ;i++)
            {
                int count = layers[i].GetPixelCount(0);
                if(count < pixelCount)
                {
                    pixelCount = count;
                    layer = layers[i];
                }
            }

            return layer.GetPixelCount(1) * layer.GetPixelCount(2);
        }
    }
}
