using System;
using System.Collections.Generic;
using System.Linq;

namespace _0349
{
    public class Solution
    {
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            var set = new HashSet<int>();
            foreach (var num in nums1)
            {
                set.Add(num);
            }

            var intersection = new HashSet<int>();
            foreach (var num in nums2)
            {
                if (set.Contains(num))
                {
                    intersection.Add(num);
                }
            }

            return intersection.ToArray();
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
