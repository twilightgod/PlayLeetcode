using System;

namespace _0835
{
    class Program
    {
        public class Solution
        {
            public int LargestOverlap(int[][] A, int[][] B)
            {
                var answer = 0;
                var n = A.GetLength(0);
                var counter = new int[(2 * n) * (2 * n)];
                for (var ia = 0; ia < n; ++ia)
                {
                    for (var ja = 0; ja < n; ++ja)
                    {
                        if (A[ia][ja] == 1)
                        {
                            for (var ib = 0; ib < n; ++ib)
                            {
                                for (var jb = 0; jb < n; ++jb)
                                {
                                    if (B[ib][jb] == 1)
                                    {
                                        counter[(ia - ib + n - 1) * 2 * n + (ja - jb + n - 1)]++;
                                    }
                                }
                            }
                        }
                    }
                }
                foreach (var c in counter)
                {
                    answer = Math.Max(answer, c);
                }
                return answer;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
