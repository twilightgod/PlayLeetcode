using System;
using System.Collections.Generic;

namespace _0340
{
    public class Solution
    {
        public int LengthOfLongestSubstringKDistinct(string s, int k)
        {
            var answer = 0;
            var l = 0;
            var dict = new Dictionary<char, int>();
            for (var r = 0; r < s.Length; ++r)
            {
                dict[s[r]] = dict.GetValueOrDefault(s[r], 0) + 1;
                if (dict.Count <= k)
                {
                    answer = Math.Max(answer, r - l + 1);
                }
                else
                {
                    while (dict.Count > k)
                    {
                        if (--dict[s[l]] == 0)
                        {
                            dict.Remove(s[l]);
                        }
                        l++;
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
