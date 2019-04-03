using System;
using System.Collections.Generic;

namespace _0986
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
        public Interval[] IntervalIntersection(Interval[] A, Interval[] B)
        {
            var answer = new List<Interval>();
            var lenA = A.Length;
            var lenB = B.Length;
            var i = 0;
            var j = 0;
            
            while (i < lenA && j < lenB)
            {
                var left = Math.Max(A[i].start, B[j].start);
                var right = Math.Min(A[i].end, B[j].end);
                if (left <= right)
                {
                    answer.Add(new Interval(left, right));
                }
                if (A[i].end < B[j].end)
                {
                    i++;
                }
                else
                {
                    j++;
                }
            }

            return answer.ToArray();
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
