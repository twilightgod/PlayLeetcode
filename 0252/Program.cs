using System;

namespace _0252
{

    public class Interval
    {
        public int start;
        public int end;
        public Interval() { start = 0; end = 0; }
        public Interval(int s, int e) { start = s; end = e; }
    }

    public class Solution
    {
        public bool CanAttendMeetings(Interval[] intervals)
        {
            if (intervals.Length == 0)
            {
                return true;
            }

            Array.Sort(intervals, (x, y) => {
                if (x.start == y.start)
                {
                    return x.end - y.end;
                }
                else
                {
                    return x.start - y.start;
                }
                });

            var lastMeeting = intervals[0];
            for (var i = 1; i < intervals.Length; ++i)
            {
                if (intervals[i].start < lastMeeting.end)
                {
                    return false;
                }
                lastMeeting = intervals[i];
            }

            return true;
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
