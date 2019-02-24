using System;
using System.Collections.Generic;
using System.Linq;

namespace _0316
{
    public class Solution
    {
        public string RemoveDuplicateLetters(string s)
        {
            var stack = new Stack<char>();
            var cnt = new Dictionary<char, int>();
            foreach (var c in s)
            {
                cnt[c] = cnt.GetValueOrDefault(c) + 1;
            }
            var used = new HashSet<char>();
            foreach (var c in s)
            {
                // reduce count of c
                cnt[c]--;
                // avoid duplication
                if (!used.Contains(c))
                {
                    // if stack top is larger than c and there're more of stack top in the future, we can pop it out to get smaller dictionary order
                    while (stack.Count > 0 && c < stack.Peek() && cnt[stack.Peek()] > 0)
                    {
                        used.Remove(stack.Pop());
                    }
                    used.Add(c);
                    stack.Push(c);
                }
            }
            var chars = stack.ToList();
            chars.Reverse();
            return new String(chars.ToArray());
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
