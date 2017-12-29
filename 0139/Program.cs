using System;
using System.Collections.Generic;
using System.Linq;

namespace _0139
{
    public class Solution
    {
        public bool WordBreak(string s, IList<string> wordDict)
        {
            // shift 1 index for handling starting point (0)
            // 1 is possible, 0 is impossible, -1 is never visit
            var f = Enumerable.Repeat(-1, s.Length + 1).ToList();
            f[0] = 1;
            var dict = wordDict.ToList();
            dict.Sort((x,y)=>-(x.Length.CompareTo(y.Length)));

            return MemorizedDFS(s, s.Length, f, dict) == 1;
        }

        private int MemorizedDFS(string s, int depth, List<int> f, List<string> wordDict)
        {
            Console.WriteLine(depth);
            if (f[depth] != -1)
            {
                Console.WriteLine("DirectReturn");
                return f[depth];
            }

            f[depth] = 0;
            foreach (var word in wordDict)
            {
                if (word.Length <= depth && s.Substring(depth - word.Length, word.Length) == word)
                {
                    if (MemorizedDFS(s, depth - word.Length, f, wordDict) == 1)
                    {
                        f[depth] = 1;
                        break;
                    }
                }
            }

            Console.WriteLine("FinalReturn");
            return f[depth];
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
