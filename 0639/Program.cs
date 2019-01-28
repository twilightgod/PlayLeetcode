using System;
using System.Collections.Generic;

namespace _0639
{
    public class Solution
    {
        const int MOD = 1000000007;

        public int NumDecodings(string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                return 0;
            }
            
            // rolling dp
            // x * 15 where x < MOD will overflow, needs 64bit 
            var f = new long[3];
            f[1] = 1;

            for (var i = 0; i < s.Length; ++i)
            {
                f[2] = (DecodeWays(s[i]) * f[1]
                    + (i > 0 ? DecodeWays(s[i - 1], s[i]) * f[0] : 0)) % MOD;
                f[0] = f[1];
                f[1] = f[2];
            }

            return (Int32)f[1];
        }

        private int DecodeWays(char c1)
        {
            if (c1 == '0')
            {
                return 0;
            }
            else if (c1 == '*')
            {
                return 9;
            }
            else
            {
                return 1;
            }
        }

        private int DecodeWays(char c1, char c2)
        {
            if (c1 == '1')
            {
                if (c2 == '*')
                {
                    return 9; // 11-19
                }
                else
                {
                    return 1;
                }
            }
            else if (c1 == '2')
            {
                if (c2 =='*')
                {
                    return 6; // 21-26
                }
                else if ('0' <= c2 && c2 <= '6')
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else if (c1 == '*')
            {
                if (c2 == '*')
                {
                    return 15; // 11-19, 21-26
                }
                else if ('0' <= c2 && c2 <= '6')
                {
                    return 2; // 10-16, 20-16
                }
                else
                {
                    return 1; //17-19
                }
            }
            else // '0'
            {
                return 0;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().NumDecodings("2839");
            Console.WriteLine("Hello World!");
        }
    }
}
