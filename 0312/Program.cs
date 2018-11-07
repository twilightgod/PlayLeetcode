using System;
using System.Collections.Generic;

namespace _0312
{
    public class Solution
    {
        public int MaxCoins(int[] nums)
        {
            // padding
            var numList = new List<int>();
            numList.Add(1);
            numList.AddRange(nums);
            numList.Add(1);
            var n = numList.Count;
            var f = new int[n, n];
            for (var len = 1; len <= n - 2; ++len)
            {
                for (var i = 1; i < n - 1; ++i)
                {
                    var j = i + len - 1;
                    if (j >= n - 1)
                    {
                        continue;
                    }
                    for (var k = i; k <= j; ++k)
                    {
                        f[i, j] = Math.Max(f[i, j], numList[i - 1] * numList[k] * numList[j + 1] + (k - 1 >= i ? f[i, k - 1] : 0) + (k + 1 <= j ? f[k + 1, j] : 0));
                    }
                }
            }
            return f[1, n - 2];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().MaxCoins(new int[]{3, 1, 5, 8});
            Console.WriteLine("Hello World!");
        }
    }
}
