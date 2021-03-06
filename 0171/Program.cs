﻿using System;

namespace _0171
{
    public class Solution
    {
        public int TitleToNumber(string s)
        {
            var ans = 0;
            var acc = 1;
            for (var i = s.Length - 1; i >= 0 ; --i)
            {
                var num = (int)(s[i] - 'A') + 1;

                ans += (acc * num);
                acc *= 26;
            }

            return ans;
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
