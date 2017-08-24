using System;
using System.Collections.Generic;

namespace _0022
{
    public class Solution
    {
        public IList<string> GenerateParenthesis(int n)
        {
            var result = new List<string>();
            var ans = new char[2 * n];
            _GenerateParenthesis(n, 0, result, ans, 0, 0);
            return result;
        }

        private void _GenerateParenthesis(int n, int depth, List<string> result, char[] ans, int LCount, int RCount)
        {
            if (depth == 2 * n)
            {
                result.Add(new String(ans));
            }
            else
            {
                if (LCount < n)
                {
                    ans[depth] = '(';
                    _GenerateParenthesis(n, depth + 1, result, ans, LCount + 1, RCount);
                }
                if (RCount < n && RCount < LCount)
                {
                    ans[depth] = ')';
                    _GenerateParenthesis(n, depth + 1, result, ans, LCount, RCount + 1);
                }
            }
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
