using System;
using System.Globalization;

namespace Amarok.Framework.Extensions
{
    public static class DateTimeExtensions
    {
        public static int LastDayOfMonth(this DateTime date)
        {
            // Fixing next month's first day.
            DateTime nextMonthFirstDay = new DateTime(date.Year, date.AddMonths(1).Month, 1);
            return nextMonthFirstDay.AddDays(-1).Day;
        }

        public static string GetShortMonthName(this DateTime date, CultureInfo culture = default(CultureInfo))
        {
            return date.GetMonthName().Substring(0, 3);
        }

        public static string GetMonthName(this DateTime date, CultureInfo culture = default(CultureInfo))
        {
            string month;

            if (culture == default(CultureInfo))
                month = Convert.ToString(PortugueseMonths().GetValue(date.Month - 1));
            else
                month = Convert.ToString(UniversalMonths().GetValue(date.Month - 1));
            //
            return month;
        }

        public static int Quarter(this DateTime date)
        {
            return date.Month <= 3 ? 1 : date.Month <= 6 ? 2 : date.Month <= 9 ? 3 : 4;
        }

        public static bool EqualsByMonthAndYear(this DateTime date, DateTime otherDate)
        {
            return date.Year == otherDate.Year && date.Month == otherDate.Month;
        }

        private static string[] UniversalMonths()
        {
            return new[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        }

        private static string[] PortugueseMonths()
        {
            return new[] { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };
        }
    }
}