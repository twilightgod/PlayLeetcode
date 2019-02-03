using System;

namespace _0287
{
    public class Solution
    {
        public int FindDuplicate(int[] nums)
        {
            var start = nums[0];
            var slow = nums[0];
            var fast = nums[0];

            while (true)
            {
                slow = nums[slow];
                fast = nums[nums[fast]];
                if (slow == fast)
                {
                    while (start != slow)
                    {
                        start = nums[start];
                        slow = nums[slow];
                    }
                    return start;
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
