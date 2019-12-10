using System;
using System.Collections.Generic;

namespace AdventOfCode2019.Core
{
    public static class Extensions
    {
        public static int ManhattenDist(this IntVector2 from, IntVector2 to)
        {
            return Math.Abs(from.X - to.X) + Math.Abs(from.Y - to.Y);
        }

        public static int IndexOfKey<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            int i = 0;
            foreach(var pair in dictionary)
            {
                if(pair.Key.Equals(key))
                    return i;
                i++;
            }
            return -1;
        }
    }
}
