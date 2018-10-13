using System;

namespace _0487
{
    public class Solution
    {
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            var l = 0;
            var zeroCount = 0;
            var answer = 0;
            var zeroLimit = 1;

            for (var r = 0; r < nums.Length; ++r)
            {
                if (nums[r] == 0)
                {
                    zeroCount++;
                }
                while (zeroCount > zeroLimit)
                {
                    if (nums[l++] == 0)
                    {
                        zeroCount--;
                    }
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
