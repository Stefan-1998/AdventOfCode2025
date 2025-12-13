using FluentAssertions;

namespace Advent2025.Day6.Test
{
    public class TrashCompactorTest()
    {
        [Theory]
        [InlineData("Day6/Example.txt", 4277556)]
        [InlineData("Day6/Input.txt", 4387670995909)]
        public void CheckIfNumberOfFreshFoodIsCorrect(string path, long expectation)
        {
            var inputLines = File.ReadAllLines(Path.GetFullPath(path)).ToList();
            var puzzle = inputLines
                .Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                .ToList();
            long endResult = 0;
            for (int i = 0; i < puzzle[0].Count(); i++)
            {
                var mathProblem = puzzle.Select(x => x[i]).ToList();
                var operation = mathProblem[^1];
                var terms = mathProblem[..^1];
                if (operation == "+")
                {
                    long result = 0;
                    foreach (var term in terms)
                    {
                        result += long.Parse(term.ToString());
                    }
                    endResult += result;
                }
                else
                {
                    long result = 1;
                    foreach (var term in terms)
                    {
                        result *= long.Parse(term.ToString());
                    }
                    endResult += result;
                }
            }
            endResult.Should().Be(expectation);
        }
    }
}
