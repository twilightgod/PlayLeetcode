using System;
using System.Collections.Generic;

namespace _0220
{
    public class Solution
    {
        public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
        {
            if (nums.Length == 0 || t < 0)
            {
                return false;
            }

            var set = new SortedSet<int>();

            for (var i = 0; i < nums.Length; ++i)
            {
                var lowerbound = 0;
                var upperbound = 0;
                checked
                {
                    try
                    {
                        lowerbound = nums[i] - t;
                    }
                    catch (OverflowException ex)
                    {
                        lowerbound = Int32.MinValue;
                    }
                    try
                    {
                        upperbound = nums[i] + t;
                    }
                    catch (OverflowException ex)
                    {
                        upperbound = Int32.MaxValue;
                    }
                }
                
                if (set.GetViewBetween(lowerbound, upperbound).Count > 0)
                {
                    return true;
                }

                set.Add(nums[i]);
                if (i - k >= 0)
                {
                    set.Remove(nums[i - k]);
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
