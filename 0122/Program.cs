using System;

namespace _0122
{
    class Program
    {
        public class Solution
        {
            public int MaxProfit(int[] prices)
            {
                if (prices == null || prices.Length <= 1)
                {
                    return 0;
                }

                var answer = 0;
                for (var i = 1; i < prices.Length; ++i)
                {
                    if (prices[i] > prices[i - 1])
                    {
                        answer += (prices[i] - prices[i - 1]);
                    }
                }

                return answer;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
