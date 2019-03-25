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

            // how many distinct chars need to be matched
            var unMatched = charCounts.Count;
            var l = 0;
            for (var r = 0; r < s.Length; ++r)
            {
                // t contians s[r]
                if (charCounts.ContainsKey(s[r]) && --charCounts[s[r]] == 0)
                {
                    // found a solution
                    if (--unMatched == 0)
                    {
                        // try to move l as far as possible in order to get the shortest answer
                        // need to consider following cases for t = "abc"
                        // aabc
                        // abbc
                        // ddabc
                        // addbc
                        while (l <= r && unMatched == 0)
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
                            // update count for s[l], if it's larger than 0, it means we have an unmatched char
                            else if (++charCounts[s[l++]] > 0) 
                            {
                                ++unMatched;
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
            Console.WriteLine(new Solution().MinWindow("bba", "ba"));
        }
    }
}
