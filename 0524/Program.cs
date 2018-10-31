using System;
using System.Collections.Generic;

namespace _0524
{
    public class Solution
    {
        public string FindLongestWord(string s, IList<string> d)
        {
            var dic = new List<string>(d);
            dic.Sort((a, b) => a.Length == b.Length ? a.CompareTo(b) : -a.Length.CompareTo(b.Length));
            foreach (var word in dic)
            {
                if (IsMatch(s, word))
                {
                    return word;
                }
            }
            return String.Empty;
        }

        private bool IsMatch(string s, string word)
        {
            var p = 0;
            foreach (var c in word)
            {
                while (p < s.Length && s[p] != c)
                {
                    p++;
                }
                if (p == s.Length)
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
