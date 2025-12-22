using System.Data;

namespace Advent2025.Day6
{
    public static class TrashCompactor
    {
        public class MathHomeWork
        {
            public long SolveSecondPart(List<string> input)
            {
                var problems = ParseForSecondSolution(input).ToList();
                long sumOfResult = 0;
                foreach (var problem in problems)
                {

                    var operation = problem.Sign.ToString();
                    var terms = problem.Terms;
                    sumOfResult += SolveMathProblem(operation, terms);
                }
                return sumOfResult;
            }

            private IEnumerable<(char Sign, List<string> Terms)> ParseForSecondSolution(List<string> input)
            {
                string signLine = input.FirstOrDefault(line => line.Contains('+'))??throw new NoNullAllowedException("Could not find a line containing signs!");
                char currentSign = signLine[0];
                List<string> TermList = [];

                for (int i = 0; i < signLine.Length; i++)
                {
                    ParseTermOfLine(input, TermList, i);
                    if (IsLastProblem(signLine, i) || IsEndOfProblem(signLine, i))
                    {
                        yield return (currentSign, TermList);
                        if (i + 2 < signLine.Length)
                            currentSign = signLine[i + 1];
                        TermList = [];
                        //start of a new calculation
                    }
                }
            }
            private static bool IsEndOfProblem(string signLine, int i)
            {
                return signLine[i + 1] == '+' || signLine[i + 1] == '*';
            }

            private static bool IsLastProblem(string signLine, int i)
            {
                return i + 2 > signLine.Length;
            }

            private static void ParseTermOfLine(List<string> input, List<string> TermList, int i)
            {
                string term = string.Empty;
                for (int j = 0; j < input.Count; j++)
                {
                    if (char.IsDigit(input[j][i]))
                    {
                        term += input[j][i];
                    }
                }
                if (term != string.Empty)
                {
                    TermList.Add(term);
                }
            }

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
                if (operation == "+")
                {
                    return SolveAdditionProblem(terms);
                }
                return SolveMultiplicationProblem(terms);
            }

            private static long SolveMultiplicationProblem(List<string> terms)
            {
                long result = 1;
                foreach (var term in terms)
                {
                    result *= long.Parse(term.ToString());
                }
                return result;
            }

            private static long SolveAdditionProblem(List<string> terms)
            {
                long result = 0;
                foreach (var term in terms)
                {
                    result += long.Parse(term.ToString());
                }
                return result;
            }
        }
    }
}
