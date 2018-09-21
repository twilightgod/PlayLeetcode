using System;
using System.Collections.Generic;

namespace _0078
{
    public class Solution
    {
        public IList<IList<int>> Subsets(int[] nums)
        {
            var answers = new List<IList<int>>();
            var answer = new List<int>();

            DFS(nums, 0, answer, answers);

            return answers;
        }

        private void DFS(int[] nums, int depth, List<int> answer, List<IList<int>> answers)
        {
            if (nums.Length == depth)
            {
                answers.Add(new List<int>(answer));
                return;
            }

            DFS(nums, depth + 1, answer, answers);
            
            answer.Add(nums[depth]);
            DFS(nums, depth + 1, answer, answers);
            answer.RemoveAt(answer.Count - 1);
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
