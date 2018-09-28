using System;

namespace _0309
{
    public class Solution
    {
        public int MaxProfit(int[] prices)
        {
            /* rolling dp
            rest[i] = max{rest[i - 1], sold[i - 1]}
            sold[i] = hold[i - 1] + p[i]
            hold[i] = max{hold[i - 1], rest[i] - p[i]}
            */

            var rest = 0;
            var sold = 0;
            var hold = Int32.MinValue;

            for (var i = 0; i < prices.Length; ++i)
            {
                var pre_rest = rest;
                rest = Math.Max(rest, sold);
                sold = hold + prices[i];
                hold = Math.Max(hold, pre_rest - prices[i]);
            }

            return Math.Max(sold, rest);
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
