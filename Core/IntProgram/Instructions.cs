namespace AdventOfCode2019.Core.IntProgram
{
    public partial class IntComputer
    {
        public enum Mode
        {
            Position,
            Immediate
        }

        private int GetData(int index, Mode mode)
        {
            return (mode == Mode.Position) ? programData[programData[index]] : programData[index];
        }

        private void ExecuteJumpIfTrue(Mode param1, Mode param2)
        {
            if(GetData(instructionPointer + 1, param1) != 0)
                instructionPointer = GetData(instructionPointer + 2, param2);
            else
                instructionPointer += 3;
        }

        private void ExecuteJumpIfFalse(Mode param1, Mode param2)
        {
            if(GetData(instructionPointer + 1, param1) == 0)
                instructionPointer = GetData(instructionPointer + 2, param2);
            else
                instructionPointer += 3;
        }

        private void ExecuteLessThan(Mode param1, Mode param2)
        {
            int pointer = GetData(instructionPointer + 3, Mode.Immediate);
            if(GetData(instructionPointer + 1, param1) < GetData(instructionPointer + 2, param2))
                programData[pointer] = 1;
            else
                programData[pointer] = 0;
            instructionPointer += 4;
        }

        private void ExecuteEquals(Mode param1, Mode param2)
        {
            int pointer = GetData(instructionPointer + 3, Mode.Immediate);
            if(GetData(instructionPointer + 1, param1) == GetData(instructionPointer + 2, param2))
                programData[pointer] = 1;
            else
                programData[pointer] = 0;
            instructionPointer += 4;
        }

        private void ExecuteAdd(Mode param1, Mode param2)
        {
            int pointer = GetData(instructionPointer + 3, Mode.Immediate);
            programData[pointer] = GetData(instructionPointer + 1, param1) + GetData(instructionPointer + 2, param2);
            instructionPointer += 4;
        }

        private void ExecuteMultiply(Mode param1, Mode param2)
        {
            int pointer = GetData(instructionPointer + 3, Mode.Immediate);
            programData[pointer] = GetData(instructionPointer + 1, param1) * GetData(instructionPointer + 2, param2);
            instructionPointer += 4;
        }

        private void ExecuteSingle(int input)
        {
            programData[programData[instructionPointer+1]] = input;
            instructionPointer += 2;
        }

        private void ExecuteOutput()
        {
            output = GetData(instructionPointer + 1, Mode.Position);
            instructionPointer += 2;
        }        
    }
}
