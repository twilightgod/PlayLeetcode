using System;
using System.Collections.Generic;
using System.Linq;

namespace _0350_1
{
    public class Solution
    {
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            var map1 = new Dictionary<int, int>();
            foreach (var num in nums1)
            {
                if (!map1.ContainsKey(num))
                {
                    map1[num] = 0;
                }
                map1[num] ++;
            }
            var answer = new List<int>();
            foreach (var num in nums2)
            {
                if (map1.ContainsKey(num))
                {
                    answer.Add(num);
                    if (--map1[num] == 0)
                    {
                        map1.Remove(num);
                    }
                }
            }
            return answer.ToArray();
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
