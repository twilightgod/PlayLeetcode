using System;

namespace _0034
{
    public class Solution
    {
        public int[] SearchRange(int[] nums, int target)
        {
            var lowerbound = nums.Length;
            var upperbound = -1;

            var l = 0;
            var r = nums.Length - 1;

            while (l <= r)
            {
                var m = (l + r) / 2;
                if (nums[m] == target)
                {
                    lowerbound = Math.Min(lowerbound, m);
                }
                if (nums[m] >= target)
                {
                    r = m - 1;
                }
                else
                {
                    l = m + 1;
                }
            }

            l = 0;
            r = nums.Length - 1;

            while (l <= r)
            {
                var m = (l + r) / 2;
                if (nums[m] == target)
                {
                    upperbound = Math.Max(upperbound, m);
                }
                if (nums[m] <= target)
                {
                    l = m + 1;
                }
                else
                {
                    r = m - 1;
                }
            }

            if (upperbound == -1)
            {
                lowerbound = -1;
            }

            return new int[]{lowerbound, upperbound};
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
