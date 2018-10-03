using System;
using System.Collections.Generic;

namespace _0317
{
    public class Solution
    {
        public int ShortestDistance(int[,] grid)
        {
            var m = grid.GetLength(0);
            var n = grid.GetLength(1);
            var moves = new int[,] {{1, 0}, {-1, 0}, {0, 1}, {0, -1}};
            var stepsList = new List<int[,]>();

            for (var i = 0; i < m; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    if (grid[i, j] == 1)
                    {
                        var steps = new int[m, n];
                        var q = new Queue<(int x, int y)>();
                        q.Enqueue((i, j));
                        while (q.Count > 0)
                        {
                            var node = q.Dequeue();
                            for (var k = 0; k < 4; ++k)
                            {
                                var nextx = node.x + moves[k, 0];
                                var nexty = node.y + moves[k, 1];
                                if (nextx >= 0 && nextx < m && nexty >= 0 && nexty < n && grid[nextx, nexty] == 0 && steps[nextx, nexty] == 0)
                                {
                                    steps[nextx, nexty] = steps[node.x, node.y] + 1;
                                    q.Enqueue((nextx, nexty));
                                }
                            }
                        }
                        stepsList.Add(steps); 
                    }
                }
            }

            var answer = Int32.MaxValue;
            for (var i = 0; i < m; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    if (grid[i, j] == 0)
                    {
                        var distance = 0;
                        var reachable = true;
                        for (var k = 0; k < stepsList.Count; ++k)
                        {
                            if (stepsList[k][i, j] == 0)
                            {
                                reachable = false;
                                break;
                            }
                            else
                            {
                                distance += stepsList[k][i, j];
                            }
                        }
                        if (reachable)
                        {
                            answer = Math.Min(answer, distance);
                        }
                    }
                }
            }
            
            return answer == Int32.MaxValue ? -1 : answer;
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
