using System;

namespace _0169
{
    public class Solution
    {
        public int MajorityElement(int[] nums)
        {
            var ans = nums[0];
            var cnt = 1;
            for (var i = 1; i < nums.Length; ++i)
            {
                if (nums[i] == ans)
                {
                    cnt ++;
                }
                else
                {
                    cnt --;
                }
                if (cnt == 0)
                {
                    ans = nums[i];
                    cnt = 1;
                }
            }
            return ans;
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
