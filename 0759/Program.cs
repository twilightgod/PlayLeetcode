﻿using System;
using System.Collections.Generic;

namespace _0759
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
        public IList<Interval> EmployeeFreeTime(IList<IList<Interval>> schedule)
        {
            var events = new List<(int x, int type)>();
            foreach (var employee in schedule)
            {
                foreach (var interval in employee)
                {
                    events.Add((interval.start, 1));
                    events.Add((interval.end, -1));
                }
            }
            events.Sort();
            var lastIntervalEnd = -1;
            var counter = 0;
            var answers = new List<Interval>();
            foreach (var e in events)
            {
                counter += e.type;
                if (e.type == -1 && counter == 0)
                {
                    lastIntervalEnd = e.x;
                }
                else if (lastIntervalEnd != -1 && e.type == 1 && counter == 1)
                {
                    if (lastIntervalEnd != e.x)
                    {
                        answers.Add(new Interval(lastIntervalEnd, e.x));
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
