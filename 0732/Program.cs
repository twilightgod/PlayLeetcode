using System;
using System.Collections.Generic;

namespace _0732
{
    public class MyCalendarThree
    {
        SortedDictionary<int, int> events = new SortedDictionary<int, int>(); 
        
        public MyCalendarThree()
        {

        }

        public int Book(int start, int end)
        {
            InsertMeeting(start, end);
            return OverlapLevel();
        }

        private void InsertMeeting(int start, int end)
        {
            if (!events.ContainsKey(start))
            {
                events.Add(start, 0);
            }
            events[start]++;

            if (!events.ContainsKey(end))
            {
                events.Add(end, 0);
            }
            events[end]--;
        }

        private void RemoveMeeting(int start, int end)
        {
            if (--events[start] == 0)
            {
                events.Remove(start);
            }
            if (++events[end] == 0)
            {
                events.Remove(end);
            }
        }

        private int OverlapLevel()
        {
            var counter = 0;
            var maxLevel = 0;

            foreach (var e in events.Values)
            {
                counter += e;
                maxLevel = Math.Max(maxLevel, counter);
            }

            return maxLevel;
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
