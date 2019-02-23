using System;

namespace _0154
{
    public class Solution
    {
        public int FindMin(int[] nums)
        {
            return DFS(nums, 0, nums.Length - 1);
        }

        private int DFS(int[] nums, int l, int r)
        {
            // single element
            if (l == r)
            {
                return nums[l];
            }
            // already sorted
            else if (nums[l] < nums[r])
            {
                return nums[l];
            }
            // devide and conquer, at least one of the two parts is sorted
            else
            {
                var m = (l + r) / 2;
                return Math.Min(DFS(nums, l, m), DFS(nums, m + 1, r));
            }
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
