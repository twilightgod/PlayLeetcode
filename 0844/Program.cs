using System;
using System.Collections.Generic;

namespace _0844
{
    public class Solution
    {
        public bool BackspaceCompare(string S, string T)
        {
            return GetBackspaceString(S) == GetBackspaceString(T);
        }

        private string GetBackspaceString(string s)
        {
            var stack = new Stack<char>();
            foreach (var c in s)
            {
                if (c == '#')
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                }
                else
                {
                    stack.Push(c);
                }
            }
            return new String(stack.ToArray());
        }
    }

    class Program
    {
        static void Main1(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
