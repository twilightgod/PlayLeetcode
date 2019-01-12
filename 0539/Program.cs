using System;
using System.Collections.Generic;
using System.Linq;

namespace _0539
{
    public class Solution
    {
        public int FindMinDifference(IList<string> timePoints)
        {
            if (timePoints.Count < 2)
            {
                return 0;
            }

            var minutes = new List<int>();
            foreach(var time in timePoints)
            {
                var strs = time.Split(':');
                var minute = Int32.Parse(strs[0]) * 60 + Int32.Parse(strs[1]);
                minutes.Add(minute);
                minutes.Add(minute + 1440);
            }

            minutes.Sort();
            
            var best = Int32.MaxValue;
            for (var i = 0; i < minutes.Count - 1; ++i)
            {
                best = Math.Min(best, minutes[i + 1] - minutes[i]);
            }

            return best;
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
