using System;
using System.Collections.Generic;

namespace _0085
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
                while (stack.Count > 0 && currentHeight <= heights[stack.Peek()])
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

        public int MaximalRectangle(char[,] matrix)
        {
            var answer = 0;
            var m = matrix.GetLength(0);
            var n = matrix.GetLength(1);
            var heights = new int[n];
            for (var i = 0; i < m; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    heights[j] = matrix[i, j] == '1' ? heights[j] + 1 : 0;
                }
                answer = Math.Max(answer, LargestRectangleArea(heights));
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
