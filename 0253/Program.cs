using System;
using System.Collections.Generic;
using System.Linq;

namespace _0253
{

    public class Interval
    {
        public int start;
        public int end;
        public Interval() { start = 0; end = 0; }
        public Interval(int s, int e) { start = s; end = e; }
    }

    public class PriorityQueue<T>
    {
        SortedDictionary<T, int> dic = new SortedDictionary<T, int>();
        public int Count {get; private set;} = 0;

        public T PeekMin()
        {
            return dic.First().Key;
        }

        public void Push(T value)
        {
            if (dic.ContainsKey(value))
            {
                dic[value]++;
            }
            else
            {
                dic.Add(value, 1);
            }

            Count++;
        }

        public void Pop()
        {
            var kvp = dic.First();
            if (kvp.Value == 1)
            {
                dic.Remove(kvp.Key);
            }
            else
            {
                dic[kvp.Key] = kvp.Value - 1;
            }

            Count--;
        }
    }

    public class Solution
    {
        public int MinMeetingRooms(Interval[] intervals)
        {
            // the goal is to find out largest interval overlapping times at any moment
            // actually we don't need to keep start time and end time together for one specified interval
            // it's the same as asking for nested level for brackets ((()))
            var timeLines = new List<(int Time, int Value)>(intervals.Length << 1);

            foreach (var interval in intervals)
            {
                timeLines.Add((interval.start, 1));
                timeLines.Add((interval.end, -1));
            }

            // end event comes first when two events have the same time
            timeLines.Sort((x, y) =>
            {
                if (x.Time == y.Time)
                {
                    return x.Value - y.Value;
                }
                else
                {
                    return x.Time - y.Time;
                }
            });

            var ans = 0;
            var counter = 0;
            foreach (var timeLine in timeLines)
            {
                counter += timeLine.Value;
                ans = Math.Max(ans, counter);
            }

            return ans;
        }

        public int MinMeetingRooms_PQ(Interval[] intervals)
        {
            Array.Sort(intervals, (x, y) =>
            {
                if (x.start == y.start)
                {
                    return x.end - y.end;
                }
                else
                {
                    return x.start - y.start;
                }
            });

            // heap
            var lastMeetingTimes = new PriorityQueue<int>();

            for (var i = 0; i < intervals.Length; ++i)
            {
                if (i == 0)
                {
                    lastMeetingTimes.Push(intervals[i].end);
                }
                else
                {
                   var minLastMeetingTime = lastMeetingTimes.PeekMin();
                   if (minLastMeetingTime > intervals[i].start)
                   {
                       // add new room
                       lastMeetingTimes.Push(intervals[i].end);
                   }
                   else
                   {
                       // update entry
                       lastMeetingTimes.Pop();
                       lastMeetingTimes.Push(intervals[i].end);

                   }
                }
            }

            return lastMeetingTimes.Count;
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
