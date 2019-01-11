using System;
using System.Collections.Generic;

namespace _0045_1
{
    public class Solution
    {
        public int Jump(int[] nums)
        {
            //Greedy, it's a special BFS, since steps will be non-descing

            var n = nums.Length;
            var maxreach = 0;
            var step = new int[n];

            for (var i = 0; i <= maxreach && maxreach < n - 1; ++i)
            {
                var maxreach_i = Math.Min(i + nums[i], n - 1);
                for (var j = maxreach + 1; j <= maxreach_i; ++j)
                {
                    step[j] = step[i] + 1;
                }
                maxreach = Math.Max(maxreach, maxreach_i);
            }

            return step[n - 1];
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
