using System;
using System.Collections.Generic;

namespace AdventOfCode2019.Puzzles
{
    public class PuzzleFactory
    {
        private const string BASE_PUZZLE_NAMESPACE = "AdventOfCode2019.Puzzles.Puzzle.Day";

        private Dictionary<Type, PuzzleBase> puzzlesCacheDictionary;

        public void Initialize()
        {
            puzzlesCacheDictionary = new Dictionary<Type, PuzzleBase>();
        }

        public PuzzleBase GetPuzzle(int day, int part)
        {
            Type puzzleType = GetPuzzleType(day, part);
            if(puzzleType == null)
                return null;

            if(puzzlesCacheDictionary.ContainsKey(puzzleType))
                return puzzlesCacheDictionary[puzzleType];

            PuzzleBase puzzle = (PuzzleBase) Activator.CreateInstance(puzzleType);
            puzzlesCacheDictionary.Add(puzzleType, puzzle);

            return puzzle;
        }

        private Type GetPuzzleType(int day, int part)
        {
            string puzzlePrefix = BASE_PUZZLE_NAMESPACE + day + ".Day" + day;

            Type puzzleType = Type.GetType(puzzlePrefix + "Part" + part + "Puzzle");
            
            if (puzzleType == null)
                puzzleType = Type.GetType(puzzlePrefix + "Puzzle");
            
            return puzzleType;
        }
    }
}
