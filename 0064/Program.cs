using System;

namespace _0064
{
    public class Solution
    {
        public int MinPathSum(int[,] grid)
        {
            var m = grid.GetLength(0);
            var n = grid.GetLength(1);
            var f = new int[m, n];
            for (var i = 0; i < m; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    f[i, j] = grid[i, j];
                    if (i == 0)
                    {
                        if (j == 0)
                        {
                            // nothing
                        }
                        else
                        {
                            f[i, j] += f[i, j - 1];
                        }
                    }
                    else if (j == 0)
                    {
                        f[i, j] += f[i - 1, j];
                    }
                    else
                    {
                        f[i, j] += Math.Min(f[i, j - 1], f[i - 1, j]);
                    }
                }
            }

            return f[m - 1, n - 1];
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
