using System;
using System.Collections.Generic;

namespace _0409
{
    public class Solution
    {
        public int LongestPalindrome(string s)
        {
            var cnt = new Dictionary<char, int>();
            foreach (var c in s)
            {
                cnt[c] = cnt.GetValueOrDefault(c) + 1;
            }
            var hasOdd = false;
            var answer = 0;
            foreach (var v in cnt.Values)
            {
                if ((v & 1) == 1)
                {
                    hasOdd = true;
                    answer += (v - 1);
                }
                else
                {
                    answer += v;
                }
            }
            return answer + (hasOdd ? 1 : 0);
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
