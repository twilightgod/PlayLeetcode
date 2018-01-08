using System;

namespace _0050
{
    public class Solution
    {
        public double MyPow(double x, int n)
        {
            long nn = n;

            if (nn < 0)
            {
                nn = -nn;
                x = 1 / x;
            }

            var acc = x;
            var ans = 1.0;

            while (nn != 0)
            {
                if (nn % 2 == 1)
                {
                    ans *= acc;
                }
                nn /= 2;
                acc *= acc;
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
