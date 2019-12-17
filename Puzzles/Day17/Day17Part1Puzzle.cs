    using System.Collections.Generic;
using AdventOfCode2019.Core;

namespace AdventOfCode2019.Puzzles.Day17
{
    public class Day17Part1Puzzle : Day17Puzzle
    {
        public override string GetSolution()
        {


            List<IntVector2> intersections = new List<IntVector2>();

            foreach(var pos in viewData.Keys)
            {
                if(viewData[pos] != 35)
                    continue;

                if (viewData.ContainsKey(pos + new IntVector2(0, 1)))
                    if (viewData[pos + new IntVector2(0, 1)] == 46)
                        continue;

                if (viewData.ContainsKey(pos + new IntVector2(0, -1)))
                    if (viewData[pos + new IntVector2(0, -1)] == 46)
                        continue;

                if (viewData.ContainsKey(pos + new IntVector2(1, 0)))
                    if (viewData[pos + new IntVector2(1, 0)] == 46)
                        continue;

                if (viewData.ContainsKey(pos + new IntVector2(-1, 0)))
                    if (viewData[pos + new IntVector2(-1, 0)] == 46)
                        continue;

                intersections.Add(pos);
            }

            Debug(intersections);

            int sum = 0;
            foreach(IntVector2 vec in intersections)
            {
                sum += (vec.X * vec.Y);
            }

            return sum.ToString();
        }
    }
}

