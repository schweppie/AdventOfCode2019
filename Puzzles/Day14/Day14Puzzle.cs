using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode2019.Puzzles.Day14
{
    public abstract class Day14Puzzle : PuzzleBase
    {
        protected override string GetPuzzleData()
        {
            return "/Day14Data.txt";
        }

        protected Dictionary<string, Chemical> availableChemicals;

        public override void Initialize()
        {
            base.Initialize();

            availableChemicals = new Dictionary<string, Chemical>();

            // Add additional space for regex
            for (int i=0; i<lines.Length; i++)
                lines[i] = " " + lines[i];

            Regex searchExpression = new Regex(@"( \d* )(\w*)", RegexOptions.Compiled);

            for (int i=0; i<lines.Length; i++)
            {
                MatchCollection collection = searchExpression.Matches(lines[i]);
                Chemical chemical = null;
                Chemical requiredChemical = null;

                for (int j = collection.Count-1; j >= 0; j--)
                {
                    Match match = collection[j];
                    string id = match.Groups[2].ToString();
                    int amount = int.Parse(match.Groups[1].ToString());
                    if (j == collection.Count -1)
                    {
                        chemical = GetOrAddChemical(id);
                        chemical.SetDefaultQuantity(amount);
                    }
                    else
                    {
                        requiredChemical = GetOrAddChemical(id);

                        chemical.AddRequirement(requiredChemical, amount);
                    }
                }
            }

            Debug();
        }

        private void Debug()
        {
            foreach(Chemical chemical in availableChemicals.Values)
                Console.WriteLine(chemical.GetDebugInfo());
        }

        private Chemical GetOrAddChemical(string id)
        {
            Chemical chemical = null;
            if (availableChemicals.ContainsKey(id))
                chemical = availableChemicals[id];
            else
            {
                chemical = new Chemical(id);
                availableChemicals.Add(id, chemical);
            }
            return chemical;
        }
    }
}
