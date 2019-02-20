using System;
using System.Collections.Generic;
using System.Text;

namespace _0269
{
    public class Solution
    {
        public string AlienOrder(string[] words)
        {
            var indegree = new Dictionary<char, int>();
            var edge = new Dictionary<char, HashSet<char>>();
            var allChars = new HashSet<char>();

            // get all the chars appear in dict
            for (var i = 0; i < words.Length; ++i)
            {
                foreach (var c in words[i])
                {
                    allChars.Add(c);
                }
            }

            // build the graph
            for (var i = 0; i < words.Length - 1; ++i)
            {
                // only compare within the min length of word i and word i + 1
                for (var j = 0; j < words[i].Length && j < words[i + 1].Length; ++j)
                {
                    var c1 = words[i][j];
                    var c2 = words[i + 1][j];
                    if (c1 != c2)
                    {
                        indegree.TryAdd(c1, 0);
                        indegree.TryAdd(c2, 0);
                        edge.TryAdd(c1, new HashSet<char>());
                        edge.TryAdd(c2, new HashSet<char>());
                        
                        // we may have duplicate edge, only increase indegree count for the first time (Add returns true)
                        if (edge[c1].Add(c2))
                        {
                            indegree[c2]++;
                        }

                        // if the char has relationship (orders), we don't need to track them at the end
                        allChars.Remove(c1);
                        allChars.Remove(c2);
                        break;
                    }
                }
            }

            // put all zero indegree chars into q
            var q = new Queue<char>();
            foreach (var c in indegree.Keys)
            {
                if (indegree[c] == 0)
                {
                    q.Enqueue(c);
                }
            }

            // BFS
            var sb = new StringBuilder();
            while (q.Count > 0)
            {
                var node = q.Dequeue();
                sb.Append(node);
                foreach (var c in edge[node])
                {
                    if (--indegree[c] == 0)
                    {
                        q.Enqueue(c);
                    }
                }
                indegree.Remove(node);
            }

            // detect a loop, no answer
            if (indegree.Count > 0)
            {
                return String.Empty;
            }

            // append all the chars we don't know the order
            foreach (var c in allChars)
            {
                sb.Append(c);
            }

            return sb.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().AlienOrder(new string[]{"za","zb","ca","cb"});
            Console.WriteLine("Hello World!");
        }
    }
}
