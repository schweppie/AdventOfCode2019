using System;
using System.Collections.Generic;
using System.Reflection;

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
            Type puzzleType = Type.GetType(BASE_PUZZLE_NAMESPACE + day + ".Day" + day + "Part" + part + "Puzzle");
            
            if (puzzleType == null)
                puzzleType = Type.GetType(BASE_PUZZLE_NAMESPACE + day + ".Day" + day + "Puzzle");
            
            return puzzleType;
        }
    }
}
