using System;
using System.Collections.Generic;

namespace _0057
{
    /**
 * Definition for an interval.
 */
    public class Interval
    {
        public int start;
        public int end;
        public Interval() { start = 0; end = 0; }
        public Interval(int s, int e) { start = s; end = e; }
    }

    public class Solution
    {
        public IList<Interval> Insert(IList<Interval> intervals, Interval newInterval)
        {
            var events = new List<(int x, bool type)>();
            foreach (var interval in intervals)
            {
                events.Add((interval.start, false));
                events.Add((interval.end, true));
            }
            var newStartEvent = (newInterval.start, false);
            var newEndEvent = (newInterval.end, true);
            var pos = events.BinarySearch(newStartEvent);
            if (pos < 0)
            {
                pos = ~pos;
            }
            events.Insert(pos, newStartEvent);
            pos = events.BinarySearch(newEndEvent);
            if (pos < 0)
            {
                pos = ~pos;
            }
            events.Insert(pos, newEndEvent);
            var s = 0;
            var cnt = 0;
            var answers = new List<Interval>();
            foreach (var e in events)
            {
                if (e.type)
                {
                    if (--cnt == 0)
                    {
                        answers.Add(new Interval(s, e.x));
                    }
                }
                else
                {
                    if (cnt++ == 0)
                    {
                        s = e.x;
                    }
                }    
            }
            return answers;
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
