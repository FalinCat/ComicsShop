using System;

namespace Utilities
{
    public static class DateTimeRandom
    {
        private static Random gen = new Random();
        public static DateTime RandomDay()
        {
            DateTime start = new DateTime(1935, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }
    }
}
