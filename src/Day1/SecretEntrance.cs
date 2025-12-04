namespace Advent2025.Day1
{
    public class SecretEntrance
    {
        public class Diallock()
        {
            public enum Direction
            {
                Left,
                Right,
            }

            public long DialNumber = 50;
            public long amountOfZerosStoppedAt = 0;
            public long amountOfZerosPassed = 0;

            public void TurnLock(string dialInstruction)
            {
                Direction direction = dialInstruction[0] == 'L' ? Direction.Left : Direction.Right;
                var dialing = long.Parse(dialInstruction[1..]);

                dialing = NormalizeDialNumber(dialing);
                if (dialing <= 0)
                {
                    return;
                }

                MoveDial(dialing, direction);

                if (IsStoppedAtZero())
                {
                    DialNumber = DialNumber % 100;
                    amountOfZerosStoppedAt++;
                }
            }

            private long NormalizeDialNumber(long dialClicks)
            {
                while (dialClicks > 100)
                {
                    dialClicks = dialClicks - 100;
                    amountOfZerosPassed++;
                }
                return dialClicks;
            }

            private void MoveDial(long dialClicks, Direction direction)
            {
                if (direction == Direction.Right)
                {
                    if (DialNumber + dialClicks >= 100)
                        amountOfZerosPassed++;

                    DialNumber += dialClicks;
                    if (DialNumber > 100)
                    {
                        DialNumber = DialNumber - 100;
                    }
                }
                else
                {
                    if (DialNumber != 0 && DialNumber - dialClicks <= 0)
                        amountOfZerosPassed++;

                    DialNumber -= dialClicks;

                    if (DialNumber <= 0)
                    {
                        DialNumber = 100 - Math.Abs(DialNumber);
                    }
                    if (DialNumber == 100)
                    {
                        DialNumber = 0;
                    }
                }
            }

            private bool IsStoppedAtZero()
            {
                return DialNumber % 100 == 0;
            }
        }
    }
}
