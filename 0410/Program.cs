using System;

namespace _0410
{
    public class Solution
    {
        int[] sum = null;

        public int SplitArray(int[] nums, int m)
        {
            if (nums == null || nums.Length == 0)
            {
                throw new Exception("invalid input");
            }

            var n = nums.Length;
            // f[i, j] means split nums[0..j] into i groups, what's the min subgroup sum
            var f = new int[m + 1, n];
            sum = new int[n];
            sum[0] = nums[0];
            for (var i = 1; i < n; ++i)
            {
                sum[i] = sum[i - 1] + nums[i];
            }

            for (var i = 1; i <= m; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    if (i == 1)
                    {
                        f[i, j] = GetSum(0, j);
                    }
                    else
                    {
                        f[i, j] = Int32.MaxValue;
                        // split [0..j] into [0..k] and [k + 1..j], k starts from i - 2 (e.g. i == 2, we have at least 1 element in group 1, so group 2 starts at index 1)
                        for (var k = i - 2; k < j; ++k)
                        {
                            f[i, j] = Math.Min(f[i, j], Math.Max(f[i - 1, k], GetSum(k + 1, j)));
                        }
                    }
                }
            }

            return f[m, n - 1];
        }

        private int GetSum(int start, int end)
        {
            return sum[end] - (start == 0 ? 0 : sum[start - 1]);
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
