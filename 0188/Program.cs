using System;

namespace _0188
{
    public class Solution
    {
        public int MaxProfit(int k, int[] prices)
        {
            var answer = 0;
            var n = prices.Length;
            // k may be very large, there's no need to run dp when k >= n / 2, in this case, it's stock II problem.
            if (k >= n / 2)
            {
                return MaxProfitNaive(prices, n);
            }
            var hold = new int[k + 1];
            var sold = new int[k + 1];
            for (var i = 0; i <= k; ++i)
            {
                hold[i] = Int32.MinValue;
            }

            for (var i = 1; i <= n; ++i)
            {
                for (var j = k; j >= 1; --j)
                {
                    /*
                    rolling DP
                    hold[i, j] = Math.Max(hold[i - 1, j], sold[i - 1, j - 1] - prices[i - 1]);
                    sold[i, j] = Math.Max(sold[i - 1, j], hold[i - 1, j] + prices[i - 1]);
                    */
                    var pre_hold_j = hold[j];
                    hold[j] = Math.Max(hold[j], sold[j - 1] - prices[i - 1]);
                    sold[j] = Math.Max(sold[j], pre_hold_j + prices[i - 1]);
                    answer = Math.Max(answer, sold[j]);
                }
            }

            return answer;
        }

        private int MaxProfitNaive(int[] prices, int n)
        {
            var answer = 0;
            for (var i = 1; i < n; ++i)
            {
                if (prices[i] > prices[i - 1])
                {
                    answer += (prices[i] - prices[i - 1]);
                }
            }

            return answer;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            new Solution().MaxProfit(2, new int[] { 2, 4, 1 });
            Console.WriteLine("Hello World!");
        }
    }
}
