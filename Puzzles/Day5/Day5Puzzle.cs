using System;

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

        protected int GetProgramOutput(int noun, int verb, int input)
        {
            int[] programData = GetProgramData();

            programData[1] = noun;
            programData[2] = verb;

            int output = -1;
            //programData = new int[] { 1101,100,-1,4,4,4};

            for(int i=0; i<programData.Length; i+=4)
            {
                int opcode = programData[i] % 100;

	            Mode parameterMode1 = (programData[i]/100%10) > 0 ? Mode.Immediate : Mode.Position;
	            Mode parameterMode2 = (programData[i]/1000%10) > 0 ? Mode.Immediate : Mode.Position;
	            Mode parameterMode3 = (programData[i]/10000%10) > 0 ? Mode.Immediate : Mode.Position;

                // 0 = position mode
                // 1 = immediate mode
                Console.WriteLine(programData[i] + " = opcode : " + opcode + " P1 " + parameterMode1 + " P2 " + parameterMode2 + " P3 " + parameterMode3);

                if(opcode == (int)Opcodes.OPCODE_TERMINATE)
                    break;

                switch((Opcodes)opcode)
                {
                    case Opcodes.OPCODE_ADD:
                        ExecuteAdd(ref programData, parameterMode1, parameterMode2, parameterMode3, i);
                        break;
                    case Opcodes.OPCODE_MULTIPLY:
                        ExecuteMultiply(ref programData, parameterMode1, parameterMode2, parameterMode3, i);
                        break;
                    case Opcodes.OPCODE_SINGLE:
                        ExecuteSingle(ref programData, ref i, input);
                        break;
                    case Opcodes.OPCODE_OUTPUT:
                        ExecuteOutput(ref programData, parameterMode1, ref i, ref output);
                        break;
                }
            }

            return output;
        }

        public enum Mode
        {
            Position,
            Immediate
        }

        private void ExecuteAdd(ref int[] programData, Mode param1, Mode param2, Mode param3, int instructionPointer)
        {
            int input1 = param1 == Mode.Position ? programData[programData[instructionPointer+1]] : programData[instructionPointer+1];
            int input2 = param2 == Mode.Position ? programData[programData[instructionPointer+2]] : programData[instructionPointer+2];
            int pointer = programData[instructionPointer+3];
            programData[pointer] = input1 + input2;
        }

        private void ExecuteMultiply(ref int[] programData, Mode param1, Mode param2, Mode param3, int instructionPointer)
        {
            int input1 = param1 == Mode.Position ? programData[programData[instructionPointer+1]] : programData[instructionPointer+1];
            int input2 = param2 == Mode.Position ? programData[programData[instructionPointer+2]] : programData[instructionPointer+2];
            int pointer = programData[instructionPointer+3];
            programData[pointer] = input1 * input2;
        }

        private void ExecuteSingle(ref int[] programData, ref int instructionPointer, int input)
        {
            programData[programData[instructionPointer+1]] = input;
            instructionPointer -= 2;
        }

        private void ExecuteOutput(ref int[] programData, Mode param1, ref int instructionPointer, ref int output)
        {
            output = param1 == Mode.Position ? programData[programData[instructionPointer+1]] : programData[instructionPointer+1];
            Console.WriteLine("Output: " +  output);
            instructionPointer -= 2;
        }
   }
}
