using System;
using System.Collections.Generic;

namespace _0402
{
    public class Solution
    {
        public string RemoveKdigits(string num, int k)
        {
            var n = num.Length;
            if (n <= k)
            {
                return "0";
            }

            var stack = new Stack<char>();
            foreach (var c in num)
            {
                while (k > 0 && stack.Count > 0 && stack.Peek() > c)
                {
                    stack.Pop();
                    k--;
                }
                stack.Push(c);
            }

            // asc order
            while (k > 0 && stack.Count > 0)
            {
                stack.Pop();
                k--;
            }

            var answerArray = stack.ToArray();
            Array.Reverse(answerArray);
            var answerTrim = (new String(answerArray)).TrimStart(new char[]{'0'});
            return answerTrim.Length == 0 ? "0" : answerTrim;
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
