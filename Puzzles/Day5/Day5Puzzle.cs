namespace AdventOfCode2019.Puzzles.Day5
{
    public abstract class Day5Puzzle : PuzzleBase
    {


        protected override string GetPuzzleData()
        {
            return "/Day5Data.txt";
        }

        private int[] GetProgramData()
        {
            string[] programInput = lines[0].Split(',');
            int[] programData = new int[programInput.Length];

            for(int i=0; i< programInput.Length; i++)
                programData[i] = int.Parse(programInput[i]);

            return programData;
        }

        protected int GetProgramOutput(int input)
        {
            int[] programData = GetProgramData();


            //programData = new int[] { 3,0,4,0,99};

            int output = -1;
            int xInput;
            int yInput;

            for(int i=0; i<programData.Length; i+=4)
            {
                int opcode = programData[i];

                if(opcode == (int)Opcodes.OPCODE_TERMINATE)
                    break;

                switch((Opcodes)opcode)
                {
                    case Opcodes.OPCODE_ADD:
                        xInput = programData[programData[i+1]];
                        yInput = programData[programData[i+2]];
                        output = xInput + yInput;
                        programData[programData[i+3]] = output;
                        break;
                    case Opcodes.OPCODE_MULTIPLY:
                        xInput = programData[programData[i+1]];
                        yInput = programData[programData[i+2]];
                        output = xInput * yInput;
                        programData[programData[i+3]] = output;
                        break;
                    case Opcodes.OPCODE_SINGLE:
                        programData[programData[i+1]] = input;
                        i-=2;
                        break;
                    case Opcodes.OPCODE_OUTPUT:
                        output = programData[programData[i+1]];
                        i-=2;
                        break;
                }
            }

            return output;
        }
   }
}
