using System;
using System.Collections.Generic;

namespace _0737
{
    public class UnionFind
    {
        Dictionary<string, string> data = new Dictionary<string, string>();
        bool randomChoice = false;

        public void TryCreateEntry(string entry)
        {
            if (!data.ContainsKey(entry))
            {
                data.Add(entry, entry);
            }
        }

        public string Find(string entry)
        {
            var root = entry;
            while (data[root] != root)
            {
                //data[root] = data[data[root]];
                root = data[root];
            }
            return root;
        }

        public void Union(string entry1, string entry2)
        {
            var root1 = Find(entry1);
            var root2 = Find(entry2);

            if ((randomChoice = !randomChoice) == false)
            {
                data[root1] = root2;
            }
            else
            {
                data[root2] = root1;
            }
        }

        public bool ContainsEntry(string entry)
        {
            return data.ContainsKey(entry);
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
                uf.TryCreateEntry(pairs[i, 0]);
                uf.TryCreateEntry(pairs[i, 1]);
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
