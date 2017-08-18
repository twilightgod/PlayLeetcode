using System;

namespace _70
{
    public class Solution
    {
        public static int[] fib = new int[100];

        public int ClimbStairs(int n)
        {
            if (fib[n] != 0)
            {
                return fib[n];
            }

            var ret = 0;

            if (n == 1)
            {
                ret = 1;
            }
            else if (n == 2)
            {
                ret = 2;
            }
            else
            {
                ret = ClimbStairs(n - 1) + ClimbStairs(n - 2);
            }

            fib[n] = ret;

            return ret;
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
