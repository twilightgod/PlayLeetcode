using System;
using System.Collections.Generic;

namespace _0684
{
    public class UnionFind
    {
        Dictionary<int, int> root = new Dictionary<int, int>();
        Dictionary<int, int> rank = new Dictionary<int, int>();

        public int Find(int x)
        {
            if (!root.ContainsKey(x))
            {
                root[x] = x;
                rank[x] = 0;
            }
            else if (root[x] != x)
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
                    rank[x]++;
                }
                else
                {
                    root[y] = x;
                    rank[x]++;
                }
            }
        }
    }

    public class Solution
    {
        public int[] FindRedundantConnection(int[,] edges)
        {
            var uf = new UnionFind();

            for (var i = 0; i < edges.Length; ++i)
            {
                var x = uf.Find(edges[i, 0]);
                var y = uf.Find(edges[i, 1]);
                if (x == y)
                {
                    return new int[]{edges[i, 0], edges[i, 1]};
                }
                else
                {
                    uf.Union(x, y);
                }
            }

            return null;
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
