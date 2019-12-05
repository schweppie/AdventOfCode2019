namespace AdventOfCode2019.Puzzles.Day5
{
    public enum Opcodes
    {
        OPCODE_TERMINATE = 99,
        OPCODE_ADD = 1,
        OPCODE_MULTIPLY = 2,
        OPCODE_SINGLE = 3,
        OPCODE_OUTPUT = 4,
        OPCODE_JUMP_IF_TRUE = 5,
        OPCODE_JUMP_IF_FALSE = 6,
        OPCODE_LESS_THAN = 7,
        OPCODE_EQUALS = 8,
        ERROR = -1
    }
}
