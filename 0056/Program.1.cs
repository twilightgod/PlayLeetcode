using System;
using System.Collections.Generic;
using System.Linq;

namespace _0056_1
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
            var answer = new List<Interval>();

            if (intervals.Count == 0)
            {
                return answer;
            }

            var events = new List<(int x, bool type)>();
            foreach (var interval in intervals)
            {
                events.Add((interval.start, false));
                events.Add((interval.end, true));
            }

            events.Sort();
            var start = -1;
            var level = 0;
            foreach (var e in events)
            {
                if (e.type)
                {
                    if (--level == 0)
                    {
                        answer.Add(new Interval(start, e.x));
                    }
                }
                else
                {
                    if (level++ == 0)
                    {
                        start = e.x;
                    }
                }
            }

            return answer;
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
