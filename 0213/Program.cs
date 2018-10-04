using System;

namespace _0213
{
    public class Solution
    {
        public int Rob(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }
            if (nums.Length == 1)
            {
                return nums[0];
            }

            return Math.Max(DP(nums, 0, nums.Length - 1), DP(nums, 1, nums.Length));
        }

        private int DP(int[] nums, int start, int end)
        {
            var f = new int[nums.Length];
            for (var i = start; i < end; ++i)
            {
                f[i] = Math.Max(GetF(f, start, i - 1), GetF(f, start, i - 2) + nums[i]);
            }

            return f[end - 1];
        }

        private int GetF(int[] f, int start, int i)
        {
            if (i < start)
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
