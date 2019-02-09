using System;

namespace _0565
{
    public class Solution
    {
        public int ArrayNesting(int[] nums)
        {
            var answer = 0;
            for (var i = 0; i < nums.Length; ++i)
            {
                if (nums[i] != -1)
                {
                    var counter = 0;
                    while (nums[i] != -1)
                    {
                        var preI = i;
                        i = nums[i];
                        nums[preI] = -1;
                        counter++;
                    }
                    answer = Math.Max(answer, counter);
                }
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
