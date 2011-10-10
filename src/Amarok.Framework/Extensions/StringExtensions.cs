using System;
using System.Text.RegularExpressions;
using Amarok.Framework.Contracts;

namespace Amarok.Framework.Extensions
{
    public static class StringExtensions
    {
        public static bool IsGuid(this string value)
        {
            Ensure.That(value).HasValue().Otherwise.Throw<ArgumentException>("Argument is mandatory.");
            //
            string guidPattern = @"^(\{{0,1}([0-9a-fA-F]){8}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){12}\}{0,1})$";
            return new Regex(guidPattern).IsMatch(value);
        }
    }
}
