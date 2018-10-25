using System;
using System.Collections.Generic;

namespace _0307
{
    public class BIT
    {
        int[] sum = null;
        int n = 0;
        public BIT(int n)
        {
            this.n = n;
            sum = new int[n + 1];
        }

        public void Update(int index, int delta)
        {
            while (index <= n)
            {
                sum[index] += delta;
                index += LowBit(index);
            }
        }

        public int QueryPrefixSum(int index)
        {
            var s = 0;
            while (index > 0)
            {
                s += sum[index];
                index -= LowBit(index);
            }
            return s;
        }

        private int LowBit(int x)
        {
            return x & (-x);
        }
    }

    public class NumArray
    {
        BIT Bit = null;
        List<int> Nums = null;

        public NumArray(int[] nums)
        {
            Nums = new List<int>(nums);
            Bit = new BIT(nums.Length);
            for (var i = 0; i < nums.Length; ++i)
            {
                Bit.Update(i + 1, nums[i]);
            }
        }

        public void Update(int i, int val)
        {
            Bit.Update(i + 1, val - Nums[i]);
            Nums[i] = val;
        }

        public int SumRange(int i, int j)
        {
            return Bit.QueryPrefixSum(j + 1) - (i == 0 ? 0 : Bit.QueryPrefixSum(i));
        }
    }

    /**
     * Your NumArray object will be instantiated and called as such:
     * NumArray obj = new NumArray(nums);
     * obj.Update(i,val);
     * int param_2 = obj.SumRange(i,j);
     */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
