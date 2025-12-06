namespace Advent2025.Day2
{
    public static class GiftShop
    {
        public static bool IsValidId(long id)
        {
            //PalindromScheme
            //<Number><Number>
            //or
            //<Number><Digit><Number>

            var number = id.ToString();

            if (number.Length % 2 == 1)
            {
                return true;
            }
            var digitIndex = number.Length - 1;
            if (number.Length % 2 == 0)
            {
                while (digitIndex > number.Length / 2 - 1)
                {
                    if (number[digitIndex] != number[digitIndex - (number.Length / 2)])
                        return true;

                    digitIndex--;
                }
            }
            return false;
        }
    }
}
