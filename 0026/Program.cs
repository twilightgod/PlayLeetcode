using System;

namespace _0026
{
    public class Solution
    {
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }

            int idx = 1;
            for (int i = 1; i < nums.Length; ++i)
            {
                if (nums[i] != nums[i - 1])
                {
                    nums[idx++] = nums[i];
                }
            }

            return idx;
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
