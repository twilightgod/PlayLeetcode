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
            for (var i = 0; i < words.Length; ++i)
            {
                foreach (var c in words[i])
                {
                    allChars.Add(c);
                }
            }
            for (var i = 0; i < words.Length - 1; ++i)
            {
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
                        if (edge[c1].Add(c2))
                        {
                            indegree[c2]++;
                        }
                        allChars.Remove(c1);
                        allChars.Remove(c2);
                        break;
                    }
                }
            }
            var zeroIndegree = new Queue<char>();
            foreach (var c in indegree.Keys)
            {
                if (indegree[c] == 0)
                {
                    zeroIndegree.Enqueue(c);
                }
            }
            var sb = new StringBuilder();
            while (zeroIndegree.Count > 0)
            {
                var node = zeroIndegree.Dequeue();
                sb.Append(node);
                foreach (var c in edge[node])
                {
                    if (--indegree[c] == 0)
                    {
                        zeroIndegree.Enqueue(c);
                    }
                }
                indegree.Remove(node);
            }
            if (indegree.Count > 0)
            {
                return String.Empty;
            }
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
