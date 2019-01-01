using System;
using System.Collections.Generic;

namespace _0266
{
    public class Solution
    {
        public bool CanPermutePalindrome(string s)
        {
            if (s == null)
            {
                return false;
            }
            var charCount = new Dictionary<char, int>();
            foreach (var c in s)
            {
                charCount[c] = charCount.GetValueOrDefault(c) + 1;
            }
            var oddCount = 0;
            foreach (var val in charCount.Values)
            {
                if (val % 2 == 1)
                {
                    oddCount++;
                }
            }
            return oddCount <= 1;
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
