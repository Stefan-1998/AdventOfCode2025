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
        public void IsNumberAPalindrome(long number, bool expectedResult)
        {
            GiftShop.IsValidId(number).Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("Day2/Example.txt", 1227775554)]
        [InlineData("Day2/Input.txt", 28844599675)]
        public void AddingUpAllInvalidIdsProducesResult(string path, long expectedResult)
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
                    if (!GiftShop.IsValidId(rangeStart))
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
