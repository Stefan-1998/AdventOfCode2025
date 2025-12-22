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
    }
}
