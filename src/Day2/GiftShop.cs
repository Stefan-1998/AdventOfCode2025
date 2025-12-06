namespace Advent2025.Day2
{
    public static class GiftShop
    {
        public static bool IsValidId(long id)
        {
            //PalindromScheme
            //<Number><Number>
            //or
            //<Number><Digit><Number> valid CodeWord

            var number = id.ToString();

            if (number.Length % 2 == 1)
            {
                return true;
            }

            var firstPart = number.Substring(0, number.Length / 2);
            var secondPart = number.Substring(number.Length / 2);

            return firstPart != secondPart;
        }
    }
}
