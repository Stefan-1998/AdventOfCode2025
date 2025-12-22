
namespace Advent2025.Day7
{
    public static class Laboratories
    {
        public static long GetAmountOfSplits(string[] input)
        {
            var sPosition = input[0].IndexOf('S');
            HashSet<int> rays = [];
            rays.Add(sPosition );
            int splitCounter = 0;

            for (int i = 1; i < input.Length; i++)
            {
                foreach (int index in AllIndexesOf(input[i], '^'))
                {
                    if (rays.Contains(index))
                    {
                        rays.Remove(index);
                        rays.Add(index + 1);
                        rays.Add(index - 1);
                        splitCounter++;
                    }
                }
            }

            return splitCounter;
        }
        private static IEnumerable<int> AllIndexesOf(string str, char character)
        {
            int minIndex = str.IndexOf(character);
            while (minIndex != -1)
            {
                yield return minIndex;
                minIndex = str.IndexOf(character, minIndex + 1);
            }
        }
    }
}
