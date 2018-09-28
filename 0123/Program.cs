using System;

namespace _0123
{
    public class Solution
    {
        public int MaxProfit(int[] prices)
        {
            var answer = 0;
            var n = prices.Length;
            var k = 2;
            var hold = new int[n + 1, k + 1];
            var sold = new int[n + 1, k + 1];
            for (var i = 0; i <= n; ++i)
            {
                for (var j = 0; j <= k; ++j)
                {
                    hold[i, j] = Int32.MinValue;
                }
            }

            for (var i = 1; i <= n; ++i)
            {
                for (var j = 1; j <= k; ++j)
                {
                    hold[i, j] = Math.Max(hold[i - 1, j], sold[i - 1, j - 1] - prices[i - 1]);
                    sold[i, j] = Math.Max(sold[i - 1, j], hold[i - 1, j] + prices[i - 1]);
                    answer = Math.Max(answer, sold[i, j]);
                }
            }

            return answer;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().MaxProfit(new int[]{3,3,5,0,0,3,1,4});
            Console.WriteLine("Hello World!");
        }
    }
}
