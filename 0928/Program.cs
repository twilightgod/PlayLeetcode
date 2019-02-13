using System;
using System.Collections.Generic;
using System.Linq;

namespace _0928
{
    public class UnionFind
    {
        int[] parent = null;

        public UnionFind(int n)
        {
            parent = new int[n];
            for (var i = 0; i < n; ++i)
            {
                parent[i] = i;
            }
        }

        public int Find(int x)
        {
            if (parent[x] != x)
            {
                parent[x] = Find(parent[x]);
            }
            return parent[x];
        }

        public void Union(int x, int y)
        {
            x = Find(x);
            y = Find(y);
            if (x != y)
            {
                parent[x] = y;
            }
        }
    }

    public class Solution
    {
        public int MinMalwareSpread(int[][] graph, int[] initial)
        {
            var n = graph.GetLength(0);
            var uf = new UnionFind(n);

            var malSet = new HashSet<int>(initial);

            // connect nodes without malware
            for (var i = 0; i < n; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    if (!malSet.Contains(i) && !malSet.Contains(j) && graph[i][j] == 1)
                    {
                        uf.Union(i, j);
                    }
                }
            }

            // group parent -> count
            var counts = new Dictionary<int, int>();
            for (var i = 0; i < n; ++i)
            {
                if (!malSet.Contains(i))
                {
                    var p = uf.Find(i);
                    counts[p] = counts.GetValueOrDefault(p, 0) + 1;
                }
            }

            var m = initial.Length;
            // group parent -> malware neighbor count
            var mals = new Dictionary<int, int>();
            for (var i = 0; i < m; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    if (graph[initial[i]][j] == 1 && !malSet.Contains(j))
                    {
                        var p = uf.Find(j);
                        mals[p] = mals.GetValueOrDefault(p, 0) + 1;
                    }
                }
            }

            // only care about groups with only 1 malware neighbor
            var maxCount = 0;
            var maxIdx = initial.Min();
            for (var i = 0; i < m; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    if (graph[initial[i]][j] == 1 && !malSet.Contains(j))
                    {
                        var p = uf.Find(j);
                        if (mals[p] == 1)
                        {

                            if (maxCount < counts[p])
                            {
                                maxCount = counts[p];
                                maxIdx = initial[i];
                            }
                            else if (maxCount == counts[p] && maxIdx > initial[i])
                            {
                                maxIdx = initial[i];
                            }
                        }
                    }
                }
            }

            return maxIdx;
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
