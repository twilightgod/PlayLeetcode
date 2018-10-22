using System;
using System.Collections.Generic;

namespace _0840
{
    public class Solution
    {
        public int NumMagicSquaresInside(int[][] grid)
        {
            if (grid == null || grid.Length == 0)
            {
                return 0;
            }

            var m = grid.Length;
            var n = grid[0].Length;
            var answer = 0;
            for (var i = 0; i <= m - 3; ++i)
            {
                for (var j = 0; j <= n - 3; ++j)
                {
                    if (IsValid(grid, i, j))
                    {
                        answer++;
                    }
                }
            }
            return answer;
        }

        private bool IsValid(int[][] grid, int x, int y)
        {
            Console.WriteLine(x + " " + y);
            var sum = new int[8];
            var digiset = new HashSet<int>();
            for (var i = 1; i <= 9; ++i)
            {
                digiset.Add(i);
            }
            for (var i = x; i <= x + 2; ++i)
            {
                for (var j = y; j <= y + 2; ++j)
                {
                    if (!digiset.Contains(grid[i][j]))
                    {
                        return false;
                    }
                    else
                    {
                        digiset.Remove(grid[i][j]);
                    }
                }
            }
            
            sum[0] = grid[x][y] + grid[x][y + 1] + grid[x][y + 2];
            sum[1] = grid[x + 1][y] + grid[x + 1][y + 1] + grid[x + 1][y + 2];
            sum[2] = grid[x + 2][y] + grid[x + 2][y + 1] + grid[x + 2][y + 2];
            sum[3] = grid[x][y] + grid[x + 1][y] + grid[x + 2][y];
            sum[4] = grid[x][y + 1] + grid[x + 1][y + 1] + grid[x + 2][y + 1];
            sum[5] = grid[x][y + 2] + grid[x + 1][y + 2] + grid[x + 2][y + 2];
            sum[6] = grid[x][y] + grid[x + 1][y + 1] + grid[x + 2][y + 2];
            sum[7] = grid[x][y + 2] + grid[x + 1][y + 1] + grid[x + 2][y];
            for (var i = 1; i < 8; ++i)
            {
                if (sum[i] != sum[0])
                {
                    return false;
                }
            }
            return true;
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
