using System;

namespace _0801
{
    public class Solution
    {
        public int MinSwap(int[] A, int[] B)
        {
            var n = A.Length;
            // f[i, 0] means the cost so far if we don't swap i-th
            // f[i, 1] means the cost so far if we swap i-th
            var f = new int[n, 2];
            f[0, 0] = 0;
            f[0, 1] = 1;
            for (var i = 1; i < n; ++i)
            {
                f[i, 0] = Int32.MaxValue;
                f[i, 1] = Int32.MaxValue;
                if (A[i] > A[i - 1] && B[i] > B[i - 1])
                {
                    f[i, 0] = f[i - 1, 0];
                    f[i, 1] = f[i - 1, 1] + 1;
                }
                if (A[i] > B[i - 1] && B[i] > A[i - 1])
                {
                    f[i, 0] = Math.Min(f[i, 0], f[i - 1, 1]);
                    f[i, 1] = Math.Min(f[i, 1], f[i - 1, 0] + 1);
                }
            }
            return Math.Min(f[n - 1, 0], f[n - 1, 1]);
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
