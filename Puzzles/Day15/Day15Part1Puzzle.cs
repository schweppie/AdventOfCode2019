using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2019.Core;
using AdventOfCode2019.Core.Pathfinding;

namespace AdventOfCode2019.Puzzles.Day15
{
    public class Day15Part1Puzzle : Day15Puzzle
    {
        private Dictionary<IntVector2, int> mapData = new Dictionary<IntVector2, int>();
        public override string GetSolution()
        {
            Pathfinder pathFinder = new Pathfinder();

            for(int i=0;i<10; i++)
            {
                for(int j=0;j<10; j++)
                {
                    mapData.Add(new IntVector2(i,j), 0);
                }
            }

            List<IntVector2> tiles = mapData.Keys.Where(x => x.X == 5).Where(x => x.Y > 3 && x.Y < 8).ToList();

            foreach(var tile in tiles)
                mapData[tile] = 1;

            pathFinder.SetMapData(mapData);

            List<IntVector2> path = pathFinder.GetPath(new IntVector2(0,0), new IntVector2(9, 7));

            foreach(var tile in path)
                mapData[tile] = 2;

            Debug();

            return 1.ToString();
        }

        private void Debug()
        {
            Console.Clear();
            foreach(var pair in mapData)
            {
                Console.SetCursorPosition(pair.Key.X, pair.Key.Y);
                Console.Write(GetDebugTile(pair.Value));
            }
        }

        private string GetDebugTile(int tile)
        {
            switch(tile)
            {
                case 0: return ".";
                case 1: return "#";
                case 2: return "*";
            }

            return "";
        }
    }
}
