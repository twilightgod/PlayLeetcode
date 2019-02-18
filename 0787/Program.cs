using System;
using System.Collections.Generic;
using System.Linq;

namespace _0787
{
    // BFS with Heap, looks like DP
    public class Solution
    {
        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K)
        {
            var edge = new Dictionary<int, List<(int y, int d)>>();
            // not only to record the shortest distance from src to each node
            // but also needs another dimension of transit times
            // it's possible to have shortest path can't meet the K limit
            var dis = new int[n, K + 2];
            for (var i = 0; i < n; ++i)
            {
                edge[i] = new List<(int y, int d)>();
                for (var j = 0; j < K + 2; ++j)
                {
                    dis[i, j] = Int32.MaxValue;
                }
            }
            for (var i = 0; i < flights.Length; ++i)
            {
                edge[flights[i][0]].Add((flights[i][1], flights[i][2]));
            }
            dis[src, 0] = 0;
            // (distance, city, times)
            var q = new SortedSet<(int d, int x, int t)>();
            q.Add((0, src, 0));
            while (q.Count > 0)
            {
                var node = q.First();
                //Console.WriteLine(node);
                q.Remove(node);
                if (node.x == dst)
                {
                    return node.d;
                }
                if (node.t > K)
                {
                    continue;
                }
                foreach (var e in edge[node.x])
                {
                    var nextd = node.d + e.d;
                    if (dis[e.y, node.t + 1] > nextd)
                    {
                        dis[e.y, node.t + 1] = nextd;
                        q.Add((nextd, e.y, node.t + 1));
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
