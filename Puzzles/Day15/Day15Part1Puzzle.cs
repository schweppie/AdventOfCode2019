using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using AdventOfCode2019.Core;
using AdventOfCode2019.Core.Emulation;
using AdventOfCode2019.Core.Pathfinding;

namespace AdventOfCode2019.Puzzles.Day15
{
    public class Day15Part1Puzzle : Day15Puzzle
    {
        private Dictionary<IntVector2, int> mapData = new Dictionary<IntVector2, int>();

        private Dictionary<IntVector2, int> spiralMap = new Dictionary<IntVector2, int>();

        private IntVector2 spiralDirection;
        private IntVector2 spiralPosition;

        public override string GetSolution()
        {
            Pathfinder pathFinder = new Pathfinder();
            IntComputer computer = new IntComputer(lines);

            spiralMap.Add(new IntVector2(0,0), 10);
            mapData.Add(new IntVector2(0,0), 10);

            spiralPosition = new IntVector2(0, 0);
            spiralDirection = new IntVector2(1, 0);

            while(true)
            {
                spiralPosition += spiralDirection;
                spiralMap.Add(spiralPosition, 2);
                //DebugSpiral();
                //Console.ReadKey();
                pathFinder.SetMapData(mapData);
                List<IntVector2> path = pathFinder.GetPath(new IntVector2(0,0), spiralPosition);

                computer.Load();

                IntVector2 origin = new IntVector2(0,0);
                for(int i=0; i<path.Count; i++)
                {
                    int input = GetDirection(origin, path[i]);

                    computer.AddInput(input);
                    computer.Run();

                    int output = (int)computer.GetOutput();

                    if (output == 0)
                    {
                        if(mapData.ContainsKey(path[i]))
                            mapData[path[i]] = 1;
                        else
                            mapData.Add(path[i], 1);
                        break;
                    }
                    if (output == 2)
                    {
                        Console.WriteLine("found at " + path[i]);
                        Console.ReadKey();
                        break;
                    }

                    origin = path[i];
                }

                IntVector2 neighbour = spiralPosition + new IntVector2(spiralDirection.Y, -spiralDirection.X);

                if (!spiralMap.Keys.Contains(neighbour))
                    spiralDirection = new IntVector2(spiralDirection.Y, -spiralDirection.X);

                //DebugBitmap();
                Debug(path);
                Console.ReadKey();
            }

            return 1.ToString();
        }

        private int GetDirection(IntVector2 from, IntVector2 to)
        {
            // north (1), south (2), west (3), and east (4)

            if (to.X == from.X)
            {
                if (to.Y > from.Y)
                    return 1;
                else
                    return 2;
            }

            if (to.Y == from.Y)
            {
                if (to.X > from.X)
                    return 4;
                else
                    return 3;
            }

            throw new Exception("invalid direction comparison");
        }

        private void DebugBitmap()
        {
            using (Bitmap bitmap = new Bitmap(256,256)){
                using (Graphics graphics = Graphics.FromImage(bitmap)){
                    graphics.Clear(Color.White);
                }

                foreach(var pair in mapData)
                {
                    bitmap.SetPixel(pair.Key.X+128, pair.Key.Y+128 ,GetTileColor(pair.Value));
                }

                bitmap.Save("randomName.bmp", ImageFormat.Bmp);
            }
        }


        private void Debug(List<IntVector2> path)
        {
            Console.Clear();
            foreach(var pair in mapData)
            {
                Console.SetCursorPosition(pair.Key.X+40, pair.Key.Y+15);
                Console.Write(GetDebugTile(pair.Value));
            }

            foreach(var pair in mapData)
            {
                foreach(var node in path)
                {
                    if(pair.Key == node)
                    {
                        Console.SetCursorPosition(pair.Key.X+40, pair.Key.Y+15);
                        Console.Write(GetDebugTile(4));
                    }
                }
            }

             Console.SetCursorPosition(0,28);
        }

        private void DebugSpiral()
        {
            Console.Clear();
            foreach(var pair in spiralMap)
            {
                Console.SetCursorPosition(pair.Key.X+40, pair.Key.Y+15);
                Console.Write(GetDebugTile(pair.Value));
            }

             Console.SetCursorPosition(0,28);
             Console.WriteLine("direction: " + spiralDirection.X + "," + spiralDirection.Y );
        }

        private string GetDebugTile(int tile)
        {
            switch(tile)
            {
                case 0: return ".";
                case 1: return "#";
                case 2: return "*";
                case 4: return "P";
                case 10: return "S";
            }

            return "";
        }

        private Color GetTileColor(int tile)
        {
            switch(tile)
            {
                case 0: return Color.Black;
                case 1: return Color.Red;
                case 2: return Color.Green;
                case 4: return Color.Blue;
                case 10: return Color.DarkCyan;
            }

            return Color.Magenta;
        }
    }
}
