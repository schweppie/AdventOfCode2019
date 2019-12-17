using System.Linq;
using AdventOfCode2019.Core.Emulation;

namespace AdventOfCode2019.Puzzles.Day17
{
    public class Day17Part2Puzzle : Day17Puzzle
    {
        public override string GetSolution()
        {
            IntComputer computer = new IntComputer(lines);
            computer.Load();
            computer.OverrideInstruction(0, 2);

            // Figured out analog on paper
            var ascii = "A,B,B,A,B,C,A,C,B,C\n" +
                "L,4,L,6,L,8,L,12\n" +
                "L,8,R,12,L,12\n" +
                "R,12,L,6,L,6,L,8\n" +
                "n\n";

            var reversed = ascii.Select(x => (long)x);

            computer.AddInput(reversed);
            computer.Run();

            return computer.GetOutput(computer.OutputCount()-1).ToString();
        }
    }
}
