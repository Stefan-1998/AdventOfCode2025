namespace Advent2025.Day1
{
    public class SecretEntrance
    {
        public class Diallock()
        {
            private long DialNumber = 50;
            public long amountOfZeros = 0;

            public void TurnLock(string dialInstruction)
            {
                bool turnLeft = dialInstruction.StartsWith("L");
                if (turnLeft)
                {
                    DialNumber -= long.Parse(dialInstruction[1..].ToString());
                }
                else
                {
                    DialNumber += long.Parse(dialInstruction[1..].ToString());
                }
                if (DialNumber % 100 == 0)
                {
                    amountOfZeros++;
                }
            }
        }
    }
}
