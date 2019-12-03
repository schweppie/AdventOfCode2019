using System.Collections.Generic;
using System.Linq;
using AdventOfCode2019.Core;

namespace AdventOfCode2019.Puzzles.Day3
{
    public class Wire
    {
        private List<IntVector2> path;
        public List<IntVector2> Path => path;
        public IntVector2 CurrentPathOrigin
        {
            get
            {
                if(path.Count == 0)
                    return new IntVector2(0,0);

                return path.Last();
            }
        }

        public Wire()
        {
            path = new List<IntVector2>();
            path.Add(new IntVector2(0,0));
        }

        public void AddPathPoint(IntVector2 point)
        {
            IntVector2 node = CurrentPathOrigin;
            IntVector2 target = point;

            while(node.X != target.X || node.Y != target.Y)
            {
                if(node.X < target.X)
                    node.X++;
                else if (node.X > target.X)
                    node.X--;

                if(node.Y < target.Y)
                    node.Y++;
                else if (node.Y > target.Y)
                    node.Y--;                    

                Path.Add(node);
            }
        }
    }
}
