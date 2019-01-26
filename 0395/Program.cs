using System;
using System.Collections.Generic;
using System.Linq;

namespace _0395
{
    public class Solution
    {
        public int LongestSubstring(string s, int k)
        {
            if (String.IsNullOrEmpty(s))
            {
                return 0;
            }

            var answer = 0;

            // we can't simply apply normal 2 pointers solution here, since we can't decide when to move left pointer
            // even if the count of left pointer char is less than k for now, but it may appear more in the future scan
            // the trick is to try all 26 possible distinct char set size, so when we have too many distinct chars, then move left pointer
            for (var distinctCharCount = 1; distinctCharCount <= 26; ++distinctCharCount)
            {
                var charDict = new Dictionary<char, int>();
                var l = 0;
                for (var r = 0; r < s.Length; ++r)
                {
                    charDict[s[r]] = charDict.GetValueOrDefault(s[r], 0) + 1;                    
                    while (charDict.Count > distinctCharCount)
                    {
                        if (--charDict[s[l]] == 0)
                        {
                            charDict.Remove(s[l]);
                        }
                        l++;
                    }
                    if (charDict.Values.Min() >= k)
                    {
                        answer = Math.Max(answer, r - l + 1);
                    }
                }
            }

            return answer;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
