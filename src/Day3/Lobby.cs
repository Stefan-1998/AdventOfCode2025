namespace Advent2025.Day3
{
    public class Lobby
    {
        public class BatteryBank
        {
            public readonly string JoltageRating;

            public BatteryBank(string joltageRatings)
            {
                JoltageRating = joltageRatings ?? throw new ArgumentNullException();
            }

            public long GetMaxJoltage(int batteriesToUse)
            {
                string remainingRatings = JoltageRating;
                string result = string.Empty;
                while (batteriesToUse > 0)
                {
                    char maxJoltage = remainingRatings[0..(^(batteriesToUse - 1))].Max();

                    int maxJoltagePosition = remainingRatings.IndexOf(maxJoltage);
                    remainingRatings = remainingRatings[(maxJoltagePosition + 1)..];
                    batteriesToUse--;

                    result += maxJoltage.ToString();
                }
                return long.Parse(result);
            }
        }
    }
}
