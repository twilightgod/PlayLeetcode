using System;
using System.Collections.Generic;

namespace _0567
{
    public class Solution
    {
        public bool CheckInclusion(string s1, string s2)
        {
            var dict = new Dictionary<char, int>();
            for (var c = 'a'; c <= 'z'; ++c)
            {
                dict.Add(c, 0);
            }
            foreach (var c in s1)
            {
                dict[c]++;
            }

            var l = 0;
            var r = 0;
            while (r < s2.Length)
            {
                dict[s2[r]]--;

                while (dict[s2[r]] < 0 && l <= r)
                {
                    dict[s2[l++]]++;
                }

                if (dict[s2[r]] == 0)
                {
                    if (r - l + 1 == s1.Length)
                    {
                        return true;
                    }
                }
                
                r++;
            }

            return false;
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
