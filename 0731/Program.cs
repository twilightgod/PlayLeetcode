using System;
using System.Collections.Generic;

namespace _0731
{
    public class Interval
    {
        public int Start;
        public int End;
    }

    public class MyCalendarTwo
    {
        List<Interval> meetings = new List<Interval>();
        List<Interval> overlaps = new List<Interval>();
        
        public MyCalendarTwo()
        {

        }

        public bool Book(int start, int end)
        {
            var meeting = new Interval() { Start = start, End = end};

            if (IsConflict(meeting))
            {
                return false;
            }
            else
            {
                InsertMeeting(meeting);            
                return true;
            }
        }

        private void InsertMeeting(Interval meeting)
        {
            foreach (var interval in meetings)
            {
                var overlapL = Math.Max(meeting.Start, interval.Start);
                var overlapR = Math.Min(meeting.End, interval.End);
                if (overlapL < overlapR)
                {
                    overlaps.Add(new Interval(){Start = overlapL, End = overlapR});
                }
            }
            meetings.Add(meeting);
        }

        private bool IsConflict(Interval meeting)
        {
            foreach (var interval in overlaps)
            {
                var overlapL = Math.Max(meeting.Start, interval.Start);
                var overlapR = Math.Min(meeting.End, interval.End);
                if (overlapL < overlapR)
                {
                    return true;
                }
            }
            return false;
        }
    }

    /**
     * Your MyCalendarTwo object will be instantiated and called as such:
     * MyCalendarTwo obj = new MyCalendarTwo();
     * bool param_1 = obj.Book(start,end);
     */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
