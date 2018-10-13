using System;

namespace _0485
{
    public class Solution
    {
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            var answer = 0;
            var counter = 0;
            foreach (var num in nums)
            {
                if (num == 0)
                {
                    counter = 0;
                }
                else
                {
                    counter++;
                }
                answer = Math.Max(answer, counter);
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
