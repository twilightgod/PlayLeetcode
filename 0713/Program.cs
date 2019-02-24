using System;

namespace _0713
{
    public class Solution
    {
        public int NumSubarrayProductLessThanK(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || k <= 1)
            {
                return 0;
            }

            var answer = 0;
            var l = 0;
            var p = 1;
            for (var r = 0; r < nums.Length; ++r)
            {
                p *= nums[r];
                while (p >= k)
                {
                    p /= nums[l++];
                }
                answer += r - l + 1;
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
