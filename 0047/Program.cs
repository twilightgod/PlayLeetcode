using System;
using System.Collections.Generic;

namespace _0047
{
    public class Solution
    {
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            var answers = new List<IList<int>>();
            var n = nums.Length;
            var used = new bool[n];
            var answer = new int[n];

            DFS(0, nums, used, answer, answers);

            return answers;
        }

        private void DFS(int depth, int[] nums, bool[] used, int[] answer, List<IList<int>> answers)
        {
            if (depth == nums.Length)
            {
                answers.Add(new List<int>(answer));
                return;
            }

            var usedNumberSet = new HashSet<int>();
            for (var i = 0; i < nums.Length; ++i)
            {
                if (!used[i] && !usedNumberSet.Contains(nums[i]))
                {
                    used[i] = true;
                    usedNumberSet.Add(nums[i]);
                    answer[depth] = nums[i];
                    DFS(depth + 1, nums, used, answer, answers);
                    used[i] = false;
                }
            }
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
