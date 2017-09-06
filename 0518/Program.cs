using System;

namespace _0518
{
    public class Solution
    {
        public int Change(int amount, int[] coins)
        {
            var ways = new int[amount + 1];
            ways[0] = 1;

            foreach (var coin in coins)
            {
                for (var i = 1; i <= amount; ++i)
                {
                    if (i - coin >= 0)
                    {
                        ways[i] += ways[i - coin];
                    }
                }
            }

            return ways[amount];
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
