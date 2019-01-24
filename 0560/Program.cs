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
            var answer = 0;
            foreach (var num in nums)
            {
                sum += num;
                // look for previous sum p, which meets sum - p = k, so p = sum - k 
                answer += sumDic.GetValueOrDefault(sum - k, 0);
                sumDic[sum] = sumDic.GetValueOrDefault(sum, 0) + 1;
            }

            return answer;
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
