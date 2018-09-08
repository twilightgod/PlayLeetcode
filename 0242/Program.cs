using System;
using System.Collections.Generic;

namespace _0242
{
    public class Solution
    {
        public bool IsAnagram(string s, string t)
        {
            var goal = new Dictionary<char, int>();
            foreach (var c in s)
            {
                if (goal.ContainsKey(c))
                {
                    goal[c]++;
                }
                else
                {
                    goal[c] = 1;
                }
            }

            foreach (var c in t)
            {
                if (!goal.ContainsKey(c))
                {
                    return false;
                }
                else
                {
                    goal[c]--;
                }
            }

            foreach (var key in goal.Keys)
            {
                if (goal[key] != 0)
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
