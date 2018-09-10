using System;
using System.Collections.Generic;

namespace _0325
{
    public class Solution
    {
        public int MaxSubArrayLen(int[] nums, int k)
        {
            // key: sum of [0, i] range
            // value: index, only record the first one since we need to get longest subarray
            var sumDic = new Dictionary<int, int>();
            sumDic[0] = -1;

            var best = 0;
            var sum = 0;
            for (var i = 0; i < nums.Length; ++i)
            {
                sum += nums[i];
                var p = sum - k;
                if (sumDic.ContainsKey(p))
                {
                    var len = i - sumDic[p];
                    best = Math.Max(best, len);
                }
                if (!sumDic.ContainsKey(sum))
                {
                    sumDic[sum] = i;
                }
            }

            return best;
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
