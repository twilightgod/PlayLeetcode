using System;

namespace _0365
{
    public class Solution
    {
        public bool CanMeasureWater(int x, int y, int z)
        {
            return z == 0 || z <= x + y && z % GCD(x, y) == 0;
        }

        private int GCD(int x, int y)
        {
            while (y != 0)
            {
                var t = x % y;
                x = y;
                y = t;
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
