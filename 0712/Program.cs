using System;

namespace _0712
{
    public class Solution
    {
        public int MinimumDeleteSum(string s1, string s2)
        {
            // padding
            s1 = '|' + s1;
            s2 = '|' + s2;
            var len1 = s1.Length;
            var len2 = s2.Length;
            var f = new int[len1, len2];
            f[0, 1] = (int)s2[1];
            f[1, 0] = (int)s1[1];
            for (var i = 1; i < len1; ++i)
            {
                f[i, 0] = f[i - 1, 0] + (int)s1[i];
            }
            for (var i = 1; i < len2; ++i)
            {
                f[0, i] = f[0, i - 1] + (int)s2[i];
            }
            for (var i = 1; i < len1; ++i)
            {
                for (var j = 1; j < len2; ++j)
                {
                    // delete s1[i] or s2[j]
                    f[i, j] = Math.Min(f[i - 1, j] + (int)s1[i], f[i, j - 1] + (int)s2[j]);
                    if (s1[i] == s2[j])
                    {
                        // don't need to delete
                        f[i, j] = Math.Min(f[i, j], f[i - 1, j - 1]);
                    }
                }
            }

            return f[len1 - 1, len2 -1];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().MinimumDeleteSum("sea", "eat");
            Console.WriteLine("Hello World!");
        }
    }
}
