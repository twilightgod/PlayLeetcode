using System;

namespace _0268
{
    public class Solution
    {
        public int MissingNumber(int[] nums)
        {
            int x = 0;
            for (var i = 0; i <= nums.Length; ++i)
            {
                x ^= i;
                if (i != nums.Length)
                {
                    x ^= nums[i];
                }
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
