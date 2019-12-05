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

        protected int GetProgramOutput(int input)
        {
            int[] programData = GetProgramData();
            int output = (int)Opcodes.ERROR;
            //input = 1;
            //programData = new int[] {3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99};

            int instructionPointer=0;
            while(instructionPointer < programData.Length)
            {
                int opcode = programData[instructionPointer] % 100;

	            Mode paraMode1 = (programData[instructionPointer]/100%10) > 0 ? Mode.Immediate : Mode.Position;
	            Mode paraMode2 = (programData[instructionPointer]/1000%10) > 0 ? Mode.Immediate : Mode.Position;
	            Mode paraMode3 = (programData[instructionPointer]/10000%10) > 0 ? Mode.Immediate : Mode.Position;

                // 0 = position mode
                // 1 = immediate mode
                Console.WriteLine(programData[instructionPointer] + " = opcode : " + ((Opcodes)opcode).ToString() + " P1 "
                    + paraMode1 + " P2 " + paraMode2 + " P3 " + paraMode3);

                if(opcode == (int)Opcodes.OPCODE_TERMINATE)
                    break;

                switch((Opcodes)opcode)
                {
                    case Opcodes.OPCODE_ADD:
                        ExecuteAdd(ref programData, paraMode1, paraMode2, paraMode3, ref instructionPointer);
                        break;
                    case Opcodes.OPCODE_MULTIPLY:
                        ExecuteMultiply(ref programData, paraMode1, paraMode2, paraMode3, ref instructionPointer);
                        break;
                    case Opcodes.OPCODE_SINGLE:
                        ExecuteSingle(ref programData, ref instructionPointer, input);
                        break;
                    case Opcodes.OPCODE_OUTPUT:
                        ExecuteOutput(ref programData, paraMode1, ref instructionPointer, ref output);
                        break;
                    case Opcodes.OPCODE_JUMP_IF_TRUE:
                        ExecuteJumpIfTrue(ref programData, paraMode1, paraMode2, paraMode3, ref instructionPointer);
                        break;
                    case Opcodes.OPCODE_JUMP_IF_FALSE:
                        ExecuteJumpIfFalse(ref programData, paraMode1, paraMode2, paraMode3, ref instructionPointer);
                        break;
                    case Opcodes.OPCODE_LESS_THAN:
                        ExecuteLessThan(ref programData, paraMode1, paraMode2, paraMode3, ref instructionPointer);
                        break;
                    case Opcodes.OPCODE_EQUALS:
                        ExecuteEquals(ref programData, paraMode1, paraMode2, paraMode3, ref instructionPointer);
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

        private void ExecuteJumpIfTrue(ref int[] programData, Mode param1, Mode param2, Mode param3, ref int instructionPointer)
        {
            int input1 = param1 == Mode.Position ? programData[programData[instructionPointer+1]] : programData[instructionPointer+1];
            int input2 = param2 == Mode.Position ? programData[programData[instructionPointer+2]] : programData[instructionPointer+2];

            if(input1 != 0)
                instructionPointer = input2;
            else
                instructionPointer += 3;
        }

        private void ExecuteJumpIfFalse(ref int[] programData, Mode param1, Mode param2, Mode param3, ref int instructionPointer)
        {
            int input1 = param1 == Mode.Position ? programData[programData[instructionPointer+1]] : programData[instructionPointer+1];
            int input2 = param2 == Mode.Position ? programData[programData[instructionPointer+2]] : programData[instructionPointer+2];

            if(input1 == 0)
                instructionPointer = input2;
            else
                instructionPointer += 3;
        }

        private void ExecuteLessThan(ref int[] programData, Mode param1, Mode param2, Mode param3, ref int instructionPointer)
        {
            int input1 = param1 == Mode.Position ? programData[programData[instructionPointer+1]] : programData[instructionPointer+1];
            int input2 = param2 == Mode.Position ? programData[programData[instructionPointer+2]] : programData[instructionPointer+2];
            int pointer = programData[instructionPointer+3];
            if(input1 < input2)
                programData[pointer] = 1;
            else
                programData[pointer] = 0;
            instructionPointer += 4;
        }

        private void ExecuteEquals(ref int[] programData, Mode param1, Mode param2, Mode param3, ref int instructionPointer)
        {
            int input1 = param1 == Mode.Position ? programData[programData[instructionPointer+1]] : programData[instructionPointer+1];
            int input2 = param2 == Mode.Position ? programData[programData[instructionPointer+2]] : programData[instructionPointer+2];
            int pointer = programData[instructionPointer+3];
            if(input1 == input2)
                programData[pointer] = 1;
            else
                programData[pointer] = 0;
            instructionPointer += 4;
        }

        private void ExecuteAdd(ref int[] programData, Mode param1, Mode param2, Mode param3, ref int instructionPointer)
        {
            int input1 = param1 == Mode.Position ? programData[programData[instructionPointer+1]] : programData[instructionPointer+1];
            int input2 = param2 == Mode.Position ? programData[programData[instructionPointer+2]] : programData[instructionPointer+2];
            int pointer = programData[instructionPointer+3];
            programData[pointer] = input1 + input2;
            instructionPointer += 4;
        }

        private void ExecuteMultiply(ref int[] programData, Mode param1, Mode param2, Mode param3, ref int instructionPointer)
        {
            int input1 = param1 == Mode.Position ? programData[programData[instructionPointer+1]] : programData[instructionPointer+1];
            int input2 = param2 == Mode.Position ? programData[programData[instructionPointer+2]] : programData[instructionPointer+2];
            int pointer = programData[instructionPointer+3];
            programData[pointer] = input1 * input2;
            instructionPointer += 4;
        }

        private void ExecuteSingle(ref int[] programData, ref int instructionPointer, int input)
        {
            programData[programData[instructionPointer+1]] = input;
            instructionPointer += 2;
        }

        private void ExecuteOutput(ref int[] programData, Mode param1, ref int instructionPointer, ref int output)
        {
            output = param1 == Mode.Position ? programData[programData[instructionPointer+1]] : programData[instructionPointer+1];
            Console.WriteLine("Output: " +  output);
            instructionPointer += 2;
        }
   }
}
