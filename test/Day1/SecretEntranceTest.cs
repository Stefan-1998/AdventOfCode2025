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
            diallock.amountOfZerosStoppedAt.Should().Be(expectedAmountOfZerosDialed);
        }

        [Theory]
        [InlineData("Day1/Example.txt", 6)]
        [InlineData("Day1/Input.txt", 6475)]
        public void InstructionsDialThroughTheExpectedAmountOfZeros(
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
            var amountOfZerosVisited = diallock.amountOfZerosPassed;
            amountOfZerosVisited.Should().Be(expectedAmountOfZerosDialed);
        }

        [Fact]
        public void DialingDownFrom0OnlyIncreasesPassedCounter()
        {
            SecretEntrance.Diallock diallock = new();
            diallock.DialNumber = 0;
            diallock.TurnLock("L60");
            diallock.amountOfZerosPassed.Should().Be(0);
            diallock.amountOfZerosStoppedAt.Should().Be(0);
        }

        [Fact]
        public void DialingOver100PassesZeroOnce()
        {
            SecretEntrance.Diallock diallock = new();
            diallock.DialNumber = 95;
            diallock.TurnLock("R60");
            diallock.amountOfZerosPassed.Should().Be(1);
            diallock.amountOfZerosStoppedAt.Should().Be(0);
        }

        [Fact]
        public void DialingUnder0PassesZeroOnce()
        {
            SecretEntrance.Diallock diallock = new();
            diallock.DialNumber = 25;
            diallock.TurnLock("L60");
            diallock.amountOfZerosPassed.Should().Be(1);
            diallock.amountOfZerosStoppedAt.Should().Be(0);
        }

        [Fact]
        public void DialingUp1000PassesZeroTenTimes()
        {
            SecretEntrance.Diallock diallock = new();
            diallock.TurnLock("R1000");
            diallock.amountOfZerosPassed.Should().Be(10);
            diallock.amountOfZerosStoppedAt.Should().Be(0);
        }

        [Fact]
        public void DialingDown1000PassesZeroTenTimes()
        {
            SecretEntrance.Diallock diallock = new();
            diallock.DialNumber = 0;
            diallock.TurnLock("L1000");
            diallock.amountOfZerosPassed.Should().Be(9);
            diallock.amountOfZerosStoppedAt.Should().Be(1);
        }

        [Fact]
        public void DialingDown1001PassesZeroTenTimes()
        {
            SecretEntrance.Diallock diallock = new();
            diallock.DialNumber = 0;
            diallock.TurnLock("L1001");
            diallock.amountOfZerosPassed.Should().Be(10);
            diallock.amountOfZerosStoppedAt.Should().Be(0);
            diallock.DialNumber = 99;
        }

        [Fact]
        public void DialingUp1001PassesZeroTenTimes()
        {
            SecretEntrance.Diallock diallock = new();
            diallock.DialNumber = 0;
            diallock.TurnLock("R1001");
            diallock.amountOfZerosPassed.Should().Be(10);
            diallock.amountOfZerosStoppedAt.Should().Be(0);
            diallock.DialNumber = 1;
        }

        [Fact]
        public void DialingDownFrom50a1000TimesPassesZeroTenTimes()
        {
            SecretEntrance.Diallock diallock = new();
            diallock.DialNumber = 50;
            diallock.TurnLock("L1000");
            diallock.amountOfZerosPassed.Should().Be(10);
            diallock.amountOfZerosStoppedAt.Should().Be(0);
        }
    }
}
