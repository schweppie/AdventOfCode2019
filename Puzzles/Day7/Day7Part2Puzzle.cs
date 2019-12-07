using AdventOfCode2019.Core;

namespace AdventOfCode2019.Puzzles.Day7
{
    public class Day7Part2Puzzle : Day7Puzzle
    {
        public override int GetSolution()
        {
            int output = 0;

            NumberSequence phaseSetting = new NumberSequence(5,9);

            for(int i=0; i<amps.Length; i++)
            {
                amps[i].LoadProgram();
            }

            int[] setting = {9,8,7,6,5};

            while(true)
            {
                int ampOutput =0;

                if(phaseSetting.IsUnique())
                {
                    for(int i=0; i<amps.Length; i++)
                    {
                        ampOutput = amps[i].GetProgramOutput(new int[] {setting[i], ampOutput});
                    }

                    if(ampOutput > output)
                        output = ampOutput;
                }

                if(!amps[4].Running)
                    break;
            }

            return output;
        }
    }
}