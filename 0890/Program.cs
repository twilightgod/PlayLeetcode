using System;
using System.Collections.Generic;

namespace _0890
{
    public class Solution
    {
        public IList<string> FindAndReplacePattern(string[] words, string pattern)
        {
            var answer = new List<string>();

            foreach (var word in words)
            {
                if (IsMatch(word, pattern))
                {
                    answer.Add(word);
                }
            }

            return answer;
        }

        private bool IsMatch(string s1, string s2)
        {
            var mapping = new Dictionary<char, char>();
            var mappedCharSet = new HashSet<char>();

            for (var i = 0; i < s1.Length; ++i)
            {
                var c1 = s1[i];
                var c2 = s2[i];
                if (!mapping.ContainsKey(c1))
                {
                    // one char can only be mapped once
                    if (mappedCharSet.Contains(c2))
                    {
                        return false;
                    }
                    mapping[c1] = c2;
                    mappedCharSet.Add(c2);
                }
                else
                {
                    if (mapping[c1] != c2)
                    {
                        return false;
                    }
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
