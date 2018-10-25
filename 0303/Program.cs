using System;

namespace _0303
{
    public class NumArray
    {
        int[] sum = null;

        public NumArray(int[] nums)
        {
            sum = new int[nums.Length];
            for (var i = 0; i < nums.Length; ++i)
            {
                if (i == 0)
                {
                    sum[0] = nums[0];
                }
                else
                {
                    sum[i] = sum[i - 1] + nums[i];
                }
            }
        }

        public int SumRange(int i, int j)
        {
            return sum[j] - (i == 0 ? 0 : sum[i - 1]);
        }
    }

    /**
     * Your NumArray object will be instantiated and called as such:
     * NumArray obj = new NumArray(nums);
     * int param_1 = obj.SumRange(i,j);
     */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
