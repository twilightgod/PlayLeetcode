using System;

namespace _0069
{
    public class Solution
    {
        public int MySqrt(int x)
        {
            long l = 0;
            long r = x + 1;

            while (l < r)
            {
                var m = l + (r - l) / 2;
                if (m * m > x)
                {
                    r = m;
                }
                else
                {
                    l = m + 1;
                }
            }

            return (int)(l - 1);
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
