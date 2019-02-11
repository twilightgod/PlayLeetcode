using System;

namespace _0261
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
        public bool ValidTree(int n, int[,] edges)
        {
            var uf = new UnionFind(n);
            for (var i = 0; i < edges.GetLength(0); ++i)
            {
                var x = edges[i, 0];
                var y = edges[i, 1];
                if (uf.Find(x) == uf.Find(y))
                {
                    return false;
                }
                uf.Union(x, y);
            }
            var setCount = 0;
            for (var i = 0; i < n; ++i)
            {
                if (uf.Find(i) == i)
                {
                    if (++setCount > 1)
                    {
                        return false;
                    }
                }
            }
            return true;
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
