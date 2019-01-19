using System;
using System.Collections.Generic;

namespace _0947
{
    public class UnionFind
    {
        private Dictionary<int, int> parent = new Dictionary<int, int>();
        private Dictionary<int, int> size = new Dictionary<int, int>();

        public int Find(int x)
        {
            if (!parent.ContainsKey(x))
            {
                parent[x] = x;
                // only stones get size == 1
                size[x] = x >= 0 ? 1 : 0;
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

            // make sure to merge to stone
            if (py < 0)
            {
                (px, py) = (py, px);
            }

            parent[px] = py;
            size[py] += size[px];
        }

        public int GetSize(int x)
        {
            return size[x];
        }
    }

    public class Solution
    {
        public int RemoveStones(int[][] stones)
        {
            var uf = new UnionFind();
            for (var i = 0; i < stones.GetLength(0); ++i)
            {
                var row = stones[i][0];
                var col = stones[i][1];
                // stone has positive id
                var stoneId = row * 10000 + col;
                // row and col have negtive id
                var rowId = - row - 20000;
                var colId = - col - 30000;
                uf.Union(stoneId, rowId);
                uf.Union(stoneId, colId);
            }

            var answer = 0;
            for (var i = 0; i < stones.GetLength(0); ++i)
            {
                var row = stones[i][0];
                var col = stones[i][1];
                var stoneId = row * 10000 + col;
                if (uf.Find(stoneId) == stoneId)
                {
                    answer += uf.GetSize(stoneId) - 1;
                }
            }
            
            return answer;
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
