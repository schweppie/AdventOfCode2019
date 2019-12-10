using System;

namespace AdventOfCode2019.Core
{
    public static class Extensions
    {
        public static int ManhattenDist(this IntVector2 from, IntVector2 to)
        {
            return Math.Abs(from.X - to.X) + Math.Abs(from.Y - to.Y);
        }
    }
}
