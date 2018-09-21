using System;
using System.Collections.Generic;
using System.Linq;

namespace _0046
{
    public class Solution
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            var answers = new List<IList<int>>();
            var answer = new int[nums.Length];
            var used = new bool[nums.Length];

            DFS(nums, 0, used, answer, answers);
            
            return answers;
        }

        private void DFS(int[] nums, int depth, bool[] used, int[] answer, IList<IList<int>> answers)
        {
            if (nums.Length == depth)
            {
                answers.Add(answer.ToList());
                return;
            }

            for (int i = 0; i < nums.Length; ++i)
            {
                if (!used[i])
                {
                    used[i] = true;
                    answer[depth] = nums[i];
                    DFS(nums, depth + 1, used, answer, answers);
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
