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
            return X.GetHashCode() ^ Y.GetHashCode();
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
    }
}
