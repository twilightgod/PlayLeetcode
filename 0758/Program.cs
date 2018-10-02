using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0758
{
    public class Solution
    {
        public string BoldWords(string[] words, string S)
        {
            if (words == null || words.Length == 0 || String.IsNullOrEmpty(S))
            {
                return S;
            }

            var wordLens = words.Select(x => x.Length).Distinct();
            var n = S.Length;
            var isBold = new bool[n];
            var dict = new HashSet<string>();
            foreach (var word in words)
            {
                dict.Add(word);
            }

            foreach (var len in wordLens)
            {
                for (var i = 0; i <= n - len; ++i)
                {
                    if (dict.Contains(S.Substring(i, len)))
                    {
                        for (var j = i; j <= i + len - 1; ++j)
                        {
                            isBold[j] = true;
                        }
                    }
                }
            }

            var sb = new StringBuilder();
            var tagBegin = "<b>";
            var tagEnd = "</b>";
            for (var i = 0; i < n; ++i)
            {
                if (i == 0 && isBold[0] || i > 0 && isBold[i] && !isBold[i - 1])
                {
                    sb.Append(tagBegin);
                }
                sb.Append(S[i]);
                if (i == n - 1 && isBold[n - 1] || i < n - 1 && isBold[i] && !isBold[i + 1])
                {
                    sb.Append(tagEnd);
                }
            }

            return sb.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().BoldWords(new string[]{"ab", "bc"}, "aabcd");
            Console.WriteLine("Hello World!");
        }
    }
}
