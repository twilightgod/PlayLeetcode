using System;

namespace _0041
{
    public class Solution
    {
        public int FirstMissingPositive(int[] nums)
        {
            // perfect array should be [1, 2, ... n]
            var n = nums.Length;
            for (var i = 0; i < n; ++i)
            {
                while (nums[i] > 0 && nums[i] <= n && nums[nums[i] - 1] != nums[i])
                {
                    // if it's part of perfect array and not in it's position
                    // save pos to j to avoid nums[i] - 1 change during swap
                    var j = nums[i] - 1;
                    (nums[i], nums[j]) = (nums[j], nums[i]);
                }
            }

            for (var i = 0; i < n; ++i)
            {
                if (nums[i] != i + 1)
                {
                    return i + 1;
                }
            }

            return n + 1; 
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
