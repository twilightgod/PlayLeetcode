using System;

namespace _0329
{
    public class Solution
    {
        public int LongestIncreasingPath(int[,] matrix)
        {
            var m = matrix.GetLength(0);
            var n = matrix.GetLength(1);
            var f = new int[m, n];
            var answer = 0;
            for (var x = 0; x < m; ++x)
            {
                for (var y = 0; y < n; ++y)
                {
                    answer = Math.Max(answer, DFS(m, n, x, y, matrix, f));
                }
            }
            return answer;
        }

        private int DFS(int m, int n, int x, int y, int[,] matrix, int[,] f)
        {
            if (f[x, y] == 0)
            {
                var moves = new int[,] {{1, 0}, {-1, 0}, {0, 1}, {0, -1}};
                for (var i = 0; i < 4; ++i)
                {
                    var newx = x + moves[i, 0];
                    var newy = y + moves[i, 1];
                    if (newx >= 0 && newx < m && newy >= 0 && newy < n && matrix[x, y] > matrix[newx, newy])
                    {
                        f[x, y] = Math.Max(f[x, y], DFS(m, n, newx, newy, matrix, f));
                    }
                }
                f[x, y]++;
            }
            
            return f[x, y];
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
