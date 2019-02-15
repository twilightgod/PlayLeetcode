using System;
using System.Linq;

namespace _0410
{
    // BinarySearch
    public class Solution
    {
        int[] sum = null;

        public int SplitArray(int[] nums, int m)
        {
            if (nums == null || nums.Length == 0)
            {
                throw new Exception("invalid input");
            }

            // test case [1,2147483647] 2
            var l = 0l;
            var r = nums.Select(x => (long)x).Sum() + 1;

            while (l < r)
            {
                var mid = l + (r - l) / 2;
                if (CanFit(nums, m, mid))
                {
                    r = mid;
                }
                else
                {
                    l = mid + 1;
                }
            }

            return (int)l;
        }

        private bool CanFit(int[] nums, int m, long max)
        {
            var group = 1;
            var sum = 0l;
            for (var i = 0; i < nums.Length; ++i)
            {
                sum += nums[i];
                if (sum > max)
                {
                    if (++group > m)
                    {
                        return false;
                    }
                    else
                    {
                        sum = 0;
                    }
                    --i;
                }
            }
            return true;
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
