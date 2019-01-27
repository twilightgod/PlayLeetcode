using System;
using System.Collections.Generic;

namespace _0030
{
    public class Solution
    {
        List<int> answers = new List<int>();
        Dictionary<string, int> dict = new Dictionary<string, int>();

        public IList<int> FindSubstring(string s, string[] words)
        {
            if (words == null || words.Length == 0)
            {
                return answers;
            }

            var len = words[0].Length;

            foreach (var word in words)
            {
                if (word.Length != len)
                {
                    return answers;
                }
                dict[word] = dict.GetValueOrDefault(word, 0) + 1;
            }

            // loop starting position
            for (var i = 0; i < len; ++i)
            {
                var l = i;
                var zeros = dict.Count;
                var dictCopied = new Dictionary<string, int>(dict);
                for (var r = i; r + len - 1 < s.Length; r += len)
                {
                    var word = s.Substring(r, len);
                    if (dictCopied.ContainsKey(word))
                    {
                        if (--dictCopied[word] == 0)
                        {
                            zeros--;
                        }
                        else if (dictCopied[word] == -1)
                        {
                            zeros++;
                        }
                        while (dictCopied[word] < 0)
                        {
                            if (++dictCopied[s.Substring(l, len)] == 0)
                            {
                                zeros--;
                            }
                            else
                            {
                                zeros++;
                            }
                            l += len;
                        }
                        if (zeros == 0)
                        {
                            answers.Add(l);
                        }
                    }
                    else
                    {
                        zeros = dict.Count;
                        dictCopied = new Dictionary<string, int>(dict);
                        l = r + len;
                    }
                }
            }

            return answers;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().FindSubstring("barfoothebarfooman", new string[] { "foo", "bar", "the" });
            Console.WriteLine("Hello World!");
        }
    }
}
