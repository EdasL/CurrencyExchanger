using System;
using System.Text.RegularExpressions;

namespace CurrencyExchange
{
    public class RegexLib
    {
        private const string positiveFloatPattern = @"^[0-9]{1}[0-9]*(?:\.[0-9]*)?$";
        private const string currencyPattern = @"^[A-Z]{3}/[A-Z]{3}$";

        public static bool IsNumberValid(string text)
        {
            return Regex.IsMatch(text, positiveFloatPattern);
        }

        public static bool IsCurrencyValid(string text)
        {
            return Regex.IsMatch(text, currencyPattern);
        }
    }
}
