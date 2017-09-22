using System;

namespace _0377
{
    public class Solution
    {
        public int CombinationSum4(int[] nums, int target)
        {
            var f = new int[target + 1];
            f[0] = 1;
            for (var i = 1; i <= target; ++i)
            {
                f[i] = 0;
                foreach (var num in nums)
                {
                    f[i] += i - num >= 0 ? f[i - num] : 0;
                }
            }

            return f[target];
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
