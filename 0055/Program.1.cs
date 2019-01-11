using System;
using System.Collections.Generic;

namespace _0055_1
{
    public class Solution
    {
        public bool CanJump(int[] nums)
        {
            //Greedy, maintain the farest index we can reach

            var n = nums.Length;
            var maxreach = 0;
            
            for (var i = 0; i <= maxreach && maxreach < n - 1; ++i)
            {
                var maxreach_i = Math.Min(i + nums[i], n - 1);
                maxreach = Math.Max(maxreach, maxreach_i);
            }

            return maxreach == n - 1;
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
