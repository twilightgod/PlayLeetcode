using System;

namespace _0137
{
    public class Solution
    {
        public int SingleNumber(int[] nums)
        {
            var once = 0;
            var twice = 0;
            foreach (var num in nums)
            {
                once = once ^ num & ~twice;
                twice = twice ^ num & ~once;
            }
            return once;
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
