using System;
using System.Collections.Generic;

namespace _0561
{
    public class Solution
    {
        public int ArrayPairSum(int[] nums)
        {
            var sorted = new List<int>(nums);
            sorted.Sort();

            var sum = 0;
            for (int i = 0; i < nums.Length; i+=2)
            {
                sum += sorted[i];
            }

            return sum;
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
