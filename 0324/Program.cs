using System;

namespace _0324
{
    public class Solution
    {
        public void WiggleSort(int[] nums)
        {
            Array.Sort(nums);
            var n = nums.Length;
            var answer = new int[n];
            var l = (n - 1) >> 1;
            var r = n - 1;
            for (var i = 0; i < n; ++i)
            {
                if ((i & 1) == 0)
                {
                    answer[i] = nums[l--];
                }
                else
                {
                    answer[i] = nums[r--];
                }
            }
            for (var i = 0; i < n; ++i)
            {
                nums[i] = answer[i];
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
