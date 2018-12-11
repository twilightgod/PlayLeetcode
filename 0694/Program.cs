using System;
using System.Collections.Generic;
using System.Text;

namespace _0694
{
    public class Solution
    {
        public int NumDistinctIslands(int[,] grid)
        {
            var m = grid.GetLength(0);
            var n = grid.GetLength(1);
            var islands = new HashSet<string>();
            var visited = new HashSet<(int, int)>();
            for (var i = 0; i < m; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    if (grid[i, j] == 1 && !visited.Contains((i, j)))
                    {
                        var sb = new StringBuilder();
                        visited.Add((i, j));
                        DFS(grid, m, n, visited, sb, i, j);
                        islands.Add(sb.ToString());
                    }
                }
            }
            return islands.Count;
        }

        private void DFS(int[,] grid, int m, int n, HashSet<(int, int)> visited, StringBuilder sb, int x, int y)
        {
            var moves = new int[,] {{0, 1}, {0, -1}, {1, 0}, {-1, 0}};
            for (var i = 0; i < 4; ++i)
            {
                var nx = x + moves[i, 0];
                var ny = y + moves[i, 1];
                if (nx >= 0 && nx < m && ny >= 0 && ny < n && grid[nx, ny] == 1 && !visited.Contains((nx, ny)))
                {
                    visited.Add((nx, ny));
                    sb.Append(i);
                    DFS(grid, m, n, visited, sb, nx, ny);
                    sb.Append(i + 4);
                }
            }
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
