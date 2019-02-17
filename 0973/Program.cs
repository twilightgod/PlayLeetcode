using System;
using System.Collections.Generic;

namespace _0973
{
    public class Solution
    {
        public int[][] KClosest(int[][] points, int K)
        {
            var answer = new int[K][];
            var n = points.Length;
            var dist = new List<(int, int)>(n);
            for (var i = 0; i < n; ++i)
            {
                dist.Add((points[i][0] * points[i][0] + points[i][1] * points[i][1], i));
            }
            dist.Sort();
            for (var i = 0; i < K; ++i)
            {
                var idx = dist[i].Item2;
                answer[i] = new int[]{points[idx][0], points[idx][1]};
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
