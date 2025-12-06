namespace Advent2025.Day2
{
    public static class GiftShop
    {
        public static bool IsValidId(long value, bool onlyUseTwoGroups)
        {
            var id = value.ToString();

            var currentSplitAmount = onlyUseTwoGroups ? 2 : id.Length;

            while (currentSplitAmount > 1)
            {
                if (IsInvalidIdPossibleWhenSplitIn(currentSplitAmount, id))
                {
                    if (onlyUseTwoGroups)
                    {
                        return true;
                    }
                    currentSplitAmount--;
                    continue;
                }

                if (!SplitIntoGroupsAndCheckIfValid(id, currentSplitAmount))
                {
                    return false;
                }

                currentSplitAmount--;
            }
            return true;
        }

        private static bool SplitIntoGroupsAndCheckIfValid(string id, int splitLength)
        {
            string previousGroup = id.Substring(0, id.Length / splitLength);

            for (int i = 1; i < splitLength; i++)
            {
                string nextGroup = id.Substring(
                    i * (id.Length / splitLength),
                    id.Length / splitLength
                );

                if (previousGroup != nextGroup)
                {
                    return true;
                }
                previousGroup = nextGroup;
            }
            return false;
        }

        private static bool IsInvalidIdPossibleWhenSplitIn(int numberOfGroups, string id)
        {
            return id.Length % numberOfGroups != 0;
        }
    }
}
