using System;
using System.Collections.Generic;

namespace _0685_1
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
        public int[] FindRedundantDirectedConnection(int[,] edges)
        {
            // assume all node id is within the range
            var n = edges.GetLength(0);
            var parent = new int[n + 1];
            int[] answer1 = null;
            int[] answer2 = null;

            // check if a node has two parents
            for (var i = 0; i < n; ++i)
            {
                var x = edges[i, 0];
                var y = edges[i, 1];
                if (parent[y] > 0)
                {
                    answer1 = new int[]{x, y};
                    answer2 = new int[]{parent[y], y};
                    break;
                }
                else
                {
                    parent[y] = x;
                }
            }

            var uf = new UnionFind();
            for (var i = 0; i < n; ++i)
            {
                var x = edges[i, 0];
                var y = edges[i, 1];
                if (answer1 != null && answer1[0] == x && answer1[1] == y)
                {
                    // remove answer1
                    continue;
                }

                var rootx = uf.Find(x);
                var rooty = uf.Find(y);
                // found circle
                if (rootx == rooty)
                {
                    if (answer1 == null)
                    {
                        // no nodes with two parents, so remove this edge
                        return new int[]{x, y};
                    }
                    else
                    {
                        // found circle without answer1, so remove answer2
                        return answer2;
                    }
                }
                else
                {
                    uf.Union(rootx, rooty);
                }
            }

            return answer1;
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
