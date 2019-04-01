using System;
using System.Collections.Generic;
using System.Linq;

namespace _0336_1
{
    public class Solution
    {
        public IList<IList<int>> PalindromePairs(string[] words)
        {
            if (words == null)
            {
                return null;
            }

            // word -> index
            var dict = new Dictionary<string, int>();
            var n = words.Length;
            var answer = new List<IList<int>>();
            
            for (var i = 0; i < n; ++i)
            {
                dict[ReverseString(words[i])] = i;
            }

            for (var i = 0; i < n; ++i)
            {
                for (var len = 0; len < words[i].Length; ++len)
                {
                    var left = words[i].Substring(0, len);
                    var right = words[i].Substring(len);
                    // left, right, rev(left)
                    if (dict.ContainsKey(left) && dict[left] != i && IsPalindrome(right))
                    {
                        answer.Add(new List<int>(){i, dict[left]});
                    }
                    // rev(right), left, right
                    if (dict.ContainsKey(right) && dict[right] != i && IsPalindrome(left))
                    {
                        answer.Add(new List<int>(){dict[right], i});
                    }
                }
            }

            return answer;
        }

        private string ReverseString(string s)
        {
            return new String(s.ToCharArray().Reverse().ToArray());
        }

        private bool IsPalindrome(string s)
        {
            if (s == String.Empty)
            {
                return true;
            }
            var l = 0;
            var r = s.Length - 1;
            while (l < r)
            {
                if (s[l++] != s[r--])
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
            new Solution().PalindromePairs(new string[]{"abcd", "dcba"});
            new Solution().PalindromePairs(new string[]{"abc", ""});
            Console.WriteLine("Hello World!");
        }
    }
}
