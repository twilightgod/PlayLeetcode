using System;

namespace _0750
{
    public class Solution
    {
        public int CountCornerRectangles(int[,] grid)
        {
            var m = grid.GetLength(0);
            var n = grid.GetLength(1);
            // f[i, j] means the count of rows with both ith column and jth column are 1
            var f = new int[n, n];
            var answer = 0;
            for (var i = 0; i < m; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    if (grid[i, j] == 1)
                    {
                        for (var k = j + 1; k < n; ++k)
                        {
                            if (grid[i, k] == 1)
                            {
                                answer += f[j, k];
                                f[j, k]++;
                            }
                        }
                    }
                }
            }
            return answer;
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
