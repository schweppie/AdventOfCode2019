namespace AdventOfCode2019.Puzzles.Day2
{
    public abstract class Day2Puzzle : PuzzleBase
    {
        protected const int OPCODE_TERMINATE = 99;
        protected const int OPCODE_ADD = 1;
        protected const int OPCODE_MULTIPLY = 2;
        protected const int ERROR = -1;

        protected override string GetPuzzleData()
        {
            return "/Day2Data.txt";
        }

        private int[] GetProgramData()
        {
            string[] programInput = lines[0].Split(',');
            int[] programData = new int[programInput.Length];

            for(int i=0; i< programInput.Length; i++)
                programData[i] = int.Parse(programInput[i]);

            return programData;
        }

        protected int GetProgramOutput(int noun, int verb)
        {
            int[] programData = GetProgramData();

            programData[1] = noun;
            programData[2] = verb;

            for(int i=0; i<programData.Length; i+=4)
            {
                int opcode = programData[i];
                if(opcode == OPCODE_TERMINATE)
                    break;

                int xInput = programData[programData[i+1]];
                int yInput = programData[programData[i+2]];
                int output = -1;

                if(opcode == OPCODE_ADD)
                    output = xInput + yInput;
                else if( opcode == OPCODE_MULTIPLY)
                    output = xInput * yInput;
                else
                    return ERROR;

                programData[programData[i+3]] = output;
            }

            return programData[0];
        }
   }
}
