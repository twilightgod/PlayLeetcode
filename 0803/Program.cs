using System;
using System.Collections.Generic;

namespace _0803
{
    public class UnionFind
    {
        int[] root = null;
        int[] rank = null;
        int[] size = null;

        public UnionFind(int capacity)
        {
            root = new int[capacity];
            rank = new int[capacity];
            size = new int[capacity];
            for (var i = 0; i < capacity; ++i)
            {
                root[i] = i;
                rank[i] = 0;
                size[i] = 1;
            }
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
                    size[y] += size[x];
                }
                else if (rank[x] > rank[y])
                {
                    root[y] = x;
                    size[x] += size[y];
                }
                else
                {
                    root[y] = x;
                    size[x] += size[y];
                    rank[x]++;
                }
            }
        }

        public int GetSize(int x)
        {
            return size[Find(x)];
        }
    }

    public class Solution
    {
        private int GetIndex(int x, int y)
        {
            return x * n + y;
        }

        int m = 0;
        int n = 0;

        public int[] HitBricks(int[][] grid, int[][] hits)
        {
            var answers = new int[hits.Length];
            var moves = new int[,] { { 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 } };
            // remove all hits
            for (var i = 0; i < hits.Length; ++i)
            {
                var hitx = hits[i][0];
                var hity = hits[i][1];
                if (grid[hitx][hity] == 1)
                {
                    grid[hitx][hity] = -1;
                }
            }
            m = grid.Length;
            n = grid[0].Length;
            var uf = new UnionFind(m * n + 1);
            // virtual root to calculate hit in O(1)
            var roof = m * n;
            // init unionfind
            for (var i = 0; i < m; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    if (grid[i][j] == 1)
                    {
                        if (i == 0)
                        {
                            uf.Union(roof, GetIndex(i, j));
                        }
                        if (i - 1 >= 0 && grid[i - 1][j] == 1)
                        {
                            uf.Union(GetIndex(i - 1, j), GetIndex(i, j));
                        }
                        if (j - 1 >= 0 && grid[i][j - 1] == 1)
                        {
                            uf.Union(GetIndex(i, j - 1), GetIndex(i, j));
                        }
                    }
                }
            }
            // process hit backwards
            for (var i = hits.Length - 1; i >= 0; --i)
            {
                var previousRootSize = uf.GetSize(roof);
                var hitx = hits[i][0];
                var hity = hits[i][1];
                // some test case will hit at empty
                if (grid[hitx][hity] == -1)
                {
                    grid[hitx][hity] = 1;
                    if (hitx == 0)
                    {
                        uf.Union(roof, GetIndex(hitx, hity));
                    }
                    for (var k = 0; k < 4; ++k)
                    {
                        var x = hitx + moves[k, 0];
                        var y = hity + moves[k, 1];
                        if (x >= 0 && x < m && y >= 0 && y < n && grid[x][y] == 1)
                        {
                            uf.Union(GetIndex(hitx, hity), GetIndex(x, y));
                        }
                    }
                    var newRootSize = uf.GetSize(roof);
                    // it will result in zero if hits a brick that already fell
                    answers[i] = Math.Max(0, newRootSize - previousRootSize - 1);
                }
            }
            return answers;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().HitBricks(new int[][] { new int[] { 1, 0, 0, 0 }, new int[] { 1, 1, 1, 0 } }, new int[][] { new int[] { 1, 0 } });
            Console.WriteLine("Hello World!");
        }
    }
}
