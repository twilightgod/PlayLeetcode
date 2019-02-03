using System;
using System.Collections.Generic;

namespace _0228
{
    public class Solution
    {
        public IList<string> SummaryRanges(int[] nums)
        {
            var answer = new List<string>();
            if (nums == null || nums.Length == 0)
            {
                return answer;
            }

            var start = nums[0];
            var end = nums[0];

            for (var i = 1; i < nums.Length; ++i)
            {
                if (end + 1 != nums[i])
                {
                    answer.Add(start == end ? start.ToString() : $"{start}->{end}");
                    start = nums[i];
                }
                end = nums[i];
            }
            answer.Add(start == end ? start.ToString() : $"{start}->{end}");

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
