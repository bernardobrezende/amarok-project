using System.Globalization;
using System.Threading;

namespace Amarok.Framework.Extensions
{
    public static class DecimalExtensions
    {
        /// <summary>
        /// Parse the decimal to string using the informed number of decimal places using the current thread's number separator.
        /// </summary>
        /// <param name="input">Decimal value to parse.</param>
        /// <param name="decimalPlaces">The number of decimal places to consider.</param>
        /// <returns>A string with the specific number of decimal places. E.g: "48.50" for 2 places or "48.503" for 3 places.</returns>
        public static string ToString(this decimal input, int decimalPlaces)
        {
            string numberSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            return Substringify(input.ToString(), numberSeparator, decimalPlaces);
        }

        /// <summary>
        /// Parse the decimal to string using the informed number of decimal places and the informed culture.
        /// </summary>
        /// <param name="input">Decimal value to parse.</param>
        /// <param name="decimalPlaces">The number of decimal places to consider.</param>
        /// <param name="culture">The culture to parse the string.</param>
        /// <returns>A string with the specific number of decimal places and number separator. E.g: 48.50 for "." or 48,50 for "," and 2 places</returns>
        public static string ToString(this decimal input, int decimalPlaces, CultureInfo culture)
        {
            string numberSeparator = culture.NumberFormat.NumberDecimalSeparator;
            string result = input.ToString(culture);
            //
            return Substringify(result, numberSeparator, decimalPlaces);
        }

        #region Private Methods

        /// <summary>
        /// Gets the substring using the given decimal places and number separator.
        /// </summary>
        /// <param name="formattedDecimal">Decimal parsed to a specific culture.</param>
        /// <param name="numberSeparator">The number separator.</param>
        /// <param name="decimalPlaces">The number of decimal places to consider.</param>
        /// <returns>A string with the specific number of decimal places and number separator. E.g: 48.50 for "." or 48,50 for "," and 2 places</returns>
        private static string Substringify(string formattedDecimal, string numberSeparator, int decimalPlaces)
        {
            int endCut = formattedDecimal.LastIndexOf(numberSeparator) + decimalPlaces;
            // Pre-incrementing endCut because the 0-based index
            endCut = decimalPlaces > 0 ? ++endCut : formattedDecimal.IndexOf(numberSeparator);            
            return formattedDecimal.Substring(0, endCut);
        }

        #endregion
    }
}
