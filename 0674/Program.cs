using System;

namespace _0674
{
    public class Solution
    {
        public int FindLengthOfLCIS(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }

            var best = 1;
            var counter = 1;
            for (var i = 1; i < nums.Length; ++i)
            {
                if (nums[i] > nums[i - 1])
                {
                    counter++;
                    best = Math.Max(best, counter);
                }
                else
                {
                    counter = 1;
                }
            }

            return best;
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
