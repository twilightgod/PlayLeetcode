using System;
using System.Collections.Generic;
using System.Linq;

namespace _0140
{
    public class Solution
    {
        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            // shift 1 index for handling starting point (0)
            // 1 is possible, 0 is impossible, -1 is never visit
            var f = Enumerable.Repeat(-1, s.Length + 1).ToList();
            f[0] = 1;

            var ans = new List<List<string>>();
            for (var i = 0; i <= s.Length + 1; ++i)
            {
                ans.Add(new List<string>());
            }

            MemorizedDFS(s, s.Length, f, ans, wordDict);
            return ans[s.Length];
        }

        private int MemorizedDFS(string s, int depth, List<int> f, List<List<string>> ans, IList<string> wordDict)
        {
            //Console.WriteLine(depth);
            if (f[depth] != -1)
            {
                //Console.WriteLine("DirectReturn");
                return f[depth];
            }

            f[depth] = 0;
            foreach (var word in wordDict)
            {
                if (word.Length <= depth && s.Substring(depth - word.Length, word.Length) == word)
                {
                    if (MemorizedDFS(s, depth - word.Length, f, ans, wordDict) == 1)
                    {
                        f[depth] = 1;
                        //break;
                        if (depth - word.Length == 0)
                        {
                            ans[depth].Add(word);
                        }
                        else
                        {
                            foreach (var sentense in ans[depth - word.Length])
                            {
                                ans[depth].Add(sentense + " " + word);
                            }
                        }
                    }
                }
            }

            //Console.WriteLine("FinalReturn");
            return f[depth];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().WordBreak("catsanddog", new List<string>(){"cat","cats","and","sand","dog"});
            Console.WriteLine("Hello World!");
        }
    }
}
