using System;
using System.Collections.Generic;

namespace _0084
{
    public class Solution
    {
        public int LargestRectangleArea(int[] heights)
        {
            var answer = 0;
            if (heights == null || heights.Length == 0)
            {
                return answer;
            }

            // asc height, store index
            var stack = new Stack<int>();
            for (var i = 0; i <= heights.Length; ++i)
            {
                // add zero at last
                var currentHeight = i == heights.Length ? 0 : heights[i];
                while (stack.Count > 0 && currentHeight < heights[stack.Peek()])
                {
                    var peekIndex = stack.Pop();
                    var peekHeight = heights[peekIndex];
                    var preIndex = stack.Count == 0 ? -1 : stack.Peek();
                    var area = peekHeight * (i - 1 - preIndex);
                    answer = Math.Max(answer, area);
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
            new Solution().LargestRectangleArea(new int[]{2,100,2,1});
            Console.WriteLine("Hello World!");
        }
    }
}
