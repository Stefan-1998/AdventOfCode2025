namespace Advent2025.Day5
{
    public class Cafeteria
    {
        public class InventoryManagementSystem
        {
            public List<Func<long, bool>> FreshNessRules;
            public List<long> Products;

            public InventoryManagementSystem(string[] input)
            {
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
                    }
                    else if (!string.IsNullOrEmpty(line))
                    {
                        Products.Add(long.Parse(line));
                    }
                }
            }
        }
    }
}
