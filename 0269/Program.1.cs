using System;
using System.Collections.Generic;
using System.Text;

namespace _0269_1
{
    public class Solution
    {
        public string AlienOrder(string[] words)
        {
            var charSet = new HashSet<char>();
            // in-degree
            var d = new Dictionary<char, int>();
            var sb = new StringBuilder();
            var edge = new Dictionary<char, HashSet<char>>();

            // get all the chars appear in dict
            for (var i = 0; i < words.Length; ++i)
            {
                foreach (var c in words[i])
                {
                    if (charSet.Add(c))
                    {
                        d[c] = 0;
                        edge[c] = new HashSet<char>();
                    }
                }
            }

            for (var i = 0; i < words.Length - 1; ++i)
            {
                for (var j = 0; j < Math.Min(words[i].Length, words[i + 1].Length); ++j)
                {
                    var c1 = words[i][j];
                    var c2 = words[i + 1][j];
                    if (c1 != c2)
                    {
                        if (edge[c1].Add(c2))
                        {
                            d[c2]++;
                        }
                        break;
                    }
                }
            }

            var q = new Queue<char>();
            foreach (var kvp in d)
            {
                if (kvp.Value == 0)
                {
                    q.Enqueue(kvp.Key);
                }
            }

            while (q.Count > 0)
            {
                var c = q.Dequeue();
                sb.Append(c);
                charSet.Remove(c);
                foreach (var nextc in edge[c])
                {
                    if (--d[nextc] == 0)
                    {
                        q.Enqueue(nextc);
                    }
                }
            }

            return charSet.Count > 0 ? String.Empty : sb.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().AlienOrder(new string[] { "za", "zb", "ca", "cb" });
            Console.WriteLine("Hello World!");
        }
    }
}
