using System;

namespace _0283
{
    public class Solution
    {
        public void MoveZeroes(int[] nums)
        {
            var lastNonZeroIndex = 0;
            for (var i = 0; i < nums.Length; ++i)
            {
                if (nums[i] != 0)
                {
                    var t = nums[i];
                    nums[i] = nums[lastNonZeroIndex];
                    nums[lastNonZeroIndex] = t;
                    lastNonZeroIndex++;
                }
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
