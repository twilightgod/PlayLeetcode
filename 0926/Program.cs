using System;

namespace _0926
{
    public class Solution
    {
        public int MinFlipsMonoIncr(string S)
        {
            // padding
            S = "|" + S;
            var n = S.Length;
            // f[i, j] means in sequence [0, i], i-th is j (0 or 1), what's the min flip times
            var f = new int[n, 2];
            for (var i = 1; i < n; ++i)
            {
                if (S[i] == '0')
                {
                    f[i, 0] = f[i - 1, 0];
                    f[i, 1] = Math.Min(f[i - 1, 0], f[i - 1, 1]) + 1;
                }
                else
                {
                    f[i, 0] = f[i - 1, 0] + 1;
                    f[i, 1] = Math.Min(f[i - 1, 0], f[i - 1, 1]);
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
