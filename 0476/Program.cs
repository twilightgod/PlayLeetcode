using System;

namespace _0476
{
    public class Solution
    {
        public int FindComplement(int num)
        {
            int ans = 0;
            int k = 0;
            while (num > 0)
            {
                ans += (num % 2 == 0 ? 1 : 0) << k;
                num >>= 1;
                k++;
            }
            return ans;
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
