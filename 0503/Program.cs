using System;
using System.Collections.Generic;

namespace _0503
{
    public class Solution
    {
        public int[] NextGreaterElements(int[] nums)
        {
            // index stack
            var stack = new Stack<int>();
            var n = nums.Length;
            var answer = new int[n];
            for (var i = 0; i < n; ++i)
            {
                answer[i] = -1;
            }
            for (var i = 0; i < 2 * n; ++i)
            {
                var p = i % n;
                while (stack.Count > 0 && nums[stack.Peek()] < nums[p])
                {
                    var idx = stack.Pop();
                    if (answer[idx] == -1)
                    {
                        answer[idx] = nums[p];
                    }
                }
                stack.Push(p);
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
