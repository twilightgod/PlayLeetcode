using System;

namespace _0283
{
    public class Solution
    {
        public void MoveZeroes(int[] nums)
        {
            var lastZeroIndex = -1;
            for (var i = 0; i < nums.Length; ++i)
            {
                if (nums[i] == 0)
                {
                    lastZeroIndex = i;
                    break;
                }
            }

            var lastNonZeroIndex = -1;
            for (var i = lastZeroIndex + 1; i < nums.Length; ++i)
            {
                if (nums[i] != 0)
                {
                    lastNonZeroIndex = i;
                    break;
                }
            }

            if (lastZeroIndex == -1 || lastNonZeroIndex == -1)
            {
                return;
            }
            
            while (lastZeroIndex < lastNonZeroIndex)
            {
                var t = nums[lastNonZeroIndex];
                nums[lastNonZeroIndex] = nums[lastZeroIndex];
                nums[lastZeroIndex] = t;

                for (var i = lastZeroIndex + 1; i < nums.Length; ++i)
                {
                    if (nums[i] == 0)
                    {
                        lastZeroIndex = i;
                        break;
                    }
                }
 
 
                for (var i = lastZeroIndex + 1; i < nums.Length; ++i)
                {
                    if (nums[i] != 0)
                    {
                        lastNonZeroIndex = i;
                        break;
                    }
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
