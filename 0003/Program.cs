using System;
using System.Collections.Generic;

namespace _3
{
    public class Solution 
    {
        public int LengthOfLongestSubstring(string s) 
        {
            if (String.IsNullOrEmpty(s))
            {
                return 0;
            }
            var best = 1;
            var left = 0;
            var lastpos = new Dictionary<char, int>();
            lastpos[s[0]] = 0;

            for (var right = 1; right < s.Length; ++right)
            {
                if (lastpos.ContainsKey(s[right]))
                {
                    var lastidx = lastpos[s[right]] + 1;
                    for (var i = left; i < lastidx; ++i)
                    {
                        lastpos.Remove(s[i]);
                    }
                    left = lastidx;
                }
                else
                {
                    best = Math.Max(best, right - left + 1);
                }

                lastpos[s[right]] = right;           
            }

            return best;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().LengthOfLongestSubstring("abcabcbb"));
            Console.WriteLine(new Solution().LengthOfLongestSubstring("bbbbbbb"));
            Console.WriteLine(new Solution().LengthOfLongestSubstring("pwwkew"));
        }
    }
}
