using System;
using System.Collections.Generic;

namespace _0162
{
    public class Solution
    {
        public int FindPeakElement(int[] nums)
        {
            var l = 0;
            var r = nums.Length;

            while (l < r)
            {
                var m = l + (r - l) / 2;
                var isLeftPeak = m == 0 || nums[m - 1] < nums[m];
                var isRightPeak = m == nums.Length - 1 || nums[m] > nums[m + 1]; 
                if (isLeftPeak && isRightPeak)
                {
                    return m;
                }

                // if m is not peak, then m - 1, m, m + 1 should be in asc or desc order
                // if it's asc (left peak), then peak will exist in right range
                // if it's desc (right peak), then peak will exist in left range
                if (isRightPeak)
                {
                    r = m;
                }
                else
                {
                    l = m + 1;
                }
            }

            return l;
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
