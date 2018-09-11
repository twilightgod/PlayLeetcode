using System;

namespace _0365
{
    public class Solution
    {
        public bool CanMeasureWater(int x, int y, int z)
        {
            if (x == 0)
            {
                return z == 0 || y == z;
            }
            if (y == 0)
            {
                return z == 0 || x == z;
            }
            var g = GCD(x, y);
            return z >= 0 && z <= x + y && z % g == 0;
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
