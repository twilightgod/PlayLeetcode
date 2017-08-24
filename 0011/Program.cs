using System;

namespace _0011
{
    public class Solution
    {
        public int MaxArea(int[] height)
        {
            var best = 0;
            var l = 0;
            var r = height.Length - 1;

            while (l < r)
            {
                best = Math.Max(best, Math.Min(height[l], height[r]) * (r - l));

                if (height[l] < height[r])
                {
                    l++;
                }
                else
                {
                    r--;
                }
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
