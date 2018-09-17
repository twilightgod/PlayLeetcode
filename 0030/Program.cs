using System;
using System.Collections.Generic;

namespace _0030
{
    public class Solution
    {
        List<int> answers = new List<int>();
        Dictionary<string, int> dict = new Dictionary<string, int>();
        Dictionary<string, int> appearing = new Dictionary<string, int>();

        public IList<int> FindSubstring(string s, string[] words)
        {
            var len = -1;
           
            if (words == null || words.Length == 0)
            {
                return answers;
            }

            foreach (var word in words)
            {
                if (len == -1)
                {
                    len = word.Length;
                }
                else if (word.Length != len)
                {
                    return answers;        
                }
                if (dict.ContainsKey(word))
                {
                    dict[word]++;
                }
                else
                {
                    dict.Add(word, 1);
                }
                appearing[word] = 0;
            }

            // loop starting position
            for (var i = 0; i < len; ++i)
            {
                var l = -1;
                ResetAppearing();
                for (var r = i; r + len - 1 < s.Length; r += len)
                {
                    var word = s.Substring(r, len);
                    if (dict.ContainsKey(word))
                    {
                        if (l == -1)
                        {
                            l = r;
                        }
                        appearing[word]++;
                        while (appearing[word] > dict[word])
                        {
                            appearing[s.Substring(l, len)]--;  
                            l += len;
                        }
                        if (IsAppearingMatchingDict())
                        {
                            answers.Add(l);
                            appearing[s.Substring(l, len)]--;  
                            l += len;
                        }
                    }
                    else
                    {
                        l = -1;
                        ResetAppearing();
                    }
                }
            }

            return answers;
        }

        private void ResetAppearing()
        {
            foreach (var word in dict.Keys)
            {
                appearing[word] = 0;
            }
        }

        private bool IsAppearingMatchingDict()
        {
            foreach (var word in appearing.Keys)
            {
                if (appearing[word] != dict[word])
                {
                    return false;
                }
            }
            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().FindSubstring("aaa", new string[]{"aa", "aa"});
            Console.WriteLine("Hello World!");
        }
    }
}
