using System;
using System.Collections.Generic;

namespace _0035
{
    public class Solution
    {
        public int SearchInsert(int[] nums, int target)
        {
            var list = new List<int>(nums);
            var idx = list.BinarySearch(target);
            if (idx >= 0)
            {
                return idx;
            }
            else
            {
                return ~idx;
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
