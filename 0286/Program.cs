using System;
using System.Collections.Generic;

namespace _0286
{
    public class Solution
    {
        public void WallsAndGates(int[,] rooms)
        {
            var moves = new int[,] { { 0, 1 }, { 1, 0 }, { -1, 0 }, { 0, -1 } };
            var m = rooms.GetLength(0);
            var n = rooms.GetLength(1);
            var INF = Int32.MaxValue;
            var q = new Queue<(int, int)>();

            // put all 0 into queue!
            for (var i = 0; i < m; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    if (rooms[i, j] == 0)
                    {
                        q.Enqueue((i, j));
                    }
                }
            }

            while (q.Count > 0)
            {
                var (x, y) = q.Dequeue();
                for (var k = 0; k < 4; ++k)
                {
                    var nx = x + moves[k, 0];
                    var ny = y + moves[k, 1];
                    if (nx >= 0 && nx < m && ny >= 0 && ny < n && rooms[nx, ny] == INF)
                    {
                        rooms[nx, ny] = rooms[x, y] + 1;
                        q.Enqueue((nx, ny));
                    }
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
