using System.Collections.Generic;

namespace AdventOfCode2019.Core.Pathfinding
{
    public class PathFiller
    {
        private HashSet<PathNode> openList;
        private HashSet<PathNode> closedList;

        private Dictionary<IntVector2, int> mapData = new Dictionary<IntVector2, int>();

        public void SetMapData(Dictionary<IntVector2, int> mapData)
        {
            this.mapData = mapData;
        }

        public int Fill(IntVector2 from)
        {
            openList = new HashSet<PathNode>();
            closedList = new HashSet<PathNode>();
            int steps;
            openList.Add(new PathNode(from, null));
            List<IntVector2> adjecentTiles = new List<IntVector2>();
            List<PathNode> tempList = new List<PathNode>();
            steps = 0;

            while(true)
            {
                tempList.Clear();
                foreach(PathNode node in openList)
                {
                    // Retrieve adjacent squares
                    adjecentTiles.Clear();

                    if(mapData.ContainsKey(node.Position + new IntVector2(0, -1)))
                        adjecentTiles.Add(node.Position + new IntVector2(0, -1));

                    if(mapData.ContainsKey(node.Position + new IntVector2(-1, 0)))
                        adjecentTiles.Add(node.Position + new IntVector2(-1, 0));

                    if(mapData.ContainsKey(node.Position + new IntVector2(0, 1)))
                        adjecentTiles.Add(node.Position + new IntVector2(0, 1));

                    if(mapData.ContainsKey(node.Position + new IntVector2(1, 0)))
                        adjecentTiles.Add(node.Position + new IntVector2(1, 0));

                    foreach(IntVector2 adjecent in adjecentTiles)
                    {
                        if(mapData[adjecent] == 1)
                            continue;

                        if(node.Parent != null && node.Parent.Position == adjecent)
                            continue;

                        tempList.Add(new PathNode(adjecent, node));
                    }

                    closedList.Add(node);
                }

                openList.Clear();
                foreach(PathNode node in tempList)
                    openList.Add(node);

                // Continue until there is no more available square in the open list (which means there is no path)
                if(openList.Count == 0)
                    break;

                steps++;
            }

            return steps;
        }
    }
}
