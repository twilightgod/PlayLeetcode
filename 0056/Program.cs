using System;
using System.Collections.Generic;
using System.Linq;

namespace _0056
{
    /**
 * Definition for an interval. */
    public class Interval
    {
        public int start;
        public int end;
        public Interval() { start = 0; end = 0; }
        public Interval(int s, int e) { start = s; end = e; }
    }

    public class Solution
    {
        public IList<Interval> Merge(IList<Interval> intervals)
        {
            var ans = new List<Interval>();

            if (intervals.Count == 0)
            {
                return ans;
            }

            var intervallist = intervals.ToList();
            intervallist.Sort((x, y) => x.start == y.start ? x.end.CompareTo(y.end) : x.start.CompareTo(y.start));

            var currentinterval = intervallist[0];

            for (var i = 1; i < intervallist.Count; ++i)
            {
                if (intervallist[i].start > currentinterval.end)
                {
                    ans.Add(currentinterval);
                    currentinterval = intervallist[i];
                }
                else
                {
                    currentinterval.end = Math.Max(currentinterval.end, intervallist[i].end);
                }
            }

            ans.Add(currentinterval);

            return ans;
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
