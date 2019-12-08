using System;
using AdventOfCode2019.Core;

namespace AdventOfCode2019.Puzzles.Day8
{
    public class Layer
    {
        private int[] pixels;
        private int pointer = 0;

        private IntVector2 dimensions;
        private int length;

        public Layer(IntVector2 dimensions)
        {
            this.dimensions = dimensions;
            length = dimensions.X * dimensions.Y;
            pixels = new int[length];
        }

        public void AddPixel(int pixel)
        {
            pixels[pointer] = pixel;
            pointer++;
        }

        public void Debug()
        {
            int index = 0;
            for(int i=0; i<dimensions.Y; i++)
            {
                for(int j=0; j<dimensions.X; j++)
                {
                    int data = pixels[index];
                    Console.Write(pixels[index]);
                    index++;
                }
                Console.WriteLine();
            }
        }

        public void Visualize()
        {
            int index = 0;
            for(int i=0; i<dimensions.Y; i++)
            {
                for(int j=0; j<dimensions.X; j++)
                {
                    int data = pixels[index];
                    if(data!=0)
                        Console.Write("*");
                    else
                        Console.Write(" ");
                    index++;
                }
                Console.WriteLine();
            }
        }

        public int GetPixelCount(int pixel)
        {
            int count=0;
            for(int i=0; i<length; i++)
            {
                if(pixels[i] == pixel)
                    count++;
            }

            return count;
        }

        public int GetPixelAt(int index)
        {
            return pixels[index];
        }
    }
}
