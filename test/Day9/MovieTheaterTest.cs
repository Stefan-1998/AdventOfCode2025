using FluentAssertions;

namespace Advent2025.Day9.Test
{
    public class MovieTheaterTest()
    {
        [Theory]
        [InlineData("Day9/Example.txt","50")]
        [InlineData("Day9/Input.txt","4786902990")]
        public void CalculatingTheCorrectMaxAreaIsCorrect(string path, string area)
        {
            var input = File.ReadAllLines(Path.GetFullPath(path));
            var tileMaximizer = new MovieTheater.TileAreaMaximizer(input);
            var maxArea =tileMaximizer.RectangleAreaMap.Values.Max();
            var test = tileMaximizer.RectangleAreaMap.Where(x => x.Value >=maxArea).ToList();
            maxArea.ToString().Should().Be(area);
        }
    }
}
