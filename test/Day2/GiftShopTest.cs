using FluentAssertions;

namespace Advent2025.Day2.Test
{
    public class GiftShopTest()
    {
        [Theory]
        [InlineData(11, false)]
        [InlineData(12, true)]
        [InlineData(101, true)]
        [InlineData(102, true)]
        [InlineData(112, true)]
        [InlineData(1010, false)]
        [InlineData(1188511885, false)]
        [InlineData(111, true)]
        [InlineData(999, true)]
        public void IsIdValidWithOnlyTwoGroups(long number, bool expectedResult)
        {
            GiftShop.IsValidId(number, true).Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(11, false)]
        [InlineData(12, true)]
        [InlineData(101, true)]
        [InlineData(102, true)]
        [InlineData(112, true)]
        [InlineData(999, false)]
        [InlineData(1010, false)]
        [InlineData(1188511885, false)]
        [InlineData(565656, false)]
        [InlineData(2121212121, false)]
        public void IsIdValid(long number, bool expectedResult)
        {
            GiftShop.IsValidId(number, false).Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("Day2/Example.txt", 1227775554, true)]
        [InlineData("Day2/Input.txt", 28844599675, true)]
        [InlineData("Day2/Example.txt", 4174379265, false)]
        [InlineData("Day2/Input.txt", 48778605167, false)]
        public void AddingUpAllInvalidIdsProducesResult(
            string path,
            long expectedResult,
            bool onlyUseTwoGroups
        )
        {
            var output = File.ReadAllLines(Path.GetFullPath(path));
            output.Length.Should().Be(1);

            long result = 0;

            var idRanges = output[0].Split(',');
            foreach (var idRange in idRanges)
            {
                var rangeStart = long.Parse(idRange.Split('-')[0]);
                var rangeEnd = long.Parse(idRange.Split('-')[1]);

                while (rangeStart <= rangeEnd)
                {
                    if (!GiftShop.IsValidId(rangeStart, onlyUseTwoGroups))
                    {
                        result += rangeStart;
                    }
                    rangeStart++;
                }
            }
            result.Should().Be(expectedResult);
        }
    }
}
