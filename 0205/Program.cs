using System;
using System.Collections.Generic;

namespace _0205
{
    public class Solution
    {
        public bool IsIsomorphic(string s, string t)
        {
            if (String.IsNullOrEmpty(s) || String.IsNullOrEmpty(t))
            {
                return true;
            }

            var mapping = new Dictionary<char, char>();
            var used = new HashSet<char>();

            for (int i = 0; i < s.Length; ++i)
            {
                if (mapping.ContainsKey(s[i]))
                {
                    if (mapping[s[i]] != t[i])
                    {
                        return false;
                    }
                }
                else
                {
                    if (used.Contains(t[i]))
                    {
                        return false;
                    }
                    mapping[s[i]] = t[i];
                    used.Add(t[i]);
                }
            }

            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().IsIsomorphic("aa", "ab");
            Console.WriteLine("Hello World!");
        }
    }
}
