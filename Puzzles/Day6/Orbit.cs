using System.Collections.Generic;

namespace AdventOfCode2019.Puzzles.Day6
{
    public class Orbit
    {
        private Orbit parent;
        public Orbit Parent => parent;

        private List<Orbit> children = new List<Orbit>();
        public List<Orbit> Children => children;

        private int parents = 0;
        public int Parents => parents;

        private string name;

        public Orbit(string name)
        {
            this.name = name;
        }

        public void SetParent(Orbit parent)
        {
            this.parent = parent;
            parents = parent.parents + 1;

            foreach (Orbit child in children)
                child.SetParent(this);

            parent.AddChild(this);
        }

        public void AddChild(Orbit child)
        {
            if (!children.Contains(child))
                children.Add(child);
        }

        public bool HasOrbitAsChild(Orbit orbit)
        {
            if (children.Contains(orbit))
                return true;
            else 
            {
                foreach (Orbit child in children )
                {
                    if (child.HasOrbitAsChild(orbit))
                        return true;
                }
            }

            return false;
        }
    }
}
