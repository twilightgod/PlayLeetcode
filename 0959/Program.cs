using System;

namespace _0959
{
    public class UnionFind
    {
        int[] parent = null;
        int[] rank = null;

        public UnionFind(int n)
        {
            parent = new int[n];
            rank = new int[n];
            for (var i = 0; i < n; ++i)
            {
                parent[i] = i;
                rank[i] = 0;
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
                if (rank[x] < rank[y])
                {
                    parent[x] = y;
                }
                else if (rank[x] > rank[y])
                {
                    parent[y] = x;
                }
                else
                {
                    parent[y] = x;
                    rank[x]++;
                }
            }
        }
    }

    public class Solution
    {
        public int RegionsBySlashes(string[] grid)
        {
            var n = grid.Length;
            var m = n * n * 4;
            var uf = new UnionFind(m);
            /* split cell into 4 sub-cell

            \ 0 /
            3\ /1
             / \
            / 2 \

             */
            for (var i = 0; i < n; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    var c0 = 4 * (i * n + j);
                    var c1 = 4 * (i * n + j) + 1;
                    var c2 = 4 * (i * n + j) + 2;
                    var c3 = 4 * (i * n + j) + 3;

                    // connect neighbors
                    var n0 = 4 * ((i + 1) * n + j);
                    var n1 = 4 * (i * n + j - 1) + 1;
                    var n2 = 4 * ((i - 1) * n + j) + 2;
                    var n3 = 4 * (i * n + j + 1) + 3;

                    if (i + 1 < n)
                    {
                        uf.Union(c2, n0);
                    }
                    if (j - 1 >= 0)
                    {
                        uf.Union(c3, n1);
                    }
                    if (i - 1 >= 0)
                    {
                        uf.Union(c0, n2);
                    }
                    if (j + 1 < n)
                    {
                        uf.Union(c1, n3);
                    }

                    // connect within current cell
                    if (grid[i][j] == ' ')
                    {
                        uf.Union(c0, c1);
                        uf.Union(c1, c2);
                        uf.Union(c2, c3);
                    }
                    else if (grid[i][j] == '/')
                    {
                        uf.Union(c0, c3);
                        uf.Union(c1, c2);
                    }
                    else // /
                    {
                        uf.Union(c0, c1);
                        uf.Union(c2, c3);
                    }
                }
            }

            var answer = 0;
            for (var i = 0; i < m; ++i)
            {
                if (uf.Find(i) == i)
                {
                    answer++;
                }
            }
            return answer;
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
