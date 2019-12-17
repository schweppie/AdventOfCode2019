#undef DEBUG

using System.Collections.Generic;

namespace AdventOfCode2019.Core.Emulation
{
    public partial class IntComputer
    {
        private List<long> memory = new List<long>();
        private long[] programData;

        private List<long> inputData = new List<long>();

        private List<long> output = new List<long>();

        private bool running = false;
        public bool Running => running;

        private int instructionPointer;

        protected long relativeParameterPointer = 0;

        public IntComputer(string[] instructions)
        {
            string[] programInput = instructions[0].Split(',');

            programData = new long[programInput.Length];

            for(int i=0; i< programInput.Length; i++)
                programData[i] = long.Parse(programInput[i]);
        }

        public void Load()
        {
            memory.Clear();
            inputData.Clear();
            output.Clear();

            for(int i=0; i< programData.Length; i++)
                memory.Add(programData[i]);

            running = true;
            instructionPointer = 0;
        }

        public void OverrideInstruction(int index, int instruction)
        {
            SetMemory(index, instruction);
        }

        public void AddInput(IEnumerable<long> list)
        {
            foreach(var ding in list)
                inputData.Add(ding);
        }

        public void AddInput(long input)
        {
            inputData.Add(input);
        }

        public void Run()
        {
            while(running)
            {
                long opcode = GetMemory(instructionPointer) % 100;

                // 0 = position mode, 1 = immediate mode, 2 = relative mode
                Mode paraMode1 = (Mode)(GetMemory(instructionPointer)/100%10);
                Mode paraMode2 = (Mode)(GetMemory(instructionPointer)/1000%10);
                Mode paraMode3 = (Mode)(GetMemory(instructionPointer)/10000%10);
#if DEBUG
                Console.WriteLine(GetMemory(instructionPointer) + " = opcode : " + ((Opcodes)opcode).ToString() + " P1 "
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
                        ExecuteAdd(paraMode1, paraMode2, paraMode3);
                        break;
                    case Opcodes.Multiply:
                        ExecuteMultiply(paraMode1, paraMode2, paraMode3);
                        break;
                    case Opcodes.Input:
                        if(inputData.Count > 0)
                        {
                            ExecuteInput(inputData[0], paraMode1);
                            inputData.RemoveAt(0);
                            break;
                        }
                        else
                        {
                            return;
                        }
                    case Opcodes.Output:
                        ExecuteOutput(paraMode1);
                        break;
                    case Opcodes.JumpIfTrue:
                        ExecuteJumpIfTrue(paraMode1, paraMode2);
                        break;
                    case Opcodes.JumpIfFalse:
                        ExecuteJumpIfFalse(paraMode1, paraMode2);
                        break;
                    case Opcodes.Less:
                        ExecuteLessThan(paraMode1, paraMode2, paraMode3);
                        break;
                    case Opcodes.Equals:
                        ExecuteEquals(paraMode1, paraMode2, paraMode3);
                        break;
                    case Opcodes.RelativeBase:
                        ExecuteRelativeBase(paraMode1);
                        break;
                }
            }
        }

        public long GetMemory(int index)
        {
            while(index >= memory.Count)
                memory.Add(0);

            return memory[index];
        }

        public void SetMemory(int index, long value)
        {
            while(index >= memory.Count)
                memory.Add(0);

            memory[index] = value;
        }

        public long GetOutput()
        {
            return GetOutput(0);
        }

        public bool HasOutputs(int count)
        {
            return output.Count >= count;
        }

        public bool HasOutputs()
        {
            return HasOutputs(1);
        }

        public int OutputCount()
        {
            return output.Count;
        }

        public long GetOutput(int index)
        {
            long outputValue = output[index];
            output.RemoveAt(index);

            return outputValue;
        }
   }
}
