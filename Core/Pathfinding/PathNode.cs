namespace AdventOfCode2019.Core.Pathfinding
{
    public class PathNode
    {
        private IntVector2 position;
        public IntVector2 Position => position;

        private int g;
        public int G => g;

        private int h;

        private PathNode parent;
        public PathNode Parent => parent;

        public PathNode(IntVector2 position, PathNode parent)
        {
            this.position = position;
            this.parent = parent;
        }

        public int F
        {
            get
            {
                return g*h;
            }
        }

        public void SetG(int g)
        {
            this.g = g;
        }

        public void SetH(int h)
        {
            this.h = h;
        }

        public void SetParent(PathNode parent)
        {
            this.parent = parent;
        }
    }
}
