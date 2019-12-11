using System;

namespace AdventOfCode2019.Core.Emulation
{
    public partial class IntComputer
    {
        public enum Mode
        {
            Position = 0,
            Immediate = 1,
            Relative = 2,
        }

        private long GetData(long index, Mode mode)
        {
            switch(mode)
            {
                case Mode.Position:
                     return GetMemory((int)GetMemory((int)index));
                case Mode.Immediate:
                    return  GetMemory((int)index);
                case Mode.Relative:
                    return GetMemory((int)GetMemory((int)index) + (int)relativeParameterPointer);
            }

            throw new Exception("Incorrect parameter mode! ");
        }

        private void ExecuteJumpIfTrue(Mode param1, Mode param2)
        {
            if(GetData(instructionPointer + 1, param1) != 0)
                instructionPointer = (int)GetData(instructionPointer + 2, param2);
            else
                instructionPointer += 3;
        }

        private void ExecuteJumpIfFalse(Mode param1, Mode param2)
        {
            if(GetData(instructionPointer + 1, param1) == 0)
                instructionPointer = (int)GetData(instructionPointer + 2, param2);
            else
                instructionPointer += 3;
        }

        private void ExecuteLessThan(Mode param1, Mode param2, Mode param3)
        {
            int pointer = GetWritePointer(instructionPointer + 3, param3);
            if(GetData(instructionPointer + 1, param1) < GetData(instructionPointer + 2, param2))
                SetMemory(pointer, 1);
            else
                SetMemory(pointer, 0);
            instructionPointer += 4;
        }

        private void ExecuteEquals(Mode param1, Mode param2, Mode param3)
        {
            int pointer = GetWritePointer(instructionPointer + 3, param3);
            if(GetData(instructionPointer + 1, param1) == GetData(instructionPointer + 2, param2))
                SetMemory(pointer, 1);
            else
                SetMemory(pointer, 0);
            instructionPointer += 4;
        }

        private void ExecuteAdd(Mode param1, Mode param2, Mode param3)
        {
            int pointer = GetWritePointer(instructionPointer + 3, param3);
            SetMemory(pointer, GetData(instructionPointer + 1, param1) + GetData(instructionPointer + 2, param2));
            instructionPointer += 4;
        }

        private void ExecuteMultiply(Mode param1, Mode param2, Mode param3)
        {
            int pointer = GetWritePointer(instructionPointer + 3, param3);
            SetMemory(pointer, GetData(instructionPointer + 1, param1) * GetData(instructionPointer + 2, param2));
            instructionPointer += 4;
        }

        private void ExecuteInput(long input, Mode param1)
        {
            SetMemory(GetWritePointer(instructionPointer + 1, param1), input);
            instructionPointer += 2;
        }

        private int GetWritePointer(int index, Mode mode)
        {
            int pointer = (int)GetMemory((int)(index));
            if(mode == Mode.Relative)
                pointer += (int)relativeParameterPointer;
            return pointer;
        }

        private void ExecuteRelativeBase(Mode param1)
        {
            relativeParameterPointer += GetData(instructionPointer + 1, param1);
            instructionPointer += 2;
        }

        private void ExecuteOutput(Mode param1)
        {
            long outputValue = GetData(instructionPointer + 1, param1);
            output.Add(outputValue);
            //Console.WriteLine("Output: " + outputValue);
            instructionPointer += 2;
        }
    }
}
