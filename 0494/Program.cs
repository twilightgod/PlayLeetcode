using System;
using System.Collections.Generic;

namespace _0494
{
    public class Solution
    {
        public int FindTargetSumWays(int[] nums, int S)
        {
            var preSum = new Dictionary<int, int>();
            preSum[0] = 1;
            foreach (var num in nums)
            {
                var curSum = new Dictionary<int, int>();
                foreach (var kvp in preSum)
                {
                    curSum[kvp.Key + num] = curSum.GetValueOrDefault(kvp.Key + num) + kvp.Value;
                    curSum[kvp.Key - num] = curSum.GetValueOrDefault(kvp.Key - num) + kvp.Value;
                }
                preSum = curSum;
            }
            return preSum.GetValueOrDefault(S);
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
