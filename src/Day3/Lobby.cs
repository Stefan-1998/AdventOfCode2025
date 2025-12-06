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

            public int GetMaxJoltageFromTwoBatteries()
            {
                var batteryRatings = JoltageRating;
                var firstBattery = batteryRatings[0..(batteryRatings.Length - 1)].ToList().Max();

                var positionOfFirstBattery = batteryRatings.ToList().IndexOf(firstBattery);

                var secondBattery = batteryRatings[(positionOfFirstBattery + 1)..].Max();
                return int.Parse(firstBattery.ToString() + secondBattery.ToString());
            }
        }
    }
}
