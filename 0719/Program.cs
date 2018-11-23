using System;

namespace _0719
{
    public class Solution
    {
        public int SmallestDistancePair(int[] nums, int k)
        {
            Array.Sort(nums);
            var n = nums.Length;
            var l = 0;
            var r = nums[n - 1] - nums[0] + 1;
            while (l < r)
            {
                var m = l + (r - l) / 2;
                var pairs = GetPairsWithDistanceNoMoreThanM(nums, n, m);
                if (pairs >= k)
                {
                    r = m;
                }
                else
                {
                    l = m + 1;
                }
            }
            return l;
        }

        private int GetPairsWithDistanceNoMoreThanM(int[] nums, int n, int m)
        {
            var counter = 0;
            var j = 1;
            for (var i = 0; i < n; ++i)
            {
                while (j < n && nums[j] - nums[i] <= m)
                {
                    j++;
                }
                // now j is the first one makes pair (i, j) has larger distance than m
                counter += (j - i - 1);
            }
            return counter;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //new Solution().SmallestDistancePair(new int[]{1, 3, 1}, 1);
            new Solution().SmallestDistancePair(new int[]{1, 6, 1}, 3);
            Console.WriteLine("Hello World!");
        }
    }
}
