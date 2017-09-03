using System;

namespace _0190
{
    public class Solution
    {
        public uint reverseBits(uint n)
        {
            uint ans = 0;

            for (var i = 0; i < 32; ++i)
            {
                ans = (ans << 1) + n % 2;
                n >>= 1;
            }

            return ans;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().reverseBits(43261596));
        }
    }
}
