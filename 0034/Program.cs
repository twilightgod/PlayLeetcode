using System;

namespace _0034
{
    public class Solution
    {
        public int[] SearchRange(int[] nums, int target)
        {
            var lowerbound = -1;
            var upperbound = -1;

            if (nums != null)
            {
                var n = nums.Length;
                if (n > 0)
                {
                    var l = 0;
                    var r = n;

                    while (l < r)
                    {
                        var m = l + (r - l) / 2;
                        if (nums[m] >= target)
                        {
                            r = m;
                        }
                        else
                        {
                            l = m + 1;
                        }
                    }

                    if (l < n && nums[l] == target)
                    {
                        lowerbound = l;

                        l = 0;
                        r = n;

                        while (l < r)
                        {
                            var m = l + (r - l) / 2;
                            if (nums[m] > target)
                            {
                                r = m;
                            }
                            else
                            {
                                l = m + 1;
                            }
                        }

                        upperbound = l - 1;
                    }
                }
            }

            return new int[] { lowerbound, upperbound };
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
