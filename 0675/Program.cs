using System;
using System.Collections.Generic;

namespace _0675
{
    public class Solution
    {
        public int CutOffTree(IList<IList<int>> forest)
        {
            var m = forest.Count;
            var n = forest[0].Count;

            var trees = new List<(int h, int x, int y)>();
            trees.Add((-1, 0, 0));
            
            for (var i = 0; i < m; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    if (forest[i][j] > 1)
                    {
                        trees.Add((forest[i][j], i, j));
                    }
                }
            }

            trees.Sort();
            var sum = 0;
            for (var i = 0; i < trees.Count - 1; ++i)
            {
                var d = GetDistance(forest, m, n, trees[i].x, trees[i].y, trees[i + 1].x, trees[i + 1].y);
                if (d == -1)
                {
                    return -1;
                }
                else
                {
                    sum += d;
                }
            }

            return sum;
        }
        
        private int GetDistance(IList<IList<int>> forest, int m, int n, int startx, int starty, int endx, int endy)
        {
            var moves = new int[,] {{1, 0}, {-1, 0}, {0, 1}, {0, -1}};
            var q = new Queue<(int x, int y, int d)>();
            var visited = new HashSet<(int x, int y)>();
            
            q.Enqueue((startx, starty, 0));
            visited.Add((startx, starty));

            while (q.Count > 0)
            {
                var (x, y, d) = q.Dequeue();
                if (x == endx && y == endy)
                {
                    return d;
                }

                for (var i = 0; i < 4; ++i)
                {
                    var nextx = x + moves[i, 0];
                    var nexty = y + moves[i, 1];
                    if (nextx >= 0 && nextx < m && nexty >= 0 && nexty < n && forest[nextx][nexty] > 0 && !visited.Contains((nextx, nexty)))
                    {
                        visited.Add((nextx, nexty));
                        q.Enqueue((nextx, nexty, d + 1));
                    }
                }
            }

            return -1;
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
