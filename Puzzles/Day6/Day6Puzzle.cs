using System;
using System.Collections.Generic;

namespace AdventOfCode2019.Puzzles.Day6
{
    public abstract class Day6Puzzle : PuzzleBase
    {
        protected override string GetPuzzleData()
        {
            return "/Day6Data.txt";
        }

        protected Dictionary<string, Orbit> orbits = new Dictionary<string, Orbit>();

        public override void Initialize()
        {
            base.Initialize();

            for(int i=0; i<lines.Length; i++)
            {
                string[] orbits = lines[i].Split(')');

                Orbit parent = AddOrGetOrbit(orbits[0]);
                Orbit child = AddOrGetOrbit(orbits[1]);

                parent.AddChild(child);
                child.SetParent(parent);
            }
        }

        private Orbit AddOrGetOrbit(string name)
        {
            if(orbits.ContainsKey(name))
                return orbits[name];
            
            Orbit orbit = new Orbit(name);
            orbits.Add(name, orbit);

            return orbit;
        }
    }
}
