using System;
using System.Collections.Generic;

namespace _0356
{

    public class Solution
    {
        public bool IsReflected(int[,] points)
        {
            if (points == null || points.Length == 0)
            {
                return true;
            }
            var pointSet = new HashSet<(int, int)>();
            var n = points.GetLength(0);
            // duplicate points will result in wrong mid x value
            for (var i = 0; i < n; ++i)
            {
                pointSet.Add((points[i, 0], points[i, 1]));
            }
            var m = pointSet.Count;
            var totalx = 0;
            foreach (var entry in pointSet)
            {
                totalx += entry.Item1;
            }
            // pivot is totalx / m
            // for given x1, looking for x2, (x1 + x2) / 2 == pivot => x2 = totalx * 2 / m - x1
            if ((totalx * 2) % m != 0)
            {
                return false;
            }
            for (var i = 0; i < n; ++i)
            {
                if (!pointSet.Contains((totalx * 2 / m - points[i, 0], points[i, 1])))
                {
                    return false;
                }
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
