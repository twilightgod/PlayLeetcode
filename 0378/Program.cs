using System;

namespace _0378
{
    public class Solution
    {
        public int KthSmallest(int[,] matrix, int k)
        {
            var n = matrix.GetLength(0);
            var l = matrix[0, 0];
            var r = matrix[n - 1, n - 1];

            // binary search the answer
            while (l < r)
            {
                var m = l + (r - l) / 2;

                if (GetSmallerCount(matrix, n, m) >= k)
                {
                    r = m;
                }
                else
                {
                    l = m + 1;
                }
            }
            
            return l;
        }

        private int GetSmallerCount(int[,] matrix, int n, int target)
        {
            var j = n - 1;
            var cnt = 0;
            for (var i = 0; i < n; ++i)
            {
                while (matrix[i, j] > target)
                {
                    if (--j == -1)
                    {
                        return cnt;
                    }
                }
                cnt += (j + 1);
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
