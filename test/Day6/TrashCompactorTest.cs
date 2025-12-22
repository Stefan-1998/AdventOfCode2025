using FluentAssertions;

namespace Advent2025.Day6.Test
{
    public class TrashCompactorTest()
    {
        [Theory]
        [InlineData("Day6/Example.txt", 4277556)]
        [InlineData("Day6/Input.txt", 4387670995909)]
        public void SolvingWithFirstVariantIsExpectedResult(string path, long expectation)
        {
            var inputLines = File.ReadAllLines(Path.GetFullPath(path)).ToList();
            TrashCompactor.MathHomeWork homework = new();
            homework.SolveFirstPart(inputLines).Should().Be(expectation);
        }

        [Theory]
        [InlineData("Day6/Example.txt", 3263827)]
        [InlineData("Day6/Input.txt", 9625320374409)]
        public void SolvingWithSecondVariantIsExpectedResult(string path, long expectation)
        {
            var inputLines = File.ReadAllLines(Path.GetFullPath(path)).ToList();
            TrashCompactor.MathHomeWork homework = new();
            homework.SolveSecondPart(inputLines).Should().Be(expectation);
        }
    }
}
