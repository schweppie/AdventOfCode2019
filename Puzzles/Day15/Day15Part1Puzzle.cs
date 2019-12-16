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

        private IntVector2 position;
        private IntVector2 direction;

        public override string GetSolution()
        {
            Pathfinder pathFinder = new Pathfinder();
            IntComputer computer = new IntComputer(lines);


            computer.Load();

            IntVector2 origin = new IntVector2(0,0);
            direction = new IntVector2(1,0);

            List<IntVector2> droidPath = new List<IntVector2>();

            droidPath.Add(origin);
            mapData.Add(new IntVector2(0,0), 10);

            IntVector2 rootDirection = direction;
            int checkedDirections = 0;

            mapData[origin] = 0;

            bool traversing = false;

            while(true)
            {
                position = droidPath.Last();

                IntVector2 newPosition = position + direction;

                computer.AddInput(GetMovement(direction));
                computer.Run();

                int output = (int)computer.GetOutput();

                switch(output)
                {
                    case 0:
                        mapData[newPosition] = 1;

                        if (checkedDirections == 0)
                        {
                            direction = new IntVector2(rootDirection.Y, -rootDirection.X);
                            checkedDirections++;
                        }
                        else if ( checkedDirections == 1)
                        {
                            direction = new IntVector2(-rootDirection.Y, rootDirection.X);
                            checkedDirections++;
                        }
                        else if ( checkedDirections == 2)
                        {
                            direction = -rootDirection;
                            traversing = true;
                        }
                        break;
                    case 1:

                        checkedDirections = 0;
                        rootDirection = direction;

                        mapData[newPosition] = 0;
                        droidPath.Add(newPosition);

                        break;
                    case 2:
                        if(mapData.ContainsKey(newPosition))
                            mapData[newPosition] = 4;
                        else
                            mapData.Add(newPosition, 4);

                        return "Hello world";
                        break;

                }

                if( !mapData.ContainsKey(newPosition + direction))
                {
                    Debug();
                    Console.ReadKey();
                    continue;
                }

                direction = new IntVector2(rootDirection.Y, -rootDirection.X);

                if( !mapData.ContainsKey(newPosition + direction))
                {
                    Debug();
                    Console.ReadKey();
                    continue;
                }

                direction = new IntVector2(-rootDirection.Y, rootDirection.X);

                if( !mapData.ContainsKey(newPosition + direction))
                {
                    Debug();
                    Console.ReadKey();
                    continue;
                }

                direction = rootDirection;


                //0: The repair droid hit a wall. Its position has not changed.
                //1: The repair droid has moved one step in the requested direction.
                //2: The repair droid has moved one step in the requested direction; its new position is the location of the oxygen system.



                Debug();
                Console.ReadKey();
            }

            return 1.ToString();
        }

        private int GetMovement(IntVector2 direction)
        {
            // north (1), south (2), west (3), and east (4)
            if (direction.X == 0 )
            {
                if (direction.Y == 1)
                    return 1;
                else if (direction.Y == -1)
                    return 2;
            }
            if (direction.Y == 0 )
            {
                if (direction.X == 1)
                    return 4;
                else if (direction.X == -1)
                    return 3;
            }

            throw new Exception("invalid direction comparison");
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


        private void Debug()
        {
            Console.Clear();
            foreach(var pair in mapData)
            {
                Console.SetCursorPosition(pair.Key.X+40, pair.Key.Y+20);
                if(pair.Key == position)
                {
                    int mov = GetMovement(direction);
                    string sprite = "";
                    switch(mov)
                    {
                        case 1:
                            sprite = "v";
                            break;
                        case 2:
                            sprite = "^";
                            break;
                        case 3:
                            sprite = "<";
                            break;
                        case 4:
                            sprite = ">";
                            break;
                    }
                    Console.Write(sprite);
                }
                else
                {
                    Console.Write(GetDebugTile(pair.Value));
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
