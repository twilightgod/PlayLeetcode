using System;

namespace _0396
{
    public class Solution
    {
        public int MaxRotateFunction(int[] A)
        {
            var n = A.Length;
            var sumall = 0;
            var sum = 0;

            for (var i = 0; i < n; ++i)
            {
                sumall += A[i];
                sum += i * A[i];
            }

            var best = sum;
            for (var i = n - 1; i >= 0; --i)
            {
                sum = sum + sumall - n * A[i];
                best = Math.Max(best, sum);
            }

            return best;
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
