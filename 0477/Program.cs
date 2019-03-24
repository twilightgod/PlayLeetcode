using System;

namespace _0477
{
    public class Solution
    {
        public int TotalHammingDistance(int[] nums)
        {
            var n = nums.Length;
            var answer = 0;
            var counts = new int[32];
            foreach (var num in nums)
            {
                var a = num;
                var idx = 0;
                while (a > 0)
                {
                    counts[idx++] += (a & 1);
                    a >>= 1;
                }
            }
            for (var i = 0; i < 32; ++i)
            {
                answer += counts[i] * (n - counts[i]);
            }
            return answer;
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
