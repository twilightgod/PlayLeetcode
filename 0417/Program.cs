using System;
using System.Collections.Generic;

namespace _0417
{
    public class Solution
    {
        public IList<int[]> PacificAtlantic(int[,] matrix)
        {
            var s1 = BFS(matrix, true);
            var s2 = BFS(matrix, false);
            s1.IntersectWith(s2);
            var answer = new List<int[]>();
            foreach (var (x, y) in s1)
            {
                answer.Add(new int[]{x, y});
            }
            return answer;
        }

        private HashSet<(int, int)> BFS(int[,] matrix, bool fromTopLeft)
        {
            var m = matrix.GetLength(0);
            var n = matrix.GetLength(1);
            var q = new Queue<(int, int)>();
            var visited = new HashSet<(int, int)>();
            
            for (var i = 0; i < m; ++i)
            {
                if (fromTopLeft)
                {
                    q.Enqueue((i, 0));
                    visited.Add((i, 0));
                }
                else
                {
                    q.Enqueue((i, n - 1));
                    visited.Add((i, n - 1));
                }
            }

            for (var i = 0; i < n; ++i)
            {
                if (fromTopLeft)
                {
                    q.Enqueue((0, i));
                    visited.Add((0, i));
                }
                else
                {
                    q.Enqueue((m - 1, i));
                    visited.Add((m - 1, i));
                }
            }

            var moves = new int[,] {{0, 1}, {1, 0}, {0, -1}, {-1, 0}};
            while (q.Count > 0)
            {
                var (x, y) = q.Dequeue();
                for (var i = 0; i < 4; ++i)
                {
                    var nx = x + moves[i, 0];
                    var ny = y + moves[i, 1];
                    if (nx >= 0 && nx < m && ny >= 0 && ny < n && matrix[nx, ny] >= matrix[x, y] && !visited.Contains((nx, ny)))
                    {
                        q.Enqueue((nx, ny));
                        visited.Add((nx, ny));
                    }
                }
            }

            return visited;
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
