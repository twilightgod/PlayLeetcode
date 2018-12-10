using System;

namespace _0322
{
    public class Solution
    {
        public int CoinChange(int[] coins, int amount)
        {
            // f[i] means the min coins needs to get value i
            var n = coins.Length;
            var f = new int[amount + 1];
            f[0] = 0;
            for (var i = 1; i < amount + 1; ++i)
            {
                f[i] = Int32.MaxValue;
            }
            for (var i = 0; i < n; ++i)
            {
                for (var j = 0; j <= amount - coins[i]; ++j)
                {
                    if (f[j] != Int32.MaxValue && f[j] + 1 < f[j + coins[i]])
                    {
                        f[j + coins[i]] = f[j] + 1;
                    }
                }
            }
            return f[amount] == Int32.MaxValue ? -1 : f[amount];
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
