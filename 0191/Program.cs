using System;

namespace _0191
{
    public class Solution
    {
        public int HammingWeight(uint n)
        {
            uint ans = 0;

            while(n > 0)
            {
                ans += n & 1;
                n >>= 1;
            }

            return (int)ans;
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
