using FluentAssertions;

namespace Advent2025.Day4.Test
{
    public class PrintingDepartmentTest()
    {
        [Theory]
        [InlineData("Day4/Example.txt", 13)]
        [InlineData("Day4/Input.txt", 1527)]
        public void NumberOfRollsAccessableByForkliftCorrect(string path, int result)
        {
            var rawGrid = File.ReadAllLines(Path.GetFullPath(path));
            PrintingDepartment.PaperRollGrid grid = new(rawGrid);

            grid.AccessableByForkLift().Should().HaveCount(result);
        }
    }
}
