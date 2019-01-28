using System;
using System.Collections.Generic;
using System.Linq;

namespace _0091
{
    public class Solution
    {
        public int NumDecodings(string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                return 0;
            }

            // rolling dp
            var f = new int[3];
            f[1] = 1;

            for (var i = 0; i < s.Length; ++i)
            {
                f[2] = DecodeWays(s[i]) * f[1] 
                    + (i > 0 ? DecodeWays(s[i - 1], s[i]) * f[0] : 0);
                f[0] = f[1];
                f[1] = f[2];
            }

            return f[1];
        }

        private int DecodeWays(char c1)
        {
            if (c1 == '0')
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        private int DecodeWays(char c1, char c2)
        {
            if (c1 == '1' || c1 == '2' && c2 <= '6')
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().NumDecodings("12");
            Console.WriteLine("Hello World!");
        }
    }
}
