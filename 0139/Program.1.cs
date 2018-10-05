using System;
using System.Collections.Generic;
using System.Linq;

namespace _0139_1
{
    public class Solution
    {
        public bool WordBreak(string s, IList<string> wordDict)
        {
            var f = new Dictionary<string, bool>();
            var wordSet = new HashSet<string>(wordDict);
            f[String.Empty] = true;

            return DP(s, wordSet, f);
        }

        private bool DP(string s, HashSet<string> wordSet, Dictionary<string, bool> f)
        {
            if (f.ContainsKey(s))
            {
                return f[s];
            }

            f[s] = false;

            // left part length is i
            for (var i = 0; i < s.Length; ++i)
            {
                var right = s.Substring(i, s.Length - i);
                if (wordSet.Contains(right))
                {
                    var left = s.Substring(0, i);
                    if (DP(left, wordSet, f))
                    {
                        f[s] = true;
                        break;
                    }
                }
            }

            return f[s];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().WordBreak("leetcode", new List<string>(){"leet","code"});
            new Solution().WordBreak("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", new List<string>(){"a","aa","aaa","aaaa","aaaaa","aaaaaa","aaaaaaa","aaaaaaaa","aaaaaaaaa","aaaaaaaaaa"});
            Console.WriteLine("Hello World!");
        }
    }
}
