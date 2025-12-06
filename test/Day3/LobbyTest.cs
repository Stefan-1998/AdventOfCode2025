using FluentAssertions;

namespace Advent2025.Day3.Test
{
    public class LobbyTest()
    {
        [Theory]
        [InlineData("987654321111111", 98)]
        [InlineData("811111111111119", 89)]
        [InlineData("234234234234278", 78)]
        [InlineData("818181911112111", 92)]
        [InlineData("818181991112111", 99)]
        public void MaxJoltageRatingForSimpleBatteyIs21(string jolateRating, int expectedMaxJoltage)
        {
            Lobby.BatteryBank batteryBank = new(jolateRating);
            batteryBank.GetMaxJoltageFromTwoBatteries().Should().Be(expectedMaxJoltage);
        }

        [Theory]
        [InlineData("Day3/Example.txt", 357)]
        [InlineData("Day3/Input.txt", 16854)]
        public void MaxJoltageOfAllBanksIsExpectedValue(string path, int expectedJoltage)
        {
            var joltageRatingsOfEachBank = File.ReadAllLines(Path.GetFullPath(path));

            int result = 0;
            foreach (var rating in joltageRatingsOfEachBank)
            {
                Lobby.BatteryBank batteryBank = new(rating);
                result += batteryBank.GetMaxJoltageFromTwoBatteries();
            }

            result.Should().Be(expectedJoltage);
        }
    }
}
