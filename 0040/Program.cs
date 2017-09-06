using System;
using System.Collections.Generic;
using System.Linq;

namespace _0040
{
    public class Solution
    {
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            var ans = new List<IList<int>>();
            var current = new List<int>();
            var nums = candidates.ToList();
            // cannot compile in mono... but works in dotnet core 2.0
            //var cnt = new Dictionary<int, int>(nums.GroupBy(x => x).Select(x => KeyValuePair.Create<int, int>(x.Key, x.Count())));
            var cnt = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (!cnt.ContainsKey(num))
                {
                    cnt.Add(num, 0);
                }
                cnt[num]++;
            }
            nums = new List<int>(nums.Distinct());
            nums.Sort();

            DFS(0, nums, cnt, 0, target, current, ans);

            return ans;
        }

        private void DFS(int depth, List<int> nums, Dictionary<int, int> cnt, int sum, int target, List<int> current, List<IList<int>> ans)
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

            for (var i = 0; i <= cnt[nums[depth]] && sum + nums[depth] * i <= target; ++i)
            {
                if (i > 0)
                {
                    current.Add(nums[depth]);
                }
                DFS(depth + 1, nums, cnt, sum + nums[depth] * i, target, new List<int>(current), ans);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().CombinationSum2(new int[]{10,1,2,7,6,1,5}, 8));
        }
    }
}
