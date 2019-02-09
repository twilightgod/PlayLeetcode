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
            
            for (var i = 0; i < m; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    if (rooms[i, j] == 0)
                    {
                        var q = new Queue<(int, int)>();
                        q.Enqueue((i, j));
                        while (q.Count > 0)
                        {
                            var (x, y) = q.Dequeue();
                            for (var k = 0; k < 4; ++k)
                            {
                                var nextx = x + moves[k, 0];
                                var nexty = y + moves[k, 1];
                                if (nextx >= 0 && nextx < m && nexty >= 0 && nexty < n && rooms[nextx, nexty] > rooms[x, y] + 1)
                                {
                                    rooms[nextx, nexty] = rooms[x, y] + 1;
                                    q.Enqueue((nextx, nexty));
                                }
                            }
                        }
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
