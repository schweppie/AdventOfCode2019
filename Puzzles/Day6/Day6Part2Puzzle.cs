namespace AdventOfCode2019.Puzzles.Day6
{
    public class Day6Part2Puzzle : Day6Puzzle
    {
        public override string GetSolution()
        {
            Orbit com = orbits["COM"];
            Orbit santa = orbits["SAN"];
            Orbit you = orbits["YOU"];

            int steps=0;
            Orbit pointer = you.Parent;
            while (!pointer.HasOrbitAsChild(santa))
            {
                pointer = pointer.Parent;
                steps++;
            }

            pointer = santa.Parent;
            while (!pointer.HasOrbitAsChild(you))
            {
                pointer = pointer.Parent;
                steps++;
            }

            return steps.ToString();
        }

    }
}
