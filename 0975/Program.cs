using System;
using System.Collections.Generic;

namespace _0975
{
    public class Solution
    {
        public int OddEvenJumps(int[] A)
        {
            var n = A.Length;
            // next equal or larger element idx (closet)
            var nextOdd = new int[n];
            // next equal or smaller element idx (closet)
            var nextEven = new int[n];

            // get pair of (A[i], i)
            var pairs = new List<(int, int)>();
            for (var i = 0; i < n; ++i)
            {
                pairs.Add((A[i], i));
                nextOdd[i] = -1;
            }
            pairs.Sort();
            
            // mono stack to assign next closet index
            // Idx         [0,1,2,3,4,5,6,7]
            // A           [1,2,3,2,1,4,4,5]
            // Sorted Idx  [0,4,1,3,2,5,6,7]
            // Sorted A    [1,1,2,2,3,4,4,5]
            var stack = new Stack<int>();
            for (var i = 0; i < n; ++i)
            {
                var idx = pairs[i].Item2;
                while (stack.Count > 0 && stack.Peek() < idx)
                {
                    nextOdd[stack.Pop()] = idx;
                }
                stack.Push(idx);
            }

            pairs.Clear();
            for (var i = 0; i < n; ++i)
            {
                pairs.Add((-A[i], i));
                nextEven[i] = -1;
            }
            pairs.Sort();
            stack.Clear();
            for (var i = 0; i < n; ++i)
            {
                var idx = pairs[i].Item2;
                while (stack.Count > 0 && stack.Peek() < idx)
                {
                    nextEven[stack.Pop()] = idx;
                }
                stack.Push(idx);
            }

            var jumpOdd = new bool[n];
            var jumpEven = new bool[n];
            var answer = 0;
            for (var i = n - 1; i >= 0; --i)
            {
                if (i == n - 1)
                {
                    jumpOdd[i] = true;
                    jumpEven[i] = true;
                }
                else
                {
                    if (nextOdd[i] != -1)
                    {
                        jumpOdd[i] = jumpEven[nextOdd[i]];
                    }
                    if (nextEven[i] != -1)
                    {
                        jumpEven[i] = jumpOdd[nextEven[i]];
                    }
                }

                if (jumpOdd[i])
                {
                    answer++;
                }
            }

            return answer;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().OddEvenJumps(new int[]{1,2,3,2,1,4,4,5});
            Console.WriteLine("Hello World!");
        }
    }
}
