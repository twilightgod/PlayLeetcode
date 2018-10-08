using System;

namespace _0727
{
    public class Solution
    {
        public string MinWindow(string S, string T)
        {
            // padding
            S = "|" + S;
            T = "|" + T;
            var len1 = S.Length;
            var len2 = T.Length;
            // f[i, j] means the min len needs in S[0..i] to match T[0..j]
            var f = new int[len1, len2];

            for (var j = 1; j < len2; ++j)
            {
                f[0, j] = Int32.MaxValue;
            }

            for (var i = 0; i < len1; ++i)
            {
                f[i, 0] = 0;
            }

            var minLen = Int32.MaxValue;
            var minIndex = -1;

            for (var i = 1; i < len1; ++i)
            {
                for (var j = 1; j < len2; ++j)
                {
                    // init for impossible
                    f[i, j] = Int32.MaxValue;
                    
                    if (f[i - 1, j] != Int32.MaxValue)
                    {
                        f[i, j] = f[i - 1, j] + 1;                    
                    }
                    
                    if (S[i] == T[j] && f[i - 1, j - 1] != Int32.MaxValue && f[i, j] > f[i - 1, j - 1] + 1)
                    {
                        f[i, j] = f[i - 1, j - 1] + 1;
                    }
                }
                if (minLen > f[i, len2 - 1])
                {
                    minLen = f[i, len2 - 1];
                    minIndex = i - f[i, len2 - 1] + 1;
                }
            }

            return (minLen == Int32.MaxValue ? String.Empty : S.Substring(minIndex, minLen));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().MinWindow("abcdebdde", "bde"));
            Console.WriteLine("Hello World!");
        }
    }
}
