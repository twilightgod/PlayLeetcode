using System;
using System.Collections.Generic;
using System.Linq;

namespace _0039
{
    public class Solution
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var ans = new List<IList<int>>();
            var current = new List<int>();
            var nums = candidates.ToList();
            nums.Sort();

            DFS(0, nums, 0, target, current, ans);

            return ans;
        }

        private void DFS(int depth, List<int> nums, int sum, int target, List<int> current, List<IList<int>> ans)
        {
            if (sum == target)
            {
                ans.Add(new List<int>(current));
                return;
            }
            if (depth == nums.Count)
            {
                return;
            }
            if (nums[depth] > target - sum)
            {
                return;
            }

            for (var i = 0; sum + nums[depth] * i <= target; ++i)
            {
                if (i > 0)
                {
                    current.Add(nums[depth]);
                }
                DFS(depth + 1, nums, sum + nums[depth] * i, target, new List<int>(current), ans);
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
