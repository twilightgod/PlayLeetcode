using System;
using System.Collections.Generic;
using System.Linq;

namespace _0681_1
{
    // brute force
    public class Solution
    {
        public string NextClosestTime(string time)
        {
            if (string.IsNullOrEmpty(time))
            {
                return time;
            }

            var digiSet = new HashSet<int>();
            var bestStr = time;
            var bestGap = 2000;

            digiSet.Add(time[0] - '0');
            digiSet.Add(time[1] - '0');
            digiSet.Add(time[3] - '0');
            digiSet.Add(time[4] - '0');

            var timeInt = ((time[0] - '0') * 10 + time[1] - '0') * 60 + (time[3] - '0') * 10 + time[4] - '0';

            foreach (var h1 in digiSet)
            {
                foreach (var h2 in digiSet)
                {
                    var hour = h1 * 10 + h2;
                    if (hour <= 23)
                    {
                        foreach (var m1 in digiSet)
                        {
                            foreach (var m2 in digiSet)
                            {
                                var minute = m1 * 10 + m2;
                                if (minute <= 59)
                                {
                                    var nextTimeInt = hour * 60 + minute;
                                    var gap = (nextTimeInt + 1440 - timeInt) % 1440;
                                    if (gap > 0 && gap < bestGap)
                                    {
                                        bestGap = gap;
                                        bestStr = $"{hour:D2}:{minute:D2}";
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return bestStr;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
