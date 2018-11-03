using System;
using System.Collections.Generic;
using System.Linq;

namespace _0862_1
{
    public class Solution
    {
        public int ShortestSubarray(int[] A, int K)
        {
            if (A == null || A.Length == 0)
            {
                return -1;
            }

            var answer = Int32.MaxValue;

            // padding
            var n = A.Length;
            var sum = new int[n + 1];
            sum[0] = 0;
            for (var i = 1; i <= n; ++i)
            {
                sum[i] = sum[i - 1] + A[i - 1];
            }

            // index queue, keep sum[idx] increasing
            // for sum, the smaller, the better
            // so if sum[i] is smaller than last one, just remove last one before inserting
            // check sum[i] - first in q >= K, then it's a new answer (needs line36 check to remove worse indexes), and first one will not be used in the future
            // since [first in q, i] is shorter than [first in q, i + 1]
            var q = new LinkedList<int>();
            q.AddLast(0);

            for (var i = 1; i <= n; ++i)
            {
                if (answer != Int32.MaxValue && i - q.First.Value >= answer)
                {
                    q.RemoveFirst();
                }

                while (q.Count > 0 && sum[i] - sum[q.First.Value] >= K)
                {
                    answer = i - q.First.Value;
                    q.RemoveFirst();
                }

                while (q.Count > 0 && sum[q.Last.Value] >= sum[i])
                {
                    q.RemoveLast();
                }
                q.AddLast(i);
            }

            return answer == Int32.MaxValue ? -1 : answer;
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
