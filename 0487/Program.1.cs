using System;
using System.Collections.Generic;

namespace _0487_1
{
    public class Solution
    {
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            var l = 0;
            var answer = 0;
            var zeroLimit = 1;
            var zeroQ = new Queue<int>();

            for (var r = 0; r < nums.Length; ++r)
            {
                if (nums[r] == 0)
                {
                    zeroQ.Enqueue(r);
                }
                if (zeroQ.Count > zeroLimit)
                {
                    l = zeroQ.Dequeue() + 1;
                }
                answer = Math.Max(answer, r - l + 1);
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
