using System;

namespace _0121
{
    public class Solution
    {
        public int MaxProfit(int[] prices)
        {
            if (prices.Length == 0)
            {
                return 0;
            }

            var min = prices[0];
            var best = 0;

            for (var i = 1; i < prices.Length; ++i)
            {
                best = Math.Max(best, prices[i] - min);
                min = Math.Min(min, prices[i]);
            }

            return best;
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
