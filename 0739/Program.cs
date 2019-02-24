using System;
using System.Collections.Generic;

namespace _0739
{
    public class Solution
    {
        public int[] DailyTemperatures(int[] T)
        {
            var n = T.Length;
            var answer = new int[n];
            // non-asc mono stack
            var stack = new Stack<int>();
            for (var i = 0; i < n; ++i)
            {
                while (stack.Count > 0 && T[stack.Peek()] < T[i])
                {
                    answer[stack.Peek()] = i - stack.Peek();
                    stack.Pop();
                }
                stack.Push(i);
            }
            return answer;
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
