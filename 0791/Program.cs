using System;
using System.Collections.Generic;

namespace _0791
{
    public class Solution
    {
        public string CustomSortString(string S, string T)
        {
            var rank = new int[26];
            var n = S.Length;
            for (var i = 0; i < n; ++i)
            {
                rank[(int)S[i] - (int)'a'] = i + 1;
            }
            for (var i = 0; i < 26; ++i)
            {
                if (rank[i] == 0)
                {
                    rank[i] = ++n;
                }
            }
            var list = T.ToCharArray();
            Array.Sort(list, (a, b) => rank[(int)a - (int)'a'].CompareTo(rank[(int)b - (int)'a']));
            return new String(list);
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
