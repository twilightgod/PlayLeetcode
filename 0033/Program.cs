using System;

namespace _0033
{
    public class Solution
    {
        public int Search(int[] nums, int target)
        {
            var l = 0;
            var r = nums.Length;

            while (l < r)
            {
                var m = l + (r - l) / 2;
                if (nums[m] == target)
                {
                    return m;
                }

                if (nums[l] < nums[m])
                {
                    // left part is asc
                    if (nums[l] <= target && target < nums[m])
                    {
                        r = m;
                    }
                    else
                    {
                        l = m + 1;
                    }
                }
                else
                {
                    // right part is asc
                    if (nums[m] < target && target <= nums[r - 1])
                    {
                        l = m + 1;
                    }
                    else
                    {
                        r = m;
                    }
                }
            }

            return -1;
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
