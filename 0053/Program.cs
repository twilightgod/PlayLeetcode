using System;

namespace _53
{
    public class Solution {
    public int MaxSubArray(int[] nums) {
        var best = Int32.MinValue;
        var sum = 0;

        for (int i = 0; i < nums.Length; ++i)
        {
            sum += nums[i];
            best = Math.Max(best, sum);
            if (sum < 0)
            {
                sum = 0;
            }
        }

        return best;
    }
}
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().MaxSubArray(new int[]{-2,1,-3,4,-1,2,1,-5,4}));
        }
    }
}
