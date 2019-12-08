#undef DEBUG

using System.Collections.Generic;

namespace AdventOfCode2019.Core.Emulation
{
    public partial class IntComputer
    {
        private int[] memory;
        private int[] programData;

        private List<int> inputData = new List<int>();

        private int output = int.MinValue;

        private bool running = false;
        public bool Running => running;

        private int instructionPointer;

        public IntComputer(string[] instructions)
        {
            string[] programInput = instructions[0].Split(',');

            memory = new int[programInput.Length];
            programData = new int[programInput.Length];

            for(int i=0; i< programInput.Length; i++)
                programData[i] = int.Parse(programInput[i]);
        }

        public void Load()
        {
            for(int i=0; i< programData.Length; i++)
                memory[i] = programData[i];

            running = true;
            instructionPointer = 0;
        }

        public void OverrideInstruction(int index, int instruction)
        {
            memory[index] = instruction;
        }

        public void AddInput(int input)
        {
            inputData.Add(input);
        }

        public void Run()
        {
            while(instructionPointer < memory.Length)
            {
                int opcode = memory[instructionPointer] % 100;

                // 0 = position mode, 1 = immediate mode
                Mode paraMode1 = (memory[instructionPointer]/100%10) > 0 ? Mode.Immediate : Mode.Position;
                Mode paraMode2 = (memory[instructionPointer]/1000%10) > 0 ? Mode.Immediate : Mode.Position;
#if DEBUG
                Console.WriteLine(memory[instructionPointer] + " = opcode : " + ((Opcodes)opcode).ToString() + " P1 "
                    + paraMode1 + " P2 " + paraMode2);
#endif

                if(opcode == (int)Opcodes.Terminate)
                {
                    running = false;
                    return;
                }

                switch((Opcodes)opcode)
                {
                    case Opcodes.Add:
                        ExecuteAdd(paraMode1, paraMode2);
                        break;
                    case Opcodes.Multiply:
                        ExecuteMultiply(paraMode1, paraMode2);
                        break;
                    case Opcodes.Input:
                        if(inputData.Count > 0)
                        {
                            ExecuteInput(inputData[0]);
                            inputData.RemoveAt(0);
                            break;
                        }
                        else
                        {
                            return;
                        }
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
        }

        public int GetMemory(int index)
        {
            return memory[0];
        }

        public int GetOutput()
        {
            return output;
        }
   }
}
