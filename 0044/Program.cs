using System;

namespace _0044
{
    public class Solution
    {
        public bool IsMatch(string s, string p)
        {
            if (s == null || p == null)
            {
                return false;
            }

            // first | is for padding, avoid access -1 index.  second | is to handle empty string case
            s = "||" + s;
            p = "||" + p;
            var len1 = s.Length;
            var len2 = p.Length;
            var f = new bool[len1, len2];
            f[0, 0] = true;

            for (var i = 1; i < len1; ++i)
            {
                for (var j = 1; j < len2; ++j)
                {
                    if (s[i] == p[j] || p[j] == '?')
                    {
                        f[i, j] = f[i - 1, j - 1];
                    }
                    else if (p[j] == '*')
                    {
                        f[i, j] = 
                            f[i - 1, j - 1] // match * with any s[i], first time using *
                            || 
                            f[i, j - 1] // * stands for empty char
                            ||
                            f[i - 1, j] // match * with any s[i], not first time using *
                            ;

                    }
                }
            }

            return f[len1 - 1, len2 - 1];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().IsMatch("", "");
            Console.WriteLine("Hello World!");
        }
    }
}
