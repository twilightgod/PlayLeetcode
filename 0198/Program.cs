using System;

namespace _0198
{
    public class Solution
    {
        public int Rob(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            var n = nums.Length;
            // max value scaning to ith house
            var f = new int[n];
            for (var i = 0; i < n; ++i)
            {
                // two options, 1. don't rob ith house  2.rob ith house
                f[i] = Math.Max(GetF(f, i - 1), GetF(f, i - 2) + nums[i]);
            }

            return f[n - 1];
        }

        private int GetF(int[] f, int i)
        {
            if (i < 0)
            {
                return 0;
            }
            else
            {
                return f[i];
            }
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
