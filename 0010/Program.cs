using System;

namespace _0010
{
    public class Solution
    {
        public bool IsMatch(string s, string p)
        {
            if (s == null || p == null)
            {
                return false;
            }

            // first | is to shift index right to avoid [-1]
            // second | is to handle empty string
            s = "||" + s;
            p = "||" + p;

            var m = s.Length;
            var n = p.Length;

            // f[i, j] == true means s[0..i] matches p[0..j]
            var f = new bool[m, n];

            f[0, 0] = true;

            for (var i = 1; i < m; ++i)
            {
                for (var j = 1; j < n; ++j)
                {
                    if (p[j] == '*')
                    {
                        // case 1, s[i] matches p[j - 1], s[i] is generated from p[j - 1] *, so look at i - 1, j
                        if (s[i] == p[j - 1] || p[j - 1] == '.')
                        {
                            f[i, j] = f[i - 1, j];                                
                        }
                        // case 2, don't use this * char (and preceding char) in p, so look at i, j - 2
                        f[i, j] |= f[i, j - 2];
                    }
                    else if (p[j] == '.')
                    {
                        // dot in p[j] matches any char in s[i], so look at i - 1, j - 1
                        f[i, j] = f[i - 1, j - 1];
                    }
                    else
                    {
                        // check i - 1, j - 1 only if s[i] matches p[j]
                        f[i, j] = s[i] == p[j] && f[i - 1, j - 1];
                    }
                }
            }

            return f[m - 1, n - 1];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().IsMatch("aa", "ab*a");
            Console.WriteLine("Hello World!");
        }
    }
}
