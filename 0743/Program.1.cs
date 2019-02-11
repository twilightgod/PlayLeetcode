using System;
using System.Collections.Generic;
using System.Linq;

namespace _0743_1
{
    // Dijkstra Heap
    public class Solution
    {
        public int NetworkDelayTime(int[,] times, int N, int K)
        {
            var edges = new List<List<(int, int)>>();
            var dist = new SortedSet<(int, int)>();
            var visited = new List<bool>();

            for (var i = 0; i <= N; ++i)
            {
                edges.Add(new List<(int, int)>());
                visited.Add(false);
            }

            for (var i = 0; i < times.GetLength(0); ++i)
            {
                var from = times[i, 0];
                var to = times[i, 1];
                var w = times[i, 2];
                edges[from].Add((to, w));
            }

            dist.Add((0, K));
            var answer = 0;
            var visitCount = 0;
            while (dist.Count > 0)
            {
                var (d, from) = dist.First();
                dist.Remove((d, from));
                if (visited[from])
                {
                    continue;
                }
                answer = Math.Max(answer, d);
                
                visited[from] = true;
                if (++visitCount == N)
                {
                    break;
                }
                foreach (var (to, w) in edges[from])
                {
                    if (!visited[to])
                    {
                        dist.Add((d + w, to));
                    }
                }
            }

            return visitCount != N ? -1 : answer;
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
