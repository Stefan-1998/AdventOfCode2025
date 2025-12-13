namespace Advent2025.Day5
{
    public static class Cafeteria
    {
        public class InventoryManagementSystem
        {
            public List<Func<long, bool>> FreshNessRules;
            public HashSet<(long LowerBound, long UpperBound)> Rules;
            public List<long> Products;
            public long RuleRange;

            public InventoryManagementSystem(string[] input)
            {
                Rules = new();

                Products = new();
                FreshNessRules = new();
                foreach (var line in input)
                {
                    if (line.Contains('-') && !string.IsNullOrEmpty(line))
                    {
                        var firstNumber = long.Parse(line.Split('-')[0]);
                        var secondNumber = long.Parse(line.Split('-')[1]);
                        FreshNessRules.Add(ingredientId =>
                            firstNumber <= ingredientId && ingredientId <= secondNumber
                        );
                        Rules.Add((LowerBound: firstNumber, UpperBound: secondNumber));
                    }
                    else if (!string.IsNullOrEmpty(line))
                    {
                        Products.Add(long.Parse(line));
                    }
                }

                RuleRange = 0;
                var orderedRules = Rules
                    .OrderBy(x => x.LowerBound)
                    .ThenBy(x => x.UpperBound)
                    .ToList();
                var currentLowerBound = orderedRules[0].LowerBound;
                var currentUpperBound = orderedRules[0].UpperBound;
                foreach (var rule in orderedRules.Skip(1))
                {
                    if (rule.UpperBound <= currentUpperBound)
                        continue;

                    if (rule.LowerBound > currentUpperBound + 1)
                    {
                        RuleRange += currentUpperBound - currentLowerBound + 1;
                        currentLowerBound = rule.LowerBound;
                    }
                    currentUpperBound = rule.UpperBound;
                }
                RuleRange += currentUpperBound - currentLowerBound + 1;
            }
        }
    }
}
