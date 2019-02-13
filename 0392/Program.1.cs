using System;
using System.Collections.Generic;

namespace _0392_1
{
    // Brute Force
    public class Solution
    {
        public bool IsSubsequence(string s, string t)
        {
            var lastIdx = -1;
            foreach (var c in s)
            {
                lastIdx = t.IndexOf(c, lastIdx + 1);
                if (lastIdx == -1)
                {
                    return false;
                }
            }
            return true;
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
