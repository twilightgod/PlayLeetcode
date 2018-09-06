using System;
using System.Collections.Generic;

namespace _0076
{
    public class Solution
    {
        public string MinWindow(string s, string t)
        {
            if (String.IsNullOrEmpty(s))
            {
                return String.Empty;
            }

            var goal = new Dictionary<char, int>();
            var current = new Dictionary<char, int>();
            var bestlen = Int32.MaxValue;
            var bestpos = -1;

            foreach (var c in t)
            {
                if (goal.ContainsKey(c))
                {
                    goal[c]++;
                }
                else
                {
                    goal[c] = 1;
                    current[c] = 0;
                }
            }

            var l = 0;
            var r = 0;
            if (goal.ContainsKey(s[l]))
            {
                current[s[l]]++;
            }

            while (r < s.Length)
            {
                if (FoundAnswer(goal, current))
                {
                    // compare overall best
                    if (bestlen > r - l + 1)
                    {
                        bestlen = r - l + 1;
                        bestpos = l;
                    }

                    // move left
                    if (goal.ContainsKey(s[l]))
                    {
                        current[s[l]]--;
                    }
                    l++;
                }
                else
                {
                    // move right
                    r++;
                    if (r < s.Length && goal.ContainsKey(s[r]))
                    {
                        current[s[r]]++;
                    }
                }
            }

            return bestpos == -1 ? String.Empty : s.Substring(bestpos, bestlen);
        }

        private bool FoundAnswer(Dictionary<char, int> goal, Dictionary<char, int> current)
        {
            foreach (var key in goal.Keys)
            {
                if (goal[key] > current[key])
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
            new Solution().MinWindow("ABC", "AC");
        }
    }
}
