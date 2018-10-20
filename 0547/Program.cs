using System;

namespace _0547
{
    public class UnionFind
    {
        int[] root = null;
        int[] rank = null;

        //[1, capacity]
        public UnionFind(int capacity)
        {
            root = new int[capacity + 1];
            rank = new int[capacity + 1];
        }

        public int Find(int x)
        {
            if (root[x] == 0)
            {
                root[x] = x;
                rank[x] = 0;
                ForestCount++;
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
        public int FindCircleNum(int[,] M)
        {
            var n = M.GetLength(0);
            var uf = new UnionFind(n + 1);
            for (var i = 0; i < n; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    if (M[i, j] == 1)
                    {
                        uf.Union(i + 1, j + 1);
                    }
                }
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
