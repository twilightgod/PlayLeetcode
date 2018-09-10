using System;
using System.Collections.Generic;

namespace _0560
{
    public class Solution
    {
        public int SubarraySum(int[] nums, int k)
        {
            var sumDic = new Dictionary<int, int>();
            // 1 way to get nothing
            sumDic[0] = 1;

            var sum = 0;
            var ans = 0;
            foreach (var num in nums)
            {
                sum += num;
                // look for sum - p = k, p is previous sum
                var p = sum - k;
                if (sumDic.ContainsKey(p))
                {
                    ans += sumDic[p];
                }
                if (sumDic.ContainsKey(sum))
                {
                    sumDic[sum]++;
                }
                else
                {
                    sumDic.Add(sum, 1);
                }
            }

            return ans;
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
