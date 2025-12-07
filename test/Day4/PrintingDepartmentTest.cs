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

            PrintingDepartment.PaperRollManager manager = new(grid);
            manager.GetAmountOfAccessableRollsByForklift().Count.Should().Be(result);
        }

        [Theory]
        [InlineData("Day4/Example.txt", 43)]
        [InlineData("Day4/Input.txt", 8690)]
        public void NumberOfRollsAfterMultipleRemovalIsCorrect(string path, int expectation)
        {
            var rawGrid = File.ReadAllLines(Path.GetFullPath(path));
            PrintingDepartment.PaperRollGrid grid = new(rawGrid);

            PrintingDepartment.PaperRollManager manager = new(grid);
            long result = 0;
            long oldResult = -1;

            while (result != oldResult)
            {
                oldResult = result;
                var idsToRemove = manager.GetAmountOfAccessableRollsByForklift();
                result += idsToRemove.Count;
                manager.RemoveRolls(idsToRemove);
            }

            result.Should().Be(expectation);
        }
    }
}
