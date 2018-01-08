using System;

namespace _0075
{
    public class Solution
    {
        public void SortColors(int[] nums)
        {
            var p0 = 0;
            var p1 = 0;
            var p2 = nums.Length - 1;

            while (p1 <= p2)
            {
                if (nums[p1] == 1)
                {
                    p1++;
                }
                else if (nums[p1] == 0)
                {
                    nums[p1] = nums[p0];
                    nums[p0] = 0;
                    p1++;
                    p0++;
                }
                else
                {
                    nums[p1] = nums[p2];
                    nums[p2] = 2;
                    p2--;
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
