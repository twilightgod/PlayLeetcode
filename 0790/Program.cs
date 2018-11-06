using System;

namespace _0790
{
    public class Solution
    {
        public int NumTilings(int N)
        {
            // f[i, 0] means processing i-th column, only use half, what's the number of ways
            // f[i, 1] means processing i-th column, use full column, what's the number of ways
            var f = new int[N + 1, 2];
            var M = 1000000007;
            f[0, 1] = 1;
            for (var i = 1; i <= N; ++i)
            {
                f[i, 0] = (f[i - 1, 0] + (i >= 2 ? f[i - 2, 1] * 2 : 0) % M) % M;
                f[i, 1] = ((f[i - 1, 0] + f[i - 1, 1]) % M + (i >= 2 ? f[i - 2, 1] : 0)) % M;
            }
            return f[N, 1];
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
