using System;

namespace _0072
{
    public class Solution
    {
        public int MinDistance(string word1, string word2)
        {
            var n1 = word1.Length;
            var n2 = word2.Length;
            // f[i, j] means process first i chars in word1 and first j chars in word2, what's the min edit distance
            var f = new int[n1 + 1, n2 + 1];

            for (var i = 0; i <= n1; ++i)
            {
                f[i, 0] = i;
            }
            for (var j = 0; j <= n2; ++j)
            {
                f[0, j] = j;
            }
            for (var i = 1; i <= n1; ++i)
            {
                for (var j = 1; j <= n2; ++j)
                {
                    // replace
                    f[i, j] = f[i - 1, j - 1];
                    if (word1[i - 1] != word2[j - 1])
                    {
                        f[i, j]++;
                        // insert/delete
                        f[i, j] = Math.Min(f[i, j], Math.Min(f[i - 1, j], f[i, j - 1]) + 1);
                    }
                }
            }

            return f[n1, n2];
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
