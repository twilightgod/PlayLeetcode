using System;
using System.Collections.Generic;

namespace _0076
{
    public class Solution
    {
        public string MinWindow(string s, string t)
        {
            var answer = String.Empty;
            var minLen = Int32.MaxValue;

            if (String.IsNullOrEmpty(s))
            {
                return answer;
            }

            // get char counts from t
            var charCounts = new Dictionary<char, int>();
            foreach (var c in t)
            {
                charCounts[c] = charCounts.GetValueOrDefault(c, 0) + 1;
            }

            // nonZeros means the number of non zero count chars, it's 0 means current substring s[l..r] contains t
            var nonZeros = charCounts.Count;
            var l = 0;
            for (var r = 0; r < s.Length; ++r)
            {
                if (charCounts.ContainsKey(s[r]) && --charCounts[s[r]] == 0)
                {
                    // found a solution
                    if (--nonZeros == 0)
                    {
                        // move l
                        // need to consider following cases for t = "abc"
                        // aabc
                        // abbc
                        // ddabc
                        // addbc
                        while (l <= r && nonZeros == 0)
                        {
                            // update minLen and answer
                            if (minLen > r - l + 1)
                            {
                                minLen = r - l + 1;
                                answer = s.Substring(l, minLen);
                            }
                            // skip other chars
                            if (!charCounts.ContainsKey(s[l]))
                            {
                                l++;
                            }
                            // moving l results have a target char > 0 (need 1 more)
                            else if (++charCounts[s[l++]] > 0)
                            {
                                ++nonZeros;
                            }
                        }
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
            new Solution().MinWindow("bba", "ba");
        }
    }
}
