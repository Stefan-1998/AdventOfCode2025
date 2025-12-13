namespace Advent2025.Day6
{
    public static class TrashCompactor
    {
        public class MathHomeWork
        {
            public long SolveFirstPart(List<string> input)
            {
                long sumOfResult = 0;
                var puzzle = input
                    .Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                    .ToList();
                for (int i = 0; i < puzzle[0].Count(); i++)
                {
                    var mathProblem = puzzle.Select(x => x[i]).ToList();
                    var operation = mathProblem[^1];
                    var terms = mathProblem[..^1];
                    sumOfResult += SolveMathProblem(operation, terms);
                }
                return sumOfResult;
            }

            private static long SolveMathProblem(string operation, List<string> terms)
            {
                long result = 0;
                if (operation == "+")
                {
                    foreach (var term in terms)
                    {
                        result += long.Parse(term.ToString());
                    }
                    return result;
                }
                result = 1;
                foreach (var term in terms)
                {
                    result *= long.Parse(term.ToString());
                }
                return result;
            }
        }
    }
}
