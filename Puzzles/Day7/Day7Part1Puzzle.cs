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
                        amps[i].AddInput(phaseSetting.GetSequence()[i]);
                        amps[i].AddInput(ampOutput);
                        amps[i].Run();
                        ampOutput = amps[i].GetOutput();
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