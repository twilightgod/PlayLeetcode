using System;
using System.Collections.Generic;

namespace _0219
{
    public class Solution
    {
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            if (nums.Length == 0)
            {
                return false;
            }

            var set = new HashSet<int>();
            
            for (var i = 0; i < nums.Length; ++i)
            {
                if (set.Contains(nums[i]))
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
