using System;
using System.Collections.Generic;
using System.Linq;

namespace _0140_1
{
    public class Solution
    {
        public IList<string> WordBreak(string s, IList<string> wordDict)
        {

            var f = new Dictionary<string, List<string>>();
            var wordSet = new HashSet<string>(wordDict);
            f[String.Empty] = new List<string>{String.Empty};

            return DP(s, wordSet, f);
        }

        private List<string> DP(string s, HashSet<string> wordSet, Dictionary<string, List<string>> f)
        {
            if (f.ContainsKey(s))
            {
                return f[s];
            }

            f[s] = new List<string>();

            // left part length is i
            for (var i = 0; i < s.Length; ++i)
            {
                var right = s.Substring(i, s.Length - i);
                if (wordSet.Contains(right))
                {
                    var left = s.Substring(0, i);
                    // need to clone result here, otherwise it will change f[left]
                    var leftResult = new List<string>(DP(left, wordSet, f));
                    if (leftResult.Count > 0)
                    {
                        for (var j = 0; j < leftResult.Count; ++j)
                        {
                            if (leftResult[j] != String.Empty)
                            {
                                leftResult[j] += " ";                           
                            }
                            leftResult[j] += right;
                        }
                        f[s].AddRange(leftResult);
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
            new Solution().WordBreak("catsanddog", new List<string>() { "cat", "cats", "and", "sand", "dog" });
            Console.WriteLine("Hello World!");
        }
    }
}
