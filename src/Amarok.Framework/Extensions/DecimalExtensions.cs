using System.Globalization;
using System.Threading;

namespace Amarok.Framework.Extensions
{
    public static class DecimalExtensions
    {
        public static string ToString(this decimal input, int decimalCases)
        {
            string numberSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            int endCut = input.ToString().LastIndexOf(numberSeparator) + decimalCases + 1;
            return input.ToString().Substring(0, endCut);
        }

        public static string ToString(this decimal input, int decimalCases, CultureInfo culture)
        {
            string numberSeparator = culture.NumberFormat.NumberDecimalSeparator;
            string result = input.ToString(culture);
            int endCut = result.LastIndexOf(numberSeparator) + decimalCases + 1;
            return result.Substring(0, endCut);
        }
    }
}
