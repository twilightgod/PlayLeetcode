using System;
using System.Text;

namespace _0664
{
    public class Solution
    {
        public int StrangePrinter(string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                return 0;
            }
            // compress the string, remove continous ones
            var sb = new StringBuilder();
            sb.Append(s[0]);
            var n = s.Length;
            for (var i = 1; i < n; ++i)
            {
                if (s[i] != s[i - 1])
                {
                    sb.Append(s[i]);
                }
            }
            var s1 = sb.ToString();
            n = s1.Length;
            var f = new int[n, n];
            for (var len = 1; len <= n; ++len)
            {
                for (var i = 0; i < n; ++i)
                {
                    var j = len + i - 1;
                    if (j >= n)
                    {
                        continue;
                    }
                    if (len == 1)
                    {
                        // single char, just print it
                        f[i, j] = 1;
                    }
                    else
                    {
                        // base line is just adding j-th at the end of [i, j - 1]
                        f[i, j] = f[i, j - 1] + 1;
                        // try to find an index k, such that s1[k] == s1[j], then we can save 1 operation by print [k, j] together
                        for (var k = i; k < j; ++k)
                        {
                            if (s1[k] == s1[j])
                            {
                                f[i, j] = Math.Min(f[i, j], f[i, k] + f[k + 1, j - 1]);
                            }
                        }
                    }
                }
            }
            return f[0, n - 1];
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
