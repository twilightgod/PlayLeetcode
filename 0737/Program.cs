using System;
using System.Collections.Generic;

namespace _0737
{
    public class UnionFind
    {
        Dictionary<string, string> parent = new Dictionary<string, string>();
        Dictionary<string, int> rank = new Dictionary<string, int>();

        public string Find(string x)
        {
            if (!Contains(x))
            {
                parent[x] = x;
                rank[x] = 0;
            }

            if (parent[x] != x)
            {
                parent[x] = Find(parent[x]);
            }

            return parent[x];
        }

        public void Union(string x, string y)
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
            }
        }

        public bool Contains(string x)
        {
            return parent.ContainsKey(x);
        }
    }

    public class Solution
    {
        public bool AreSentencesSimilarTwo(string[] words1, string[] words2, string[,] pairs)
        {
            if (words1.Length != words2.Length)
            {
                return false;
            }

            var uf = new UnionFind();
            for (var i = 0; i < pairs.GetLength(0); ++i)
            {
                uf.Union(pairs[i, 0], pairs[i, 1]);
            }

            for (var i = 0; i < words1.Length; ++i)
            {
                if (words1[i] == words2[i])
                {
                    
                }
                else if (uf.ContainsEntry(words1[i]) && uf.ContainsEntry(words2[i]))
                {
                    if (uf.Find(words1[i]) != uf.Find(words2[i]))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
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
