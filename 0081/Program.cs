using System;

namespace _0081
{
    public class Solution
    {
        public bool Search(int[] nums, int target)
        {
            var l = 0;
            var r = nums.Length;

            while (l < r)
            {
                var m = l + (r - l) / 2;
                if (nums[m] == target)
                {
                    return true;
                }

                if (nums[l] == nums[r - 1] && nums[l] == nums[m])
                {
                    l++;
                    r--;
                }
                else if (nums[l] <= nums[m])
                {
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

            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().Search(new int[]{2,2,2,0,1}, 0);
            Console.WriteLine("Hello World!");
        }
    }
}
