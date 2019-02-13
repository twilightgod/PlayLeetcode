using System;
using System.Collections.Generic;

namespace _0392
{
    // BinarySearch
    public class Solution
    {
        public bool IsSubsequence(string s, string t)
        {
            // char -> position mapping in t
            var pos = new Dictionary<char, List<int>>();
            for (var i = 0; i < t.Length; ++i)
            {
                var c = t[i];
                pos.TryAdd(c, new List<int>());
                pos[c].Add(i);
            }
            // greedy to find the earliest position since last char in s
            var lastIdx = -1;
            foreach (var c in s)
            {
                if (!pos.ContainsKey(c))
                {
                    return false;
                }
                var idx = pos[c].BinarySearch(lastIdx + 1);
                // didn't find exact match
                if (idx < 0)
                {
                    idx = ~idx;
                    if (idx == pos[c].Count)
                    {
                        // out of range, doesn't exist
                        return false;
                    }
                    else
                    {
                        
                    }
                }
                lastIdx = pos[c][idx];
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
