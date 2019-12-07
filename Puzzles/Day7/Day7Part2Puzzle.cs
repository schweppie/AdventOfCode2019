using AdventOfCode2019.Core;

namespace AdventOfCode2019.Puzzles.Day7
{
    public class Day7Part2Puzzle : Day7Puzzle
    {
        public override int GetSolution()
        {
            int output = 0;

            NumberSequence phaseSetting = new NumberSequence(5,9);


            int[] setting = {9,8,7,6,5};

            for(int i=0; i<amps.Length; i++)
            {
                amps[i].LoadProgram();
                amps[i].AddInput(setting[i]);
            }

            int ampOutput=0;

            while(true)
            {

                for(int i=0; i<amps.Length; i++)
                {
                    amps[i].AddInput(ampOutput);
                    amps[i].Run();
                    ampOutput = amps[i].GetOutput();
                }

                if(!amps[4].Running)
                    break;
            }

            output = ampOutput;

            return output;
        }
    }
}
