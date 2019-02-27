using System;

namespace _0097
{
    public class Solution
    {
        public bool IsInterleave(string s1, string s2, string s3)
        {
            // padding for empty string
            s1 = "|" + s1;
            s2 = "|" + s2;
            s3 = "||" + s3;
            var l1 = s1.Length;
            var l2 = s2.Length;
            var l3 = s3.Length;
            if (l1 + l2 != l3)
            {
                return false;
            }
            
            // f[i, j] matching first i chars from s3, with first j chars from s1, so i - j chars from s2
            // s3[i - 1] == s1[j - 1]    f[i, j] = f[i - 1, j - 1]   comes from s1
            // s3[i - 1] == s2[i - j - 1]     f[i, j] = f[i - 1, j]
            // could use rolling array to reduce space complexity to O(n)
            var f = new bool[l3 + 1, l1 + 1];
            f[1, 1] = s1[0] == s3[0];
            f[1, 0] = s2[0] == s3[0];
            for (var i = 2; i <= l3; ++i)
            {
                for (var j = 0; j <= i && j <= l1; ++j)
                {
                    if (i - j <= l2)
                    {
                        if (j - 1 >= 0 && s1[j - 1] == s3[i - 1])
                        {
                            f[i, j] |= f[i - 1, j - 1];
                        }
                        if (i - j - 1 >= 0 && s2[i - j - 1] == s3[i - 1])
                        {
                            f[i, j] |= f[i - 1, j];
                        }
                        if (i == l3 && f[i, j])
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().IsInterleave("a", "b", "a");
            Console.WriteLine("Hello World!");
        }
    }
}
