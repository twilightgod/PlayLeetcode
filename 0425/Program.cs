using System;
using System.Collections.Generic;
using System.Text;

namespace _0425
{
    class Program
    {
        public class Solution
        {
            public IList<IList<string>> WordSquares(string[] words)
            {
                var answers = new List<IList<string>>();
                if (words == null || words.Length == 0)
                {
                    return answers;
                }

                var n = words[0].Length;
                // key -> prefix     value -> all words starting with key
                var prefixMap = new Dictionary<string, List<string>>();
                foreach (var word in words)
                {
                    for (var i = 0; i < n; ++i)
                    {
                        var prefix = word.Substring(0, i);
                        if (!prefixMap.ContainsKey(prefix))
                        {
                            prefixMap.Add(prefix, new List<string>());
                        }
                        prefixMap[prefix].Add(word);
                    }
                }

                var answer = new string[n];
                DFS(0, n, String.Empty, prefixMap, answer, answers);
                return answers;
            }

            private void DFS(int depth, int n, string prefix, Dictionary<string, List<string>> prefixMap, string[] answer, List<IList<string>> answers)
            {
                if (depth == n)
                {
                    answers.Add(new List<string>(answer));
                    return;
                }

                // loop through all words starting with prefix
                foreach (var word in prefixMap[prefix])
                {
                    answer[depth] = word;
                    // get prefix based on current answer sequence
                    var nextprefix = String.Empty;
                    // special handling for last one, since we need to access depth + 1 index
                    if (depth < n - 1)
                    {
                        var sb = new StringBuilder();
                        for (var i = 0; i <= depth; ++i)
                        {
                            sb.Append(answer[i][depth + 1]);
                        }
                        nextprefix = sb.ToString();
                    }
                    if (prefixMap.ContainsKey(nextprefix))
                    {
                        DFS(depth + 1, n, nextprefix, prefixMap, answer, answers);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            new Solution().WordSquares(new string[]{"area","lead","wall","lady","ball"});
            Console.WriteLine("Hello World!");
        }
    }
}
