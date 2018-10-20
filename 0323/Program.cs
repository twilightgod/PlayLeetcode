using System;
using System.Collections.Generic;
using System.Linq;

namespace _0323
{
    public class UnionFind
    {
        List<int> root = new List<int>();
        List<int> rank = new List<int>();

        //[1, capacity]
        public UnionFind(int capacity)
        {
            for (var i = 0; i < capacity; ++i)
            {
                root.Add(i);
                rank.Add(0);
            }
            ForestCount = capacity;
        }

        public int Find(int x)
        {
            if (root[x] != x)
            {
                root[x] = Find(root[x]);
            }
            return root[x];
        }

        public void Union(int x, int y)
        {
            x = Find(x);
            y = Find(y);
            if (x != y)
            {
                if (rank[x] < rank[y])
                {
                    root[x] = y;
                }
                else if (rank[x] > rank[y])
                {
                    root[y] = x;
                }
                else
                {
                    root[y] = x;
                    rank[x]++;
                }
                ForestCount--;
            }
        }

        public int ForestCount { private set; get; } = 0;
    }

    public class Solution
    {
        public int CountComponents(int n, int[,] edges)
        {
            var uf = new UnionFind(n);
            for (var i = 0; i < edges.GetLength(0); ++i)
            {
                uf.Union(edges[i, 0], edges[i, 1]);
            }

            return uf.ForestCount;
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
