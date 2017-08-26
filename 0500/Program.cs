using System;
using System.Collections.Generic;

namespace _0500
{
    public class Solution
    {
        private static Dictionary<char, int> mapping = new Dictionary<char, int>()
            {
                ['q'] = 0,
                ['w'] = 0,
                ['e'] = 0,
                ['r'] = 0,
                ['t'] = 0,
                ['y'] = 0,
                ['u'] = 0,
                ['i'] = 0,
                ['o'] = 0,
                ['p'] = 0,
                ['a'] = 1,
                ['s'] = 1,
                ['s'] = 1,
                ['d'] = 1,
                ['f'] = 1,
                ['g'] = 1,
                ['h'] = 1,
                ['j'] = 1,
                ['k'] = 1,
                ['l'] = 1,
                ['z'] = 2,
                ['x'] = 2,
                ['c'] = 2,
                ['v'] = 2,
                ['b'] = 2,
                ['n'] = 2,
                ['m'] = 2,
            };

        public string[] FindWords(string[] words)
        {
            var ans = new List<string>(words.Length);

            foreach (var word in words)
            {
                var lword = word.ToLower();
                var rows = new HashSet<int>();
                foreach (var c in lword)
                {
                    rows.Add(mapping[c]);
                }
                if (rows.Count == 1)
                {
                    ans.Add(word);
                }
            }

            return ans.ToArray();
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
