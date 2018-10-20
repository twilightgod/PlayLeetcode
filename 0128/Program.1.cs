using System;
using System.Collections.Generic;

namespace _0128_1
{
    public class UnionFind
    {
        Dictionary<int, int> root = new Dictionary<int, int>();
        Dictionary<int, int> rank = new Dictionary<int, int>();
        Dictionary<int, int> size = new Dictionary<int, int>();

        public bool Contains(int x)
        {
            return root.ContainsKey(x);
        }

        public void TryCreate(int x)
        {
            if (!root.ContainsKey(x))
            {
                root[x] = x;
                rank[x] = 0;
                size[x] = 1;
                LargestSize = Math.Max(LargestSize, 1);
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
                    LargestSize = Math.Max(LargestSize, size[y]);
                }
                else if (rank[x] > rank[y])
                {
                    root[y] = x;
                    size[x] += size[y];
                    LargestSize = Math.Max(LargestSize, size[x]);
                }
                else
                {
                    root[y] = x;
                    rank[x]++;
                    size[x] += size[y];
                    LargestSize = Math.Max(LargestSize, size[x]);
                }
            }
        }

        public int LargestSize {private set;get;} = 0;
    }

    public class Solution
    {
        public int LongestConsecutive(int[] nums)
        {
            var uf = new UnionFind();
            foreach (var num in nums)
            {
                uf.TryCreate(num);
                if (uf.Contains(num - 1))
                {
                    uf.Union(num, num - 1);
                }
                if (uf.Contains(num + 1))
                {
                    uf.Union(num, num + 1);
                }
            }
            return uf.LargestSize;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().LongestConsecutive(new int[]{1,2,0,1});
            new Solution().LongestConsecutive(new int[]{100,4,200,1,3,2});
            Console.WriteLine("Hello World!");
        }
    }
}
