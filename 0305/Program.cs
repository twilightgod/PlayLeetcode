using System;
using System.Collections.Generic;

namespace _0305
{
    public class UnionFind
    {
        private Dictionary<int, int> parent = new Dictionary<int, int>();
        private Dictionary<int, int> rank = new Dictionary<int, int>();
        public int SetsCount {get;private set;} = 0;

        public bool Contains(int x)
        {
            return parent.ContainsKey(x);
        }

        public int Find(int x)
        {
            if (!Contains(x))
            {
                parent[x] = x;
                rank[x] = 0;
                SetsCount++;
            }

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
                if (rank[x] > rank[y])
                {
                    parent[y] = x;
                }
                else if (rank[x] < rank[y])
                {
                    parent[x] = y;
                }
                else
                {
                    parent[x] = y;
                    rank[y]++;
                }
                
                SetsCount--;
            }
        }
    }

    public class Solution
    {
        public IList<int> NumIslands2(int m, int n, int[,] positions)
        {
            var moves = new int[,] {{0, 1}, {1, 0}, {-1, 0}, {0, -1}};
            var answer = new List<int>();
            var uf = new UnionFind();

            for (var i = 0; i < positions.GetLength(0); ++i)
            {
                var x1 = positions[i, 0];
                var y1 = positions[i, 1];
                var p1 = x1 * n + y1;
                // need to create the entry even if there's no surrounding islands 
                uf.Find(p1);

                for (var j = 0; j < 4; ++j)
                {
                    var x2 = x1 + moves[j, 0];
                    var y2 = y1 + moves[j, 1];

                    if (x2 >= 0 && y2 >= 0 && x2 < m && y2 < n)
                    {
                        var p2 = x2 * n + y2;
                        if (uf.Contains(p2))
                        {
                            uf.Union(p1, p2);
                        }
                    }
                }

                answer.Add(uf.SetsCount);
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
