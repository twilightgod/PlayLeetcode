using System;
using System.Collections.Generic;

namespace _0548
{
    public class Solution
    {
        public bool SplitArray(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return false;
            }

            var n = nums.Length;
            var sum = new int[n];
            sum[0] = nums[0];
            for (var i = 1; i < n; ++i)
            {
                sum[i] = sum[i - 1] + nums[i];
            }

            for (var j = 3; j <= n - 4; ++j)
            {
                var s = new HashSet<int>();
                for (var i = 1; i <= j - 2; ++i)
                {
                    var s1 = sum[i - 1];
                    var s2 = sum[j - 1] - sum[i];
                    if (s1 == s2)
                    {
                        s.Add(s1);
                    }
                }
                for (var k = j + 2; k <= n - 2; ++k)
                {
                    var s3 = sum[k - 1] - sum[j];
                    var s4 = sum[n - 1] - sum[k];
                    if (s3 == s4 && s.Contains(s3))
                    {
                        return true;
                    }
                }
            }

            return false; 
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
