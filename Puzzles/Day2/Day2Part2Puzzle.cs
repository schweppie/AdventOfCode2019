using AdventOfCode2019.Core.Emulation;

namespace AdventOfCode2019.Puzzles.Day2
{
    public class Day2Part2Puzzle : Day2Puzzle
    {
        private const int TARGET_OUTPUT = 19690720;

        public override int GetSolution()
        {
            int programOutput;
            for(int noun=0; noun < 100; noun++)
            {
                for(int verb=0; verb < 100; verb++)
                {
                    intComputer.LoadProgram();
                    intComputer.SetOverrideInstruction(1,noun);
                    intComputer.SetOverrideInstruction(2,verb);
                    intComputer.Run();
                    programOutput = intComputer.GetOutput(OutputMode.Address0);

                    if(programOutput == TARGET_OUTPUT)
                        return 100 * noun + verb;
                }
            }

            return ERROR;
        }
    }
}
