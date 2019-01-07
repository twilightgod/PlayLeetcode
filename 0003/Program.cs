using System;
using System.Collections.Generic;

namespace _0003
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
            var charSet = new HashSet<char>();

            for (var right = 0; right < s.Length; ++right)
            {
                while (charSet.Contains(s[right]))
                {
                    charSet.Remove(s[left++]);
                }
                charSet.Add(s[right]);
                best = Math.Max(best, right - left + 1);
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
