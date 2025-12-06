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
        public void MaxJoltageRatingBy2Batteries(string jolateRating, long expectedMaxJoltage)
        {
            Lobby.BatteryBank batteryBank = new(jolateRating);
            batteryBank.GetMaxJoltage(2).Should().Be(expectedMaxJoltage);
        }

        [Theory]
        [InlineData("987654321111111", 987)]
        [InlineData("811111111111119", 819)]
        [InlineData("234234234234278", 478)]
        [InlineData("818181911112111", 921)]
        [InlineData("818181991112111", 992)]
        [InlineData("234234234234678", 678)]
        public void MaxJoltageRatingBy3Batteries(string jolateRating, long expectedMaxJoltage)
        {
            Lobby.BatteryBank batteryBank = new(jolateRating);
            batteryBank.GetMaxJoltage(3).Should().Be(expectedMaxJoltage);
        }

        [Theory]
        [InlineData("987654321111111", 987654321111)]
        [InlineData("811111111111119", 811111111119)]
        [InlineData("234234234234278", 434234234278)]
        [InlineData("818181911112111", 888911112111)]
        public void MaxJoltageRatingBy12Batteries(string jolateRating, long expectedMaxJoltage)
        {
            Lobby.BatteryBank batteryBank = new(jolateRating);
            batteryBank.GetMaxJoltage(12).Should().Be(expectedMaxJoltage);
        }

        [Theory]
        [InlineData("Day3/Example.txt", 357, 2)]
        [InlineData("Day3/Input.txt", 16854, 2)]
        [InlineData("Day3/Example.txt", 3121910778619, 12)]
        [InlineData("Day3/Input.txt", 167526011932478, 12)]
        public void MaxJoltageOfAllBanksIsExpectedValue(
            string path,
            long expectedJoltage,
            int usedBatteries
        )
        {
            var joltageRatingsOfEachBank = File.ReadAllLines(Path.GetFullPath(path));

            long result = 0;
            foreach (var rating in joltageRatingsOfEachBank)
            {
                Lobby.BatteryBank batteryBank = new(rating);
                result += batteryBank.GetMaxJoltage(usedBatteries);
            }

            result.Should().Be(expectedJoltage);
        }
    }
}
