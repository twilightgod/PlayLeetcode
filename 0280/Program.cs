using System;

namespace _0280
{
    public class Solution
    {
        public void WiggleSort(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return;
            }
            Array.Sort(nums);
            for (var i = 1; i + 1 < nums.Length; i += 2)
            {
                (nums[i], nums[i + 1]) = (nums[i + 1], nums[i]);
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
