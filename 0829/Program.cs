using System;

namespace _0829
{
    public class Solution
    {
        public int ConsecutiveNumbersSum(int N)
        {
            // (a + b) / 2 * k == n, [a, b] has k numbers
            // b == a + k - 1
            // a = (2 * n - k * k + k) / (2 * k)
            var cnt = 0;
            for (var k = 1; 2 * N - k * k + k > 0; ++k)
            {
                if ((2 * N - k * k + k) % (2 * k) == 0)
                {
                    cnt++;
                }
            }
            return cnt;
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
