using System;

namespace _0516
{
    public class Solution
    {
        public int LongestPalindromeSubseq(string s)
        {
            var n = s.Length;
            // f[i, j] means the length of longest palindrome in s[i..j]
            var f = new int[n, n];
            
            for (var len = 1; len <= n; ++len)
            {
                for (var i = 0; i <= n - len; ++i)
                {
                    var j = i + len - 1;
                    if (i == j)
                    {
                        f[i, j] = 1;
                    }
                    else if (s[i] == s[j])
                    {
                        f[i, j] = f[i + 1, j - 1] + 2;
                    }
                    else
                    {
                        f[i, j] = Math.Max(f[i + 1, j], f[i, j - 1]);
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
