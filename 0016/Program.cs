using System;
using System.Linq;

namespace _16
{
    class Program
    {
        public class Solution {
    public int ThreeSumClosest(int[] nums, int target) {
        var sorted = nums.ToList();
        sorted.Sort();
        if (sorted.Count < 3)
        {
            return target;
        }
        var best_val = sorted[0] + sorted[1] + sorted[2];
        var best_diff = int.MaxValue;

        for (int i = 0; i < sorted.Count; ++i)
        {
            var l = i + 1;
            var r = sorted.Count - 1;

            while (l < r)
            {
                var sum = sorted[l] + sorted[r] + sorted[i];
                var diff = Math.Abs(target - sum);
                if (best_diff > diff)
                {
                    best_diff = diff;
                    best_val = sum; 
                }

                if (sum < target)
                {
                    l++;
                }
                else
                {
                    r--;
                }
            }
        }

        return best_val;
    }
}
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().ThreeSumClosest(new int[]{-1,2,1,-4}, 1));
        }
    }
}
