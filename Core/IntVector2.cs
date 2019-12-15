namespace AdventOfCode2019.Core
{
    public struct IntVector2
    {
        public int X;
        public int Y;

        public IntVector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            IntVector2 other = (IntVector2)obj;

            if(other == null)
                return false;

           return X == other.X && Y == other.Y;
        }

        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return X + "," + Y + " ";
        }

        public static bool operator ==(IntVector2 a, IntVector2 b)
        {
            return a.X == b.X && a.Y == b.Y;
        }
        public static bool operator !=(IntVector2 a, IntVector2 b)
        {
            return !(a == b);
        }

        public static IntVector2 operator +(IntVector2 a, IntVector2 b)
        {
            return new IntVector2 (a.X + b.X, a.Y + b.Y);
        }

        public static IntVector2 operator -(IntVector2 a, IntVector2 b)
        {
            return new IntVector2 (a.X - b.X, a.Y - b.Y);
        }

        public static IntVector2 Max()
        {
            return new IntVector2(int.MaxValue, int.MaxValue);
        }

        public static IntVector2 Min()
        {
            return new IntVector2(int.MinValue, int.MinValue);
        }
    }
}
