using System;
using System.Collections.Generic;

namespace _20
{
    class Program
    {
        public class Solution {
    public bool IsValid(string s) {
        var stack = new Stack<char>();
        foreach (var c in s)
        {
            if (c == '(' || c == '[' || c == '{')
            {
                stack.Push(c);
            }
            if (c == ')')
            {
                if (stack.Count == 0 || stack.Peek() != '(')
                {
                    return false;
                }
                stack.Pop();
            }
            if (c == ']')
            {
                if (stack.Count == 0 || stack.Peek() != '[')
                {
                    return false;
                }
                stack.Pop();
            }
            if (c == '}')
            {
                if (stack.Count == 0 || stack.Peek() != '{')
                {
                    return false;
                }
                stack.Pop();
            }
        }

        return stack.Count == 0;
        
    }
}
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().IsValid(""));
            Console.WriteLine(new Solution().IsValid("("));
            Console.WriteLine(new Solution().IsValid("}"));
            Console.WriteLine(new Solution().IsValid("([]{}"));
            Console.WriteLine(new Solution().IsValid("([]){}"));
            Console.WriteLine(new Solution().IsValid("([]{(})"));
            Console.WriteLine(new Solution().IsValid("()[]{}"));
        }
    }
}
