using System;
using System.Collections.Generic;
using System.Linq;

namespace _0015_1
{
    public class Solution
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var answers = new List<IList<int>>();
            if (nums == null || nums.Length == 0)
            {
                return answers;
            }
            var n = nums.Length;
            var seenSet = new HashSet<int>();
            var answerSet = new HashSet<(int, int, int)>();
            var buffer = new int[3];

            for (var i = 0; i < n; ++i)
            {
                for (var j = i + 1; j < n; ++j)
                {
                    if (seenSet.Contains(-nums[i] - nums[j]))
                    {
                        buffer[0] = -nums[i] - nums[j];
                        buffer[1] = nums[i];
                        buffer[2] = nums[j];
                        Array.Sort(buffer);
                        answerSet.Add((buffer[0], buffer[1], buffer[2]));
                    }
                }
                seenSet.Add(nums[i]);
            }

            foreach (var answer in answerSet)
            {
                answers.Add(new List<int>() { answer.Item1, answer.Item2, answer.Item3 });
            }
            return answers;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var a = new Solution().ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 });
            Console.WriteLine("");
        }
    }
}
