using System;
using System.Collections.Generic;
using System.Linq;

namespace _0350
{
    public class Solution
    {
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            var l1 = nums1.ToList();
            var l2 = nums2.ToList();
            var l3 = new List<int>();
            l1.Sort();
            l2.Sort();

            var p1 = 0;
            var p2 = 0;
            while (p1 < l1.Count && p2 < l2.Count)
            {
                if (l1[p1] == l2[p2])
                {
                    l3.Add(l1[p1]);
                    p1++;
                    p2++;
                }
                else if (l1[p1] < l2[p2])
                {
                    p1++;
                }
                else
                {
                    p2++;
                }
            }

            return l3.ToArray();
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
