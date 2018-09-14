using System;

namespace _0387
{
    public class Solution
    {
        public int FirstUniqChar(string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                return -1;
            }

            var counter = new int[26];
            foreach (var c in s)
            {
                counter[(int)c - (int)'a']++;
            }

            var first = -1;
            for (var i = 0; i < s.Length; ++i)
            {
                if (counter[(int)s[i] - (int)'a'] == 1)
                {
                    first = i;
                    break;
                }
            }

            return first;
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
