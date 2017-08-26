using System;

namespace _0461
{
    public class Solution
    {
        public int HammingDistance(int x, int y)
        {
            var ans = 0;
            var diff = x ^ y;
            
            while (diff > 0)
            {
                ans += diff % 2;
                diff /= 2;
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
