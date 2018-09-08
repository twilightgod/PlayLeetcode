using System;
using System.Collections.Generic;

namespace _0438
{
    public class Solution
    {
        public IList<int> FindAnagrams(string s, string p)
        {
            var ans = new List<int>();
            if (s.Length < p.Length)
            {
                return ans;
            }

            var goal = new Dictionary<char, int>();
            var current = new Dictionary<char, int>();
            foreach (var c in p)
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

            for (var i = 0; i < s.Length - p.Length + 1; ++i)
            {
                if (i == 0)
                {
                    for (var j = 0; j < p.Length; ++j)
                    {
                        if (goal.ContainsKey(s[j]))
                        {
                            current[s[j]]++;
                        }
                    }
                }
                else
                {
                    if (goal.ContainsKey(s[i - 1]))
                    {
                        current[s[i - 1]]--;
                    }
                    if (goal.ContainsKey(s[i + p.Length - 1]))
                    {
                        current[s[i + p.Length - 1]]++;
                    }
                }
                if (FoundAnswer(goal, current))
                {
                    ans.Add(i);
                }
            }

            return ans;
        }

        private bool FoundAnswer(Dictionary<char, int> goal, Dictionary<char, int> current)
        {
            foreach (var key in goal.Keys)
            {
                if (goal[key] != current[key])
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
