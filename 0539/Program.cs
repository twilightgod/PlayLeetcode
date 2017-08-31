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

            if (timePoints.GroupBy(x => x).Where(x => x.Count() > 1).Count() > 0)
            {
                return 0;
            }

            var minutes = new List<int>(timePoints.Count);
            foreach(var time in timePoints)
            {
                var strs = time.Split(':');
                minutes.Add(Int32.Parse(strs[0]) * 60 + Int32.Parse(strs[1]));
            }

            var best = Int32.MaxValue;
            for (var i = 0; i < minutes.Count; ++ i)
            {
                for (var j = i + 1; j < minutes.Count; ++j)
                {
                    best = Math.Min(
                        Math.Abs(Math.Abs(minutes[i] - minutes[j]) - 1440), 
                        Math.Abs(Math.Min(
                            best,
                            Math.Abs(minutes[i] - minutes[j]))));

                }
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
