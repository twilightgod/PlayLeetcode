using System;
using System.Collections.Generic;

namespace _0200
{
    public class Solution
    {
        public int NumIslands(char[,] grid)
        {
            if (grid == null)
            {
                return 0;
            }

            var ans = 0;
            var moves = new int[, ] {{1, 0}, {0, -1}, {-1, 0}, {0, 1}};
            var m = grid.GetLength(0);
            var n = grid.GetLength(1);

            for (var i = 0; i < m; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    if (grid[i, j] == '1')
                    {
                        ans++;

                        var q = new Queue<(int x, int y)>();
                        q.Enqueue((i, j));
                        while (q.Count > 0)
                        {
                            var (x, y) = q.Dequeue();
                            for (var k = 0; k < 4; ++k)
                            {
                                var nx = x + moves[k, 0];
                                var ny = y + moves[k, 1];
                                if (nx >= 0 && ny >= 0 && nx < m && ny < n && grid[nx, ny] == '1')
                                {
                                    grid[nx, ny] = '0';
                                    q.Enqueue((nx, ny));
                                }
                            }
                        }
                    }
                }
            }

            return ans;
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
