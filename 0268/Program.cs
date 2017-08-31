using System;

namespace _0268
{
    public class Solution
    {
        public int MissingNumber(int[] nums)
        {
            int x = 0;
            for (var i = 1; i <= nums.Length; ++i)
            {
                x ^= i;
            }

            for (var i = 0; i < nums.Length; ++i)
            {
                x ^= nums[i];
            }

            return x;
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
