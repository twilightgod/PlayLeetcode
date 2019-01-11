using System;
using System.Collections.Generic;

namespace _0032_1
{
    public class Solution
    {
        public int LongestValidParentheses(string s)
        {
            var lCount = 0;
            var rCount = 0;
            var best = 0;

            for (var i = 0; i < s.Length; ++i)
            {
                if (s[i] == '(')
                {
                    lCount++;
                }
                else
                {
                    rCount++;
                    if (lCount == rCount)
                    {
                        best = Math.Max(best, lCount + rCount);
                    }
                    else if (lCount < rCount)
                    {
                        lCount = 0;
                        rCount = 0;
                    }
                }
            }

            lCount = 0;
            rCount = 0;

            for (var i = s.Length - 1; i >= 0; --i)
            {
                if (s[i] == ')')
                {
                    rCount++;
                }
                else
                {
                    lCount++;
                    if (lCount == rCount)
                    {
                        best = Math.Max(best, lCount + rCount);
                    }
                    else if (lCount > rCount)
                    {
                        lCount = 0;
                        rCount = 0;
                    }
                }
            }

            return best;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().LongestValidParentheses("(()"));
            Console.WriteLine("Hello World!");
        }
    }
}
