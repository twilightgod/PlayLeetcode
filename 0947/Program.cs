using System;
using System.Collections.Generic;

namespace _0947
{
    public class UnionFind
    {
        private Dictionary<int, int> parent = new Dictionary<int, int>();

        private Dictionary<int, int> rank = new Dictionary<int, int>();

        private int count = 0;

        public int Find(int x)
        {
            if (!parent.ContainsKey(x))
            {
                parent[x] = x;
                rank[x] = 0;
                count++;
            }
            else
            {
                if (parent[x] != x)
                {
                    parent[x] = Find(parent[x]);
                }
            }

            return parent[x];
        }

        public void Union(int x, int y)
        {
            var px = Find(x);
            var py = Find(y);

            if (px == py)
            {
                return;
            }

            if (rank[x] < rank[y])
            {
                parent[px] = py;
            }
            else if (rank[x] > rank[y])
            {
                parent[py] = px;
            }
            else
            {
                parent[py] = px;
                rank[x]++;
            }
            count--;
        }

        public int GetCount()
        {
            return count;
        }
    }

    public class Solution
    {
        public int RemoveStones(int[][] stones)
        {
            var uf = new UnionFind();
            var n = stones.GetLength(0);

            for (var i = 0; i <n ; ++i)
            {
                // ~y is used here for encoding
                uf.Union(stones[i][0], ~stones[i][1]);
            }

            return n - uf.GetCount();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().RemoveStones(new int[][]{
                new int[]{0, 0},
                new int[]{0, 1},
                new int[]{1, 0},
                new int[]{1, 2},
                new int[]{2, 1},
                new int[]{2, 2},
                });
            Console.WriteLine("Hello World!");
        }
    }
}
