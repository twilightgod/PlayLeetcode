using System;

namespace _0689
{
    public class Solution
    {
        public int[] MaxSumOfThreeSubarrays(int[] nums, int k)
        {
            var n = nums.Length;
            var sums = new int[n];
            sums[0] = nums[0];
            for (var i = 1; i < n; ++i)
            {
                sums[i] = nums[i] + sums[i - 1];
            }

            // calculate 1st subarray
            // maxSubarray_left[i] means max subarray with length k in [0 .. i]
            var maxSubarray_left = new int[n];
            var maxSubarray_left_index = new int[n];
            maxSubarray_left[k - 1] = GetSum(sums, 0, k - 1);
            maxSubarray_left_index[k - 1] = 0;
            for (var i = k; i < n - 2 * k ; ++i)
            {
                maxSubarray_left[i] = maxSubarray_left[i - 1];
                maxSubarray_left_index[i] = maxSubarray_left_index[i - 1];
                var t = GetSum(sums, i - k + 1, i);
                if (maxSubarray_left[i] < t)
                {
                    maxSubarray_left[i] = t;
                    maxSubarray_left_index[i] = i - k + 1;
                }
            }

            // calculate 3rd subarray
            // maxSubarray_right[i] means max subarray with length k in [i .. n - 1]
            var maxSubarray_right = new int[n];
            var maxSubarray_right_index = new int[n];
            maxSubarray_right[n - k] = GetSum(sums, n - k, n - 1);
            maxSubarray_right_index[n - k] = n - k;
            for (var i = n - k - 1; i >= 2 * k; --i)
            {
                maxSubarray_right[i] = maxSubarray_right[i + 1];
                maxSubarray_right_index[i] = maxSubarray_right_index[i + 1];
                // <= here, since we need the smallest in dictionary order
                var t = GetSum(sums, i, i + k - 1);
                if (maxSubarray_right[i] <= t)
                {
                    maxSubarray_right[i] = t;
                    maxSubarray_right_index[i] = i;
                }
            }

            // loop through all possible start index for 2nd subarray
            var answer = 0;
            var answer_index = new int[3];
            for (var i = k; i <= n - 2 * k; ++i)
            {
                var t = maxSubarray_left[i - 1] + GetSum(sums, i, i + k - 1) + maxSubarray_right[i + k];
                if (answer < t)
                {
                    answer = t;
                    answer_index[0] = maxSubarray_left_index[i - 1];
                    answer_index[1] = i;
                    answer_index[2] = maxSubarray_right_index[i + k];
                }
            }

            return answer_index;
        }

        private int GetSum(int[] sums, int begin, int end)
        {
            return sums[end] - (begin == 0 ? 0 : sums[begin - 1]); 
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
