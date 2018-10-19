using System;
using System.Collections.Generic;

namespace _0685
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
                    rank[x]++;
                }
                else
                {
                    root[y] = x;
                    rank[x]++;
                }
                ForestCount--;
            }
        }

        public int ForestCount {private set;get;} = 0;
    }

    public class Solution
    {
        public int[] FindRedundantDirectedConnection(int[,] edges)
        {
            for (var i = edges.GetLength(0) - 1; i >= 0; --i)
            {
                if (IsValidTree(edges, i))
                {
                    return new int[]{edges[i, 0], edges[i, 1]};
                }
            }
            return null;
        }

        private bool IsValidTree(int[,] edges, int removedIndex)
        {
            var inDegree0 = new HashSet<int>();
            var inDegree1 = new HashSet<int>();
            var uf = new UnionFind();

            for (var i = 0; i < edges.GetLength(0); ++i)
            {
                if (i == removedIndex)
                {
                    continue;
                }

                var x = edges[i, 0];
                var y = edges[i, 1];

                // init in-degree for new node
                if (!inDegree0.Contains(x) && !inDegree1.Contains(x))
                {
                    inDegree0.Add(x);
                }
                if (!inDegree0.Contains(y) && !inDegree1.Contains(y))
                {
                    inDegree0.Add(y);
                }

                // increase in-degree for y
                if (inDegree0.Contains(y))
                {
                    inDegree0.Remove(y);
                    inDegree1.Add(y);
                    if (inDegree0.Count == 0)
                    {
                        return false;
                    }
                }
                else if (inDegree1.Contains(y))
                {
                    return false;
                }

                uf.Union(uf.Find(x), uf.Find(y));
            }

            return uf.ForestCount == 1;
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
