using System;
using System.Collections.Generic;

namespace _0398
{
    public class Solution
    {
        List<(int, int)> numList = null;
        Random random = null;
        int n = 0;

        public Solution(int[] nums)
        {
            numList = new List<(int, int)>();
            n = nums.Length;
            for (var i = 0; i < n; ++i)
            {
                numList.Add((nums[i], i));
            }
            numList.Sort();
            random = new Random();
        }

        public int Pick(int target)
        {
            var l = 0;
            var r = n;
            while (l < r)
            {
                var m = l + (r - l) / 2;
                if (numList[m].Item1 >= target)
                {
                    r = m;
                }
                else
                {
                    l = m + 1;
                }
            }
            var lowerbound = l;

            l = 0;
            r = n;
            while (l < r)
            {
                var m = l + (r - l) / 2;
                if (numList[m].Item1 > target)
                {
                    r = m;
                }
                else
                {
                    l = m + 1;
                }
            }
            var upperbound = l;

            return numList[random.Next(lowerbound, upperbound)].Item2;
        }
    }

    /**
     * Your Solution object will be instantiated and called as such:
     * Solution obj = new Solution(nums);
     * int param_1 = obj.Pick(target);
     */

    class Program
    {
        static void Main(string[] args)
        {
            new Solution(new int[]{1,2,3,3,3}).Pick(3);
            Console.WriteLine("Hello World!");
        }
    }
}
