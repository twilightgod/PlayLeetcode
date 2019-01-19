using System;
using System.Collections.Generic;
using System.Linq;

namespace _0480_2
{
    public class Solution
    {
        public double[] MedianSlidingWindow(int[] nums, int k)
        {
            if (nums == null)
            {
                return null;
            }
            
            // Use 2 multisets, similar with 295 
            // SortedSet doesn't allow duplicate keys, so add index as part of the key, and we don't need value actually: <(nums[i], i)>
            var s1 = new SortedSet<(int, int)>(Comparer<(int, int)>.Create((x, y) => -x.CompareTo(y)));
            var s2 = new SortedSet<(int, int)>();
            var answer = new List<double>();

            for (var i = 0; i < nums.Length; ++i)
            {
                // add new element, keep two sets range correct first
                s1.Add((nums[i], i));
                s2.Add(s1.First());
                s1.Remove(s1.First());

                // remove expired element
                if (i - k >= 0)
                {
                    if (!s1.Remove((nums[i - k], i - k)))
                    {
                        s2.Remove((nums[i - k], i - k));
                    }
                }

                // balance, s1 has at most 1 more element than s2
                // s2 may has 2 more elements than s1 after insert and remove
                while (s2.Count - s1.Count >= 1)
                {
                    s1.Add(s2.First());
                    s2.Remove(s2.First());
                }

                if (i - k + 1 >= 0)
                {
                    answer.Add((k & 1) == 0 ? ((double)s1.First().Item1 + s2.First().Item1) / 2.0 : s1.First().Item1);
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
