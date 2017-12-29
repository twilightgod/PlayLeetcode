using System;

namespace _0238
{
    public class Solution
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            var ans = new int[nums.Length];
            for (var i = 0; i < nums.Length - 1; ++i)
            {
                if (i == 0)
                {
                    ans[i] = nums[i];
                }
                else
                {
                    ans[i] = ans[i - 1] * nums[i];
                }
            }

            var product = 1;

            for (var i = nums.Length - 1; i >= 0; --i)
            {
                if (i == 0)
                {
                    ans[i] = product;
                }
                else
                {
                    ans[i] = product * ans[i - 1];
                    product *= nums[i]; 
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
