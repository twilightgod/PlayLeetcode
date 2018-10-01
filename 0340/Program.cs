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
                if (!dict.ContainsKey(s[r]))
                {
                    dict[s[r]] = 0;
                }
                dict[s[r]]++;
                if (dict.Count <= k)
                {
                    answer = Math.Max(answer, r - l + 1);
                }
                else
                {
                    do
                    {
                        if (--dict[s[l]] == 0)
                        {
                            dict.Remove(s[l]);
                        }
                        l++;
                    } while (dict.Count > k);
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
