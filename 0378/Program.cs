using System;

namespace _0378
{
    public class Solution
    {
        public int KthSmallest(int[,] matrix, int k)
        {
            var n = matrix.GetLength(0);
            var l = Int32.MaxValue;
            var r = Int32.MinValue;

            for (var i = 0; i < n; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    l = Math.Min(l, matrix[i, j]);
                    r = Math.Max(r + 1, matrix[i, j]);
                }
            }

            while (l < r)
            {
                var m = l + (r - l) / 2;
                var counter = 0;
                for (var i = 0; i < n; ++i)
                {
                    counter += upper_bound(matrix, n, i, m);
                }

                if (counter >= k)
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

        private int upper_bound(int[,] matrix, int n, int i, int target)
        {
            var l = 0;
            var r = n;

            while (l < r)
            {
                var m = l + (r - l) / 2;
                if (matrix[i, m] > target)
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
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
