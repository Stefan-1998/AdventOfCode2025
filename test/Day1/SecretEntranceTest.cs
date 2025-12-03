using FluentAssertions;

namespace Advent2025.Day1.Test
{
    public class SecretEntranceTest()
    {
        [Theory]
        [InlineData("Day1/Example.txt", 3)]
        [InlineData("Day1/Input.txt", 1084)]
        public void InstructionsDialTheExpectedAmountOfZeros(
            string path,
            long expectedAmountOfZerosDialed
        )
        {
            var instructions = File.ReadAllLines(Path.GetFullPath(path));
            SecretEntrance.Diallock diallock = new();
            foreach (string instruction in instructions)
            {
                diallock.TurnLock(instruction);
            }
            diallock.amountOfZeros.Should().Be(expectedAmountOfZerosDialed);
        }
    }
}
