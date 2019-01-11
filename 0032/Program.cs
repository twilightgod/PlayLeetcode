using System;
using System.Collections.Generic;

namespace _0032
{
    public class Solution
    {
        public int LongestValidParentheses(string s)
        {
            var stack = new Stack<int>();
            var best = 0;
            var score = 0;

            foreach (var c in s)
            {
                if (c == '(')
                {
                    stack.Push(score + 2);
                    score = 0;
                }
                else
                {
                    // illegal ')'
                    if (stack.Count == 0)
                    {
                        stack.Clear();
                        score = 0;
                    }
                    else // normal ')'
                    {
                        score += stack.Pop();
                        best = Math.Max(best, score);                        
                    }
                }
            }
            return best;
        }
    }

    class Program
    {/* 
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }*/
    }
}
