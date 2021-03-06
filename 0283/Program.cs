﻿using System;

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
                    (nums[i], nums[lastNonZeroIndex]) = (nums[lastNonZeroIndex], nums[i]);
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
