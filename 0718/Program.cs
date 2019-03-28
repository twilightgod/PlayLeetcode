using System;

namespace _0718
{
    public class Solution
    {
        public int FindLength(int[] A, int[] B)
        {
            var lenA = A.Length;
            var lenB = B.Length;
            var f = new int[lenA + 1, lenB + 1];
            var best = 0;

            for (var i = lenA - 1; i >= 0; --i)
            {
                for (var j = lenB - 1; j >= 0; --j)
                {
                    if (A[i] == B[j])
                    {
                        f[i, j] = f[i + 1, j + 1] + 1;
                    }
                    best = Math.Max(best, f[i, j]);
                }
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
