using AdventOfCode2019.Core;

namespace AdventOfCode2019.Puzzles.Day7
{
    public class Day7Part2Puzzle : Day7Puzzle
    {
        public override int GetSolution()
        {
            int output = 0;

            NumberSequence phaseSetting = new NumberSequence(5,9,5);

            while(true)
            {
                if(!phaseSetting.Increase())
                    break;

                if(!phaseSetting.IsUnique())
                    continue;

                for(int i=0; i<amps.Length; i++)
                {
                    amps[i].Load();
                    amps[i].AddInput(phaseSetting[i]);
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

                if(ampOutput > output)
                    output = ampOutput;
            }

            return output;
        }
    }
}
