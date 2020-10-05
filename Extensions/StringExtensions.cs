using System;
using System.Text.RegularExpressions;

namespace AddoSamples.Extensions
{
    public static class StringExtensions
    {
        static readonly Regex _convertDates = new Regex(@"(\\\/Date\()(\d+)(\)\\\/)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        static readonly DateTime _origo = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        public static string ConvertDatesFromAddo(this string src)
        {
            if (string.IsNullOrWhiteSpace(src))
            {
                return string.Empty;
            }

            return _convertDates.Replace(src, new MatchEvaluator(MillisToDate));
        }

        static string MillisToDate(Match match)
        {
            var matchValue = long.Parse(match.Groups[2].ToString());
            var dateTime = _origo.AddMilliseconds(matchValue);
            return dateTime.ToString("yyyy-MM-ddThh:mm:ssZ");
        }
    }
}