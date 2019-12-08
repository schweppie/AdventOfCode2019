namespace AdventOfCode2019.Puzzles.Day8
{
    public class Day8Part2Puzzle : Day8Puzzle
    {
        public override int GetSolution()
        {
            int length = dimensions.X * dimensions.Y;

            Layer finalLayer = new Layer(dimensions);

            for(int i=0; i<length; i++)
            {
                int finalPixel = 0;
                foreach(Layer layer in layers)
                {
                    int pixel = layer.GetPixelAt(i);

                    if(pixel != 2)
                    {
                        finalPixel = pixel;;
                        break;
                    }
                }
                finalLayer.AddPixel(finalPixel);
            }

            finalLayer.Visualize();
            return 0;
        }
    }
}
