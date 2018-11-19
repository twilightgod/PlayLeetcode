using System;
using System.Collections.Generic;

namespace _0080
{
    public class Solution
    {
        public int RemoveDuplicates(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }
            var dupset = new HashSet<int>();
            var idx = 0;
            for (var i = 1; i < nums.Length; ++i)
            {
                if (nums[i] != nums[idx])
                {
                    nums[++idx] = nums[i];
                }
                else if (!dupset.Contains(nums[i]))
                {
                    nums[++idx] = nums[i];
                    dupset.Add(nums[i]);
                }
            }
            return idx + 1;
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
