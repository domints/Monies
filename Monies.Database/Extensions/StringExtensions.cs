using System;
using System.Text.RegularExpressions;

namespace Monies.Database.Extensions
{
    public static class StringExtensions
    {
        public static string ToSnakeCase(this string input)
        {
            if (string.IsNullOrEmpty(input)) { return input; }

            var startUnderscores = Regex.Match(input, "^_+");
            return startUnderscores + Regex.Replace(input, "([a-z0-9])([A-Z])", "$1_$2").ToLower();
        }

        public static string B64Decode(this string input)
        {
            var bytes = Convert.FromBase64String(input);
            return System.Text.Encoding.UTF8.GetString(bytes);
        }

        public static string B64Encode(this string input)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(bytes);
        }
    }
}