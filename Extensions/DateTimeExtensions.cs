using System;

namespace AddoSamples.Extensions
{
    public static class DateTimeExtensions
    {
        public static string AddoDate(this DateTime src)
        {
            var milliseconds = new DateTimeOffset(src).ToUnixTimeMilliseconds();
            return string.Format("/Date({0})/", milliseconds);
        }
    }
}