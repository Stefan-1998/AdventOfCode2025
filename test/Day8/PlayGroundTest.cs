using FluentAssertions;

namespace Advent2025.Day8.Test
{
    public class PlayGroundTest()
    {
        [Theory]
        [InlineData("Day8/Example.txt",40, 10)]
        [InlineData("Day8/Input.txt",81536, 1000)]
        public void CombinationOfTheLargestCircuitsIsTheCorrectAmount(string path, long expectedResult, int pairsToCombine)
        {
            var input = File.ReadAllLines(Path.GetFullPath(path));
            var grouper = new PlayGround.JunctionBoxGrouper(input);
            grouper.GroupBoxesSum(pairsToCombine).Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("Day8/Example.txt",25272 )]
        [InlineData("Day8/Input.txt",7017750530)]
        public void LastTwoJunctionBoxesGenerateTheCorrectAmount(string path, long expectedResult )
        {
            var input = File.ReadAllLines(Path.GetFullPath(path));
            var grouper = new PlayGround.JunctionBoxGrouper(input);
            var boxes =grouper.GetLastCombination();
            long distanceFromWall =(long) (boxes.firstBox.X)*(long) (boxes.secondBox.X);
            distanceFromWall.Should().Be(expectedResult);
        }
    }
}
