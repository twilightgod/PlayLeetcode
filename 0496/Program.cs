using System;
using System.Collections.Generic;

namespace _0496
{
    public class Solution
    {
        public int[] NextGreaterElement(int[] findNums, int[] nums)
        {
            var nextMap = new Dictionary<int, int>();
            var stack = new Stack<int>();
            var answer = new int[findNums.Length];
            foreach (var num in nums)
            {
                while (stack.Count > 0 && stack.Peek() < num)
                {
                    nextMap[stack.Pop()] = num;
                }
                stack.Push(num);
            }
            for (var i = 0; i < findNums.Length; ++i)
            {
                answer[i] = nextMap.GetValueOrDefault(findNums[i], -1);
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
