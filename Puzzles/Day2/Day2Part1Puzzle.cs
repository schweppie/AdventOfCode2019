namespace AdventOfCode2019.Puzzles.Day2
{
    public class Day2Part1Puzzle : Day2Puzzle
    {
        public override int GetSolution()
        {
            int[] programData = GetProgramData();

            programData[1] = 12;
            programData[2] = 2;

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
                    return ERROR_CODE;

                programData[programData[i+3]] = output;
            }

            return programData[0]; 
        }
    }
}
