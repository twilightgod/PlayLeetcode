using System;
using System.Collections.Generic;

namespace _0498
{
    public class Solution
    {
        public int[] FindDiagonalOrder(int[,] matrix)
        {
            var n = matrix.GetLength(0);
            var m = matrix.GetLength(1);

            if (n == 0 || m == 0)
            {
                return new int[0];
            }

            var di = -1;
            var dj = 1;

            var i = 0;
            var j = 0;

            var ans = new List<int>();

            while (true)
            {
                ans.Add(matrix[i, j]);
                if (i == n - 1 && j == m - 1)
                {
                    break;
                }

                var newi = i + di;
                var newj = j + dj;
                var changed = false;

                if (newj >= m)
                {
                    newi = i + 1;
                    newj = j;
                    changed = true;
                }
                else if (newi < 0)
                {
                    newi = i;
                    newj = j + 1;
                    changed = true;
                }
                else if (newi >= n)
                {
                    newi = i;
                    newj = j + 1;
                    changed = true;
                }
                else if (newj < 0)
                {
                    newi = i + 1;
                    newj = j;
                    changed = true;
                }

                i = newi;
                j = newj;
                if (changed)
                {
                    di = -di;
                    dj = -dj;
                }
            }

            return ans.ToArray();
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
