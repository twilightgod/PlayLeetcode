using System;
using System.Collections.Generic;

namespace _0746
{
    public class Solution
    {
        public int MinCostClimbingStairs(int[] cost)
        {
            var n = cost.Length;
            var f = new int[n + 1];
            for (var i = 2; i <= n; ++i)
            {
                f[i] = Math.Min(f[i - 1] + cost[i - 1], f[i - 2] + cost[i - 2]);
            }
            return f[n];
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
