using System;
using System.Collections.Generic;

namespace _0200
{
    public class Solution
    {
        public int NumIslands(char[,] grid)
        {
            var ans = 0;
            var moves = new int[4, 2] {{1, 0}, {0, -1}, {-1, 0}, {0, 1}};

            for (var i = 0; i < grid.GetLength(0); ++i)
            {
                for (var j = 0; j < grid.GetLength(1); ++j)
                {
                    if (grid[i, j] == '1')
                    {
                        ans++;

                        var q = new Queue<Tuple<int, int>>();
                        q.Enqueue(Tuple.Create<int, int>(i, j));
                        while (q.Count > 0)
                        {
                            var p = q.Dequeue();
                            var x = p.Item1;
                            var y = p.Item2;
                            for (var k = 0; k < 4; ++k)
                            {
                                var nx = x + moves[k, 0];
                                var ny = y + moves[k, 1];
                                if (nx >= 0 && ny >= 0 && nx < grid.GetLength(0) && ny < grid.GetLength(1) && grid[nx, ny] == '1')
                                {
                                    grid[nx, ny] = '0';
                                    q.Enqueue(Tuple.Create<int, int>(nx, ny));
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
