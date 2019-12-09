using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode2019.Core;

namespace AdventOfCode2019.Puzzles.Day3
{
    public abstract class Day3Puzzle : PuzzleBase
    {
        protected List<Wire> wires;

        protected abstract int HandleIntersection(IntVector2 intersection);

        protected override string GetPuzzleData()
        {
            return "/Day3Data.txt";
        }

        public override string GetSolution()
        {
            var intersections = wires[0].Path.Intersect(wires[1].Path);

            int lowestResult = int.MaxValue;
            foreach(var intersection in intersections)
            {
                if(intersection.X == 0 && intersection.Y == 0)
                    continue;

                int result = HandleIntersection(intersection);
                if(result < lowestResult)
                    lowestResult = result;
            }

            return lowestResult.ToString();
        }

        public override void Initialize()
        {
            base.Initialize();
            PopulateWires();
        }

        protected void PopulateWires()
        {
            Regex offsetExpression = new Regex(@"([UDLR])(\d+)", RegexOptions.Compiled);
            wires = new List<Wire>();

            for(int i=0; i<lines.Length; i++)
            {
                Wire wire = new Wire();

                foreach (Match match in offsetExpression.Matches(lines[i]))
                {
                    IntVector2 to = wire.CurrentPathOrigin;
                    int offset = int.Parse(match.Groups[2].Value);

                    switch(match.Groups[1].Value)
                    {
                        case "U":
                            to.Y += offset;
                            break;
                        case "D":
                            to.Y -= offset;
                            break;
                        case "L":
                            to.X -= offset;
                            break;
                        case "R":
                            to.X += offset;
                            break;
                    }

                    wire.AddPathPoint(to);
                }

                wires.Add(wire);
            }
        }
    }
}
