using System;
using System.Collections.Generic;

namespace _0953
{
    public class Solution
    {
        public bool IsAlienSorted(string[] words, string order)
        {
            var w = new Dictionary<char, int>();
            for (var i = 0; i < 26; ++i)
            {
                w[order[i]] = i;
            }
            w[' '] = -1;
            for (var i = 0; i < words.Length - 1; ++i)
            {
                var s1 = words[i];
                var s2 = words[i + 1];
                for (var j = 0; j < Math.Max(s1.Length, s2.Length); ++j)
                {
                    char c1 = ' ';
                    char c2 = ' ';
                    if (j < s1.Length)
                    {
                        c1 = s1[j];
                    }
                    if (j < s2.Length)
                    {
                        c2 = s2[j];
                    }
                    if (w[c1] == w[c2])
                    {
                        continue;
                    }
                    else if (w[c1] > w[c2])
                    {
                        return false;
                    }
                    else // <
                    {
                        break;
                    }
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
