using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0491
{
    public class Solution
    {
        public IList<IList<int>> FindSubsequences(int[] nums)
        {
            var ans = new List<IList<int>>();
            var current = new List<int>();
            var set = new HashSet<string>();

            Find(0, nums, current, set, ans);
            
            return ans;
        }

        private void Find(int depth, int[] nums, List<int> current, HashSet<string> set, List<IList<int>> ans)
        {
            if (depth == nums.Length)
            {
                if (current.Count >=2)
                {
                    var hash = string.Join("|", current.Select(x => x.ToString()));
                    if (!set.Contains(hash))
                    {
                        set.Add(hash);
                        ans.Add(new List<int>(current));
                    }
                }

                return;
            }

            // use
            if (current.Count == 0 || current.Count > 0 && nums[depth] >= current.Last())
            {
                current.Add(nums[depth]);
                Find(depth + 1, nums, current, set, ans);
                current.RemoveAt(current.Count - 1);
            }

            // don't use
            Find(depth + 1, nums, current, set, ans);
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
