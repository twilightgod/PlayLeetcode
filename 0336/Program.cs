using System;
using System.Collections.Generic;
using System.Linq;

namespace _0336
{
    public class Solution
    {
        public IList<IList<int>> PalindromePairs(string[] words)
        {
            var dict = new Dictionary<string, int>();
            for (var i = 0; i < words.Length; ++i)
            {
                dict[ReverseString(words[i])] = i;
            }

            var answersSet = new HashSet<(int, int)>();

            for (var i = 0; i < words.Length; ++i)
            {
                // left, right, reverse(left)
                // reverse(right), left, right
                for (var j = 0; j <= words[i].Length; ++j)
                {
                    var leftStr = words[i].Substring(0, j);
                    var rightStr = words[i].Substring(j);

                    if (dict.ContainsKey(leftStr) && IsPalindrome(rightStr) && dict[leftStr] != i)
                    {
                        answersSet.Add((i, dict[leftStr]));
                    }
                    if (dict.ContainsKey(rightStr) && IsPalindrome(leftStr) && dict[rightStr] != i)
                    {
                        answersSet.Add((dict[rightStr], i));
                    }
                }
            }

            // dedupe
            var answers = new List<IList<int>>();
            foreach (var pair in answersSet)
            {
                answers.Add(new List<int>(){pair.Item1, pair.Item2});
            }
            return answers;
        }

        private string ReverseString(string s)
        {
            return new String(s.ToCharArray().Reverse().ToArray());
        }

        private bool IsPalindrome(string s)
        {
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
        static void Main1(string[] args)
        {
            new Solution().PalindromePairs(new string[]{"abc", ""});
            Console.WriteLine("Hello World!");
        }
    }
}
