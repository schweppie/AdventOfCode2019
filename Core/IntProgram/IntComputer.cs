using System;

namespace AdventOfCode2019.Core.IntProgram
{
    public partial class IntComputer
    {
        private int[] programData;
        
        int instructionPointer;
        int output = (int)Opcodes.Error;

        public IntComputer(string[] instructions)
        {
            string[] programInput = instructions[0].Split(',');
            programData = new int[programInput.Length];

            for(int i=0; i< programInput.Length; i++)
                programData[i] = int.Parse(programInput[i]);
        }

        public int GetProgramOutput(int input)
        {
            instructionPointer = 0;

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

                if(opcode == (int)Opcodes.Terminate)
                    break;

                switch((Opcodes)opcode)
                {
                    case Opcodes.Add:
                        ExecuteAdd(paraMode1, paraMode2);
                        break;
                    case Opcodes.Multiply:
                        ExecuteMultiply(paraMode1, paraMode2);
                        break;
                    case Opcodes.Input:
                        ExecuteSingle(input);
                        break;
                    case Opcodes.Output:
                        ExecuteOutput();
                        break;
                    case Opcodes.JumpIfTrue:
                        ExecuteJumpIfTrue(paraMode1, paraMode2);
                        break;
                    case Opcodes.JumpIfFalse:
                        ExecuteJumpIfFalse(paraMode1, paraMode2);
                        break;
                    case Opcodes.Less:
                        ExecuteLessThan(paraMode1, paraMode2);
                        break;
                    case Opcodes.Equals:
                        ExecuteEquals(paraMode1, paraMode2);
                        break;
                }
            }
            return output;
        }
   }
}
