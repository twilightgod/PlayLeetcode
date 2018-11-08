using System;

namespace _0209
{
    public class Solution
    {
        public int MinSubArrayLen(int s, int[] nums)
        {
            var answer = Int32.MaxValue;
            var sum = 0;
            var l = 0;
            for (var r = 0; r < nums.Length; ++r)
            {
                sum += nums[r];
                // try to reduce l
                while (l <= r && sum >= s)
                {
                    answer = Math.Min(answer, r - l + 1);
                    sum -= nums[l++];
                }
            }
            return answer == Int32.MaxValue ? 0 : answer;
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
