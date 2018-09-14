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
                var countDic = new Dictionary<char, int>();
                var l = 0;
                var r = -1;

                while (true)
                {
                    if (countDic.Count > distinctCharCount)
                    {
                        countDic[s[l]]--;
                        if (countDic[s[l]] == 0)
                        {
                            countDic.Remove(s[l]);
                        }
                        l++;
                    }
                    else
                    {
                        r++;
                        if (r >= s.Length)
                        {
                            break;
                        }
                        if (!countDic.ContainsKey(s[r]))
                        {
                            countDic.Add(s[r], 1);
                        }
                        else
                        {
                            countDic[s[r]]++;
                        }
                    }
                    if (countDic.Values.Min() >= k)
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
