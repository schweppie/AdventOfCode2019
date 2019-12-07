using AdventOfCode2019.Core;

namespace AdventOfCode2019.Puzzles.Day7
{
    public class Day7Part1Puzzle : Day7Puzzle
    {
        public override int GetSolution()
        {
            int output = 0;

            NumberSequence phaseSetting = new NumberSequence(5,4);

            while(true)
            {
                if(phaseSetting.IsUnique())
                {
                    int ampOutput = 0;
                    for(int i=0; i<amps.Length; i++)
                    {
                        amps[i].LoadProgram();
                        ampOutput = amps[i].GetProgramOutput(new int[] {phaseSetting.GetSequence()[i], ampOutput});
                    }

                    if(ampOutput > output)
                        output = ampOutput;
                }

                if(!phaseSetting.Increase())
                    break;
            }

            return output;
        }
    }
}