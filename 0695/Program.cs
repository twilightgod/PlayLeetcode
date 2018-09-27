using System;

namespace _0695
{
    public class Solution
    {
        public int MaxAreaOfIsland(int[,] grid)
        {
            var m = grid.GetLength(0);
            var n = grid.GetLength(1);
            var answer = 0;
            var visited = new bool[m, n];

            for (var i = 0; i < m; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    if (!visited[i, j] && grid[i, j] == 1)
                    {
                        answer = Math.Max(answer, BFS(grid, m, n, i, j, visited));
                    }
                }
            }

            return answer;
        }

        private int BFS(int[,] grid, int m, int n, int startx, int starty, bool[,] visited)
        {
            var moves = new int[,] {{0, 1}, {1, 0}, {-1, 0}, {0, -1}};
            var q = new Queue<(int x, int y)>();
            q.Enqueue((startx, starty));
            visited[startx, starty] = true;
            var size = 1;

            while (q.Count > 0)
            {
                var node = q.Dequeue();
                for (var i = 0; i < 4; ++i)
                {
                    var newx = node.x + moves[i, 0];
                    var newy = node.y + moves[i, 1];
                    if (newx >= 0 && newx < m && newy >=0 && newy < n && !visited[newx, newy] && grid[newx, newy] == 1)
                    {
                        visited[newx, newy] = true;
                        size++;
                        q.Enqueue((newx, newy));
                    }
                }
            }

            return size;
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
