using FluentAssertions;

namespace Advent2025.Day7.Test
{
    public class LaboratoriesTest()
    {
        [Theory]
        [InlineData("Day7/Example.txt",21)]
        [InlineData("Day7/Input.txt",1658)]
        public void IsTheCorrectAmountOfSplitsCounted(string path, int expectedSplits)
        {
            var input = File.ReadAllLines(Path.GetFullPath(path));
            Laboratories.GetAmountOfSplits(input).Should().Be(expectedSplits);
        }

        [Theory]
        [InlineData("Day7/Example.txt",40)]
        [InlineData("Day7/Input.txt",53916299384254)]
        public void IsTheCorrectAmountOfPossibleSplitsCounted(string path, long expectedSplits)
        {
            var input = File.ReadAllLines(Path.GetFullPath(path));
            Laboratories.GetAmountOfSplitsInAllTimeLines(input).Should().Be(expectedSplits);
        }
    }
}
