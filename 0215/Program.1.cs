using System;
using System.Collections.Generic;
using System.Linq;

namespace _0215_1
{
    public class Solution
    {
        public int FindKthLargest(int[] nums, int k)
        {
            // randomize to avoid O(n^2) case
            var random = new Random();
            for (var i = 0; i < nums.Length; i++)
            {
                Swap(ref nums[i], ref nums[random.Next(i, nums.Length)]);
            }

            k--;
            var l = 0;
            var r = nums.Length;
            while (l < r)
            {
                var m = Partition(nums, l, r);
                if (m == k)
                {
                    return nums[k];
                }
                if (m < k)
                {
                    l = m + 1;
                }
                else
                {
                    r = m;
                }                
            }
            return nums[l];
        }

        private int Partition(int[] nums, int l, int r)
        {
            // l is pivot
            var i = l + 1;
            var j = r - 1;
            while (true)
            {
                while (i < r && nums[i] >= nums[l])
                {
                    i++;
                }
                while (j > l && nums[j] < nums[l])
                {
                    j--;
                }
                if (i >= j)
                {
                    break;
                }
                Swap(ref nums[i], ref nums[j]);
            }
            Swap(ref nums[l], ref nums[j]);
            return j;
        }

        private void Swap(ref int a, ref int b)
        {
            var t = a;
            a = b;
            b = t;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().FindKthLargest(new int[]{3, 2, 1, 5, 6, 4}, 2);
            Console.WriteLine("Hello World!");
        }
    }
}
