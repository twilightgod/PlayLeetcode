using System;
using System.Linq;

namespace _0875
{
    public class Solution
    {
        public int MinEatingSpeed(int[] piles, int H)
        {
            var l = 1;
            var r = piles.Max() + 1;
            
            while (l < r)
            {
                var m = l + (r - l) / 2;
                var sum = 0;
                foreach (var pile in piles)
                {
                    sum += (int)Math.Ceiling((double)pile / m);
                }
                if (sum <= H)
                {
                    r = m;
                }
                else
                {
                    l = m + 1;
                }
            }

            return l;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Solution().MinEatingSpeed(new int[]{312884470}, 968709470);
            Console.WriteLine("Hello World!");
        }
    }
}
