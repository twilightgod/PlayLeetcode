using System;
using System.Collections.Generic;

namespace _0743
{
    // Dijkstra
    public class Solution
    {
        public int NetworkDelayTime(int[,] times, int N, int K)
        {
            var edges = new List<List<(int, int)>>();
            var dist = new List<int>();
            var visited = new List<bool>();

            for (var i = 0; i <= N; ++i)
            {
                edges.Add(new List<(int, int)>());
                dist.Add(Int32.MaxValue);
                visited.Add(false);
            }

            for (var i = 0; i < times.GetLength(0); ++i)
            {
                var from = times[i, 0];
                var to = times[i, 1];
                var w = times[i, 2];
                edges[from].Add((to, w));
            }

            dist[K] = 0;
            for (var i = 0; i < N; ++i)
            {
                var minDist = Int32.MaxValue;
                var from = 0;
                for (var j = 1; j <= N; ++j)
                {
                    if (!visited[j] && minDist > dist[j])
                    {
                        minDist = dist[j];
                        from = j;
                    }
                }
                if (from == 0)
                {
                    return -1;
                }

                visited[from] = true;
                foreach (var (to, w) in edges[from])
                {
                    if (!visited[to] && dist[to] > dist[from] + w)
                    {
                        dist[to] = dist[from] + w;
                    }
                }
            }

            var answer = 0;
            for (var i = 1; i <= N; ++i)
            {
                answer = Math.Max(answer, dist[i]);
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
