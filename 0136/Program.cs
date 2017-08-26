using System;

namespace _0136
{
    public class Solution
    {
        public int SingleNumber(int[] nums)
        {
            var ans = 0;
            foreach (var num in nums)
            {
                ans ^= num;
            }

            return ans;
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
