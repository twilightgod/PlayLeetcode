using System;
using System.Collections.Generic;
using System.Linq;

namespace _0373
{
    public class Solution
    {
        public IList<int[]> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            var answers = new List<int[]>();
            if (nums1 == null || nums1.Length == 0 || nums2 == null || nums2.Length == 0)
            {
                return answers;
            }
            var pq = new SortedSet<(int sum, int idx1, int idx2)>();
            for (var i = 0; i < Math.Min(nums1.Length, k); ++i)
            {
                pq.Add((nums1[i] + nums2[0], i, 0));
            }
            while (k-- > 0 && pq.Count > 0)
            {
                var node = pq.First();
                pq.Remove(node);
                answers.Add(new int[]{nums1[node.idx1], nums2[node.idx2]});
                if (node.idx2 + 1< nums2.Length)
                {
                    pq.Add((nums1[node.idx1] + nums2[node.idx2 + 1], node.idx1, node.idx2 + 1));
                }
            }
            return answers;
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
