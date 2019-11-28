using System;
using AdventOfCode2019.Puzzles;

namespace AdventOfCode2019
{
    public class Program
    {
        static void Main(string[] args)
        {
            PuzzleFactory puzzleFactory = new PuzzleFactory();
            PuzzleBase puzzle;

            puzzleFactory.Initialize();

            int day;
            int part = -1;

            while (true)
            {
                Console.WriteLine("Enter Puzzle day and part: day,part");
                string puzzleInput = Console.ReadLine();
                
                if(!GetDayAndPart(puzzleInput, out day, out part))
                {
                    Console.WriteLine("Invalid input..");
                    continue;
                }

                puzzle = puzzleFactory.GetPuzzle(day, part);
                
                if (puzzle != null)
                    Console.WriteLine("Solution: " + puzzle.GetSolution());
                else
                    Console.WriteLine("Puzzle not found..");
            }
        }

        private static bool GetDayAndPart(string puzzleInput, out int day, out int part)
        {
            string[] puzzleInputData;
            day = -1;
            part = -1;

            if(string.IsNullOrEmpty(puzzleInput))
                return false;

            puzzleInputData = puzzleInput.Split(',');

            if(!int.TryParse(puzzleInputData[0], out day))
                return false;
            
            if(puzzleInputData.Length > 1 && !int.TryParse(puzzleInputData[1], out part))
                part = -1;

            return true;
        }
    }
}
