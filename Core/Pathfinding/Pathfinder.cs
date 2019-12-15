using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Core.Pathfinding
{
    public class Pathfinder
    {
        private HashSet<PathNode> openList = new HashSet<PathNode>();
        private HashSet<PathNode> closedList = new HashSet<PathNode>();

        private Dictionary<IntVector2, int> mapData = new Dictionary<IntVector2, int>();

        public void SetMapData(Dictionary<IntVector2, int> mapData)
        {
            this.mapData = mapData;
        }

        public List<IntVector2> GetPath(IntVector2 from, IntVector2 to)
        {
            List<IntVector2> path = new List<IntVector2>();

            PathNode currentNode;
            openList.Add(new PathNode(from, null));
            List<IntVector2> adjecentTiles = new List<IntVector2>();

            while(true)
            {
                currentNode = openList.OrderBy(x => x.F).First(); // Get the square with the lowest F score

                closedList.Add(currentNode); // add the current square to the closed list
                openList.Remove(currentNode); // remove it to the open list

                PathNode destinationNode = closedList.FirstOrDefault(x => x.Position == to);
                if (destinationNode != null)
                    break; // break the loop

                // Retrieve adjacent squares
                adjecentTiles.Clear();
                foreach(IntVector2 tile in mapData.Keys)
                {
                    // Check if it is a wall
                    if (mapData[tile] != 0)
                        continue;

                    if (tile.X == currentNode.Position.X && tile.Y - 1 == currentNode.Position.Y)
                        adjecentTiles.Add(tile);

                    if (tile.X == currentNode.Position.X - 1 && tile.Y == currentNode.Position.Y)
                        adjecentTiles.Add(tile);

                    if (tile.X == currentNode.Position.X && tile.Y + 1 == currentNode.Position.Y)
                        adjecentTiles.Add(tile);

                    if (tile.X == currentNode.Position.X + 1 && tile.Y == currentNode.Position.Y)
                        adjecentTiles.Add(tile);
                }

                foreach(IntVector2 adjecent in adjecentTiles)
                {

                    if (closedList.FirstOrDefault(x => x.Position == adjecent) != null)
                        continue;

                    PathNode node = openList.FirstOrDefault(x => x.Position == adjecent);
                    if (node == null)
                    {
                        // compute its score, set the parent
                        PathNode newNode = new PathNode(adjecent, currentNode);
                        newNode.SetG( currentNode.G + 1);
                        newNode.SetH( currentNode.Position.ManhattenDist(adjecent));

                        openList.Add(newNode);
                    }
                    else
                    {
                        // test if using the current G score make the aSquare F score lower, if yes update the parent because it means its a better path
                        if ( currentNode.G + 1 < node.G)
                        {
                            node.SetG(currentNode.G + 1);
                            node.SetParent(currentNode);
                        }
                    }

                    // Continue until there is no more available square in the open list (which means there is no path)
                    if(openList.Count == 0)
                        return null;
                }
            }

            while(true)
            {
                if( currentNode.Parent == null)
                    break; // found root node, exiting

                path.Add(currentNode.Position);
                currentNode = currentNode.Parent;
            }

            path.Reverse();

            return path;
        }
    }
}
