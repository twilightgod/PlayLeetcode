using System;
using System.Collections.Generic;

namespace _0376
{
    public class Solution
    {
        public int WiggleMaxLength(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            
            var diff = new List<int>();
            var n = nums.Length;

            for (int i = 1; i < n; ++i)
            {
                diff.Add(nums[i] - nums[i - 1]);
            }

            var poslen = 0;
            var neglen = 0;

            foreach (var a in diff)
            {
                if (a == 0)
                {
                    continue;
                }

                if (a > 0)
                {
                    poslen = neglen + 1;
                }

                if (a < 0)
                {
                    neglen = poslen + 1;
                }
            }

            return Math.Max(poslen, neglen) + 1;
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
