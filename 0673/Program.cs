using System;

namespace _0673
{
    public class Solution
    {
        public int FindNumberOfLIS(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            var n = nums.Length;
            var f = new int[n];
            var longest = 1;
            var ways = new int[n];

            for (var i = 0; i < n; ++i)
            {
                f[i] = 1;
                ways[i] = 1;
                for (var j = 0; j < i; ++j)
                {
                    if (nums[i] > nums[j])
                    {
                        if (f[i] < f[j] + 1)
                        {
                            f[i] = f[j] + 1;
                            ways[i] = ways[j];
                        }
                        else if (f[i] == f[j] + 1)
                        {
                            ways[i] += ways[j];
                        }
                    }
                    longest = Math.Max(longest, f[i]);
                }
            }

            var answer = 0;
            for (var i = 0; i < n; ++i)
            {
                //Console.WriteLine($"{i}, {f[i]}, {ways[i]}");
                if (f[i] == longest)
                {
                    answer += ways[i];
                }
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
