using System;
using System.Collections.Generic;
using System.Linq;

namespace _0091
{
    public class Solution {
    public int NumDecodings(string s) {
        /*
        if (String.IsNullOrEmpty(s))
        {
            return 0;
        }
        */
        var f = Enumerable.Repeat(0, s.Length).ToList();

        if (s[0] == '0')
        {
            return 0;
        }
        else
        {
            f[0] = 1;
        }

        for (var i = 1; i < s.Length; ++i)
        {
            if (s[i] != '0')
            {
                // decode ith char
                f[i] = f[i - 1];
            }
            // decode (i-1 ~ i)th chars
            var digits = s.Substring(i - 1, 2);
            var number = Convert.ToInt32(digits);
            if (number >= 10 && number <= 26)
            {
                if (i - 1 == 0)
                {
                    f[i] += 1;
                }
                else
                {
                    f[i] += f[i - 2];
                }
            }
        }

        return f[s.Length - 1];
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
