using System;
using System.Collections.Generic;

namespace _0523
{
    public class Solution
    {
        public bool CheckSubarraySum(int[] nums, int k)
        {
            // calcuate prefix sum
            // if sum[i] = A * k + C, sum[j] = B * k + C, then sum[i] - sum[j] will be n * k
            // then we only need to track the remaining (C) and the index (need at least 2 length)
            var rem = new Dictionary<int, int>();
            var sum = 0;
            rem[0] = -1;
            for (var i = 0; i < nums.Length; ++i)
            {
                sum += nums[i];
                var r = k == 0 ? sum : sum % k;
                if (rem.ContainsKey(r))
                {
                    if (i - rem[r] >= 2)
                    {
                        return true;
                    }
                }
                else
                {
                    rem.Add(r, i);
                }
            }
            return false;
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
