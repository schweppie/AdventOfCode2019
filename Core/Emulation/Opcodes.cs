namespace AdventOfCode2019.Core.Emulation
{
    public enum Opcodes
    {
        Error = -1,
        Add = 1,
        Multiply = 2,
        Input = 3,
        Output = 4,
        JumpIfTrue = 5,
        JumpIfFalse = 6,
        Less = 7,
        Equals = 8,
        Terminate = 99,
    }
}
