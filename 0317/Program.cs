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
            var moves = new int[,] { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };
            // total distance for a cell to get to all buildings
            var totalSteps = new int[m, n];
            // reachable count for each cell (building -> cell)
            var reachCount = new int[m, n];

            var buildingCount = 0;
            for (var i = 0; i < m; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    if (grid[i, j] == 1)
                    {
                        buildingCount++;
                    }
                }
            }

            // for each building, find out the distance from it to every empty cell
            for (var i = 0; i < m; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    if (grid[i, j] == 1)
                    {
                        var steps = new int[m, n];
                        var reachableBuildingCount = 0;
                        var q = new Queue<(int, int)>();
                        q.Enqueue((i, j));
                        while (q.Count > 0)
                        {
                            var (x, y) = q.Dequeue();
                            for (var k = 0; k < 4; ++k)
                            {
                                var nx = x + moves[k, 0];
                                var ny = y + moves[k, 1];
                                if (nx >= 0 && nx < m && ny >= 0 && ny < n && steps[nx, ny] == 0)
                                {
                                    if (grid[nx, ny] == 0)
                                    {
                                        steps[nx, ny] = steps[x, y] + 1;
                                        totalSteps[nx, ny] += steps[nx, ny];
                                        reachCount[nx, ny]++;
                                        q.Enqueue((nx, ny));
                                    }
                                    // reuse BFS to get reachable building count
                                    else if (grid[nx, ny] == 1)
                                    {
                                        steps[nx, ny] = 1;
                                        reachableBuildingCount++;
                                    }
                                }
                            }
                        }
                        // optimization, return -1 earlier before doing all BFS
                        if (reachableBuildingCount != buildingCount)
                        {
                            return -1;
                        }
                    }
                }
            }

            var answer = Int32.MaxValue;
            // for each empty cell, find out the total distance to all buildings
            for (var i = 0; i < m; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    if (grid[i, j] == 0 && reachCount[i, j] == buildingCount)
                    {
                        answer = Math.Min(answer, totalSteps[i, j]);
                    }
                }
            }

            return answer;
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
