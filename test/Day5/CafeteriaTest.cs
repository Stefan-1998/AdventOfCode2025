using FluentAssertions;

namespace Advent2025.Day5.Test
{
    public class CafeteriaTest()
    {
        [Theory]
        [InlineData("Day5/Example.txt", 3)]
        [InlineData("Day5/Input.txt", 739)]
        public void CheckIfNumberOfFreshFoodIsCorrect(string path, int expectation)
        {
            var input = File.ReadAllLines(path);

            Cafeteria.InventoryManagementSystem system = new(input);

            long counter = 0;
            foreach (var product in system.Products)
            {
                foreach (var rule in system.FreshNessRules)
                {
                    if (rule.Invoke(product))
                    {
                        counter++;
                        break;
                    }
                }
            }
            counter.Should().Be(expectation);
        }

        [Theory]
        [InlineData("Day5/Example.txt", 14)]
        [InlineData("Day5/Input.txt", 344486348901788)]
        public void CheckIfRuleRangeIsCorrect(string path, long expectation)
        {
            var input = File.ReadAllLines(path);

            Cafeteria.InventoryManagementSystem system = new(input);
            system.RuleRange.Should().Be(expectation);
        }
    }
}
